using ReserveProject.Domain;
using ReserveProject.Domain.Commands;
using ReserveProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Application.Services
{
    public class ReservationService : IReservationService
    {
        public ReserveDbContext Context { get; }

        public ReservationService(ReserveDbContext context)
        {
            Context = context;
        }


    }
}
