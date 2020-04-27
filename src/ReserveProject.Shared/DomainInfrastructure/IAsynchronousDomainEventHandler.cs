using MediatR;

namespace ReserveProject.Shared.DomainInfrastructure
{
    public interface IAsynchronousDomainEventHandler<in TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
    }
}