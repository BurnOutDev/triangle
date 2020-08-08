using ReserveProject.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Converters
{
    public static class CustomerExtensions
    {
        public static CustomerProfileQueryResult ToQueryResult(this Customer customer)
        {
            var result = new CustomerProfileQueryResult
            {
                Avatar = customer.Avatar,
                BithDate = customer.BithDate,
                Email = customer.Email,
                FacebookId = customer.FacebookId,
                FirstName = customer.FirstName,
                Gender = customer.Gender,
                IsActivated = customer.IsActivated,
                LastName = customer.LastName,
                PhoneNumber = customer.LastName
            };

            return result;
        }
    }
}
