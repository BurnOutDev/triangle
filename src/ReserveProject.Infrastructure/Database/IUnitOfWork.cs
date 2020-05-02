using System.Threading.Tasks;

namespace ReserveProject.Infrastructure.Database
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}