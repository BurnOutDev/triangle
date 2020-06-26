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
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(ILogger<ProfileController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "/Restaurant/Profile");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ProfileViewModel>(content);

            var requestEnums = new HttpRequestMessage(HttpMethod.Get, "/Restaurant/Cuisines");
            var responseEnums = await httpClient.SendAsync(requestEnums, HttpCompletionOption.ResponseHeadersRead);
            responseEnums.EnsureSuccessStatusCode();
            var cuisinesEnum = await responseEnums.Content.ReadAsStringAsync();
            model.CuisinesQuery = JsonConvert.DeserializeObject<CuisinesQueryResult>(cuisinesEnum);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProfileData(ProfileViewModel model)
        {
            using (var memoryStream = new MemoryStream())
            {
                if (model.FormImage != null)
                {
                    model.FormImage.CopyTo(memoryStream);
                    var bytes = memoryStream.ToArray();

                    model.ImageUrl = $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
                }
            }

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var client = new RestClient("http://localhost:5001");
            client.AddDefaultHeader("Authorization", $"Bearer {accessToken}");

            var request = new RestRequest("Restaurant/Update");
            request.AddJsonBody(model);

            var response = client.Post(request);

            return RedirectToAction(nameof(Index));
        }
    }
}