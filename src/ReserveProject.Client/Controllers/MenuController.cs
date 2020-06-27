using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using ReserveProject.Client.Models;
using ReserveProject.Domain.Queries;
using RestSharp;
using RestSharp.Authenticators;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ReserveProject.Client.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(ILogger<ProfileController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new MenuItemsViewModel();

            var ingredients = await GetData<IngredientsQueryResult>("Menu/Ingredients", "GET");
            var menuItems = await GetData<RestaurantMenuItemsQueryResult>("Menu/GetMenuItems", "GET");

            viewModel.IngredientsQuery = ingredients;
            viewModel.MenuItems = menuItems;

            return View(model: viewModel);
        }

        public async Task<IActionResult> Add()
        {
            var categories = await GetData<KeyValuesQueryResult>("Menu/Categories", "GET");
            var ingredients = await GetData<IngredientsQueryResult>("Menu/Ingredients", "GET");

            var viewModel = new AddMenuItemViewModel
            {
                CategoriesQuery = categories,
                IngredientsQuery = ingredients
            };

            return View(model: viewModel);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Add(AddMenuItemViewModel menuItem)
        {
            using (var memoryStream = new MemoryStream())
            {
                if (menuItem.FormImage != null)
                {
                    menuItem.FormImage.CopyTo(memoryStream);
                    var bytes = memoryStream.ToArray();

                    menuItem.ImageUrl = $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
                }
            }

            var response = await ApiRequest("Menu/AddMenuItem", "POST", menuItem);

            return RedirectToActionPermanent("Index");
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> EditMenuItem(EditMenuItemViewModel menuItem)
        {
            using (var memoryStream = new MemoryStream())
            {
                if (menuItem.FormImage != null)
                {
                    menuItem.FormImage.CopyTo(memoryStream);
                    var bytes = memoryStream.ToArray();

                    menuItem.ImageUrl = $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
                }
            }

            var response = await ApiRequest("Menu/EditMenuItem", "POST", menuItem);

            return RedirectToActionPermanent("Edit", new { id = menuItem.Id });
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await GetData<KeyValuesQueryResult>("Menu/Categories", "GET");
            var ingredients = await GetData<IngredientsQueryResult>("Menu/Ingredients", "GET");
            var m = await GetData<RestaurantMenuItemQueryResult>($"Menu/Get?id={id}", "GET");

            var viewModel = new EditMenuItemViewModel
            {
                CategoryId = m.CategoryId,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                IngredientIds = m.IngredientIds,
                Name = m.Name,
                Price = m.Price,
                Unavailable = m.Unavailable,

                Id = m.MenuItemId,

                CategoriesQuery = categories,
                IngredientsQuery = ingredients
            };

            return View(model: viewModel);
        }

        public async Task<T> GetData<T>(string url, string method, object data = null)
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var client = new RestClient("http://localhost:5001");
            client.AddDefaultHeader("Authorization", $"Bearer {accessToken}");

            var request = new RestRequest(url);

            if (data != null)
            {
                request.AddJsonBody(data);
            }

            //var response = client.Post<T>(request);
            var response = await ApiRequest(url, method, data);

            var content = JsonConvert.DeserializeObject<T>(response.Content);

            return content;
        }

        public async Task<IRestResponse> ApiRequest(string url, string method, object data = null)
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var client = new RestClient("http://localhost:5001");
            client.AddDefaultHeader("Authorization", $"Bearer {accessToken}");

            var request = new RestRequest(url);

            if (data != null)
            {
                request.AddJsonBody(data);
            }

            //var response = client.Post<T>(request);
            var response = await client.ExecuteAsync(request, Enum.Parse<Method>(method));

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw response.ErrorException;
            }

            return response;
        }

    }
}