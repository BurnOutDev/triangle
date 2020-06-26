using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ReserveProject.Client.Models
{
    public class ProfileViewModel
    {
        public CuisinesQueryResult CuisinesQuery { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }

        public string BusinessId { get; set; }
        public string FacebookId { get; set; }

        public string ImageUrl { get; set; }

        public string Address { get; set; }
        public string AddressLongtitude { get; set; }
        public string AddressLatitude { get; set; }

        public int CuisineId { get; set; }
        public int PriceRange { get; set; }

        public bool HasParking { get; set; }
        public bool IsCardPaymentAvailable { get; set; }

        [FromForm]
        public IFormFile FormImage { get; set; }
    }
}
