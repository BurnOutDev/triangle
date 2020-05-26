using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ReserveProject.Client.Models
{
    public class ProfileViewModel : RestaurantProfileQueryResult
    {
        public CuisinesQueryResult CuisinesQuery { get; set; }

        [FromForm]
        public IFormFile FormImage { get; set; }
    }
}
