using Dinner.Domain.MenuAggregate.Events;
using MediatR;

namespace Dinner.Application.Dinners.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
