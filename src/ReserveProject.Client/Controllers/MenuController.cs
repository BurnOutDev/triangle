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

            var categories = await GetData<CategoriesQueryResult>("Menu/Categories", "GET");
            var ingredients = await GetData<IngredientsQueryResult>("Menu/Ingredients", "GET");
            var menuItems = await GetData<RestaurantMenuItemsQueryResult>("Menu/GetMenuItems", "GET");

            viewModel.CategoriesQuery = categories;
            viewModel.IngredientsQuery = ingredients;
            viewModel.MenuItems = menuItems;

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
            var response = await client.ExecuteAsync(request, Enum.Parse<Method>(method));

            var content = JsonConvert.DeserializeObject<T>(response.Content);

            return content;
        }
    }
}