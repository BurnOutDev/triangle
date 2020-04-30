using ReserveProject.Domain;
using ReserveProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Application
{
    public partial class CuisineService : ICuisineService
    {
        private ReserveDbContext _context;

        public CuisineService(ReserveDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CuisineModel> GetAll()
        {
            return _context.Set<Cuisine>().Select(cuisine => new CuisineModel
            {
                Name = cuisine.Name,
                Icon = cuisine.Icon
            }).AsEnumerable();
        }
    }
}