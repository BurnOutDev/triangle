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
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public OrdersController(ILogger<OrdersController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ReservationsViewModel();

            var reservations = await GetData<ReservationsQueryResult>("Reservation/GetReservations", "GET");

            viewModel.Reservations = reservations;

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