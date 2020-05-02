using MediatR;

namespace ReserveProject.Shared.ApplicationInfrastructure
{
    public interface ICommand<T> : IRequest<T>
    {
    }
}