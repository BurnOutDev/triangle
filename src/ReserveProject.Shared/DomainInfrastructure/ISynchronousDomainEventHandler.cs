using MediatR;

namespace ReserveProject.Shared.DomainInfrastructure
{
    public interface ISynchronousDomainEventHandler<in TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
    }
}