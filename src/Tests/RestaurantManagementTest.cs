using System;
using Xunit;
using ReserveProject.Application.Services;
using Flurl;
using Flurl.Http;

namespace Tests
{
    public class RestaurantManagementTest
    {
        private const string Url = "http://localhost:5001";

        [Fact]
        public void FirstTest() {
            Url.AppendPathSegment("Organization")
        }
    }
}
