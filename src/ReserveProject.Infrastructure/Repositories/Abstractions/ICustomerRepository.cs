using ReserveProject.Domain.Aggregates.CustomerAggregate;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
