using MediatR;

namespace ReserveProject.Shared.ApplicationInfrastructure
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}