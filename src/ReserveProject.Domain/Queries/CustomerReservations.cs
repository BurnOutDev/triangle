using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Queries
{
    public class CustomerReservationsQueryResult : ReservationsQueryResult
    {
        public int CustomerId { get; set; }
    }
}
