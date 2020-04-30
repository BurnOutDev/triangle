using System.Collections.Generic;

namespace ReserveProject.Application
{
    public interface ICuisineService
    {
        IEnumerable<CuisineModel> GetAll();
    }
}