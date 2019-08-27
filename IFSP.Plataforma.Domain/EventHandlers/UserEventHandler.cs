using System.Threading;
using System.Threading.Tasks;
using IFSP.Plataforma.Domain.Events.User;
using MediatR;

namespace IFSP.Plataforma.Domain.EventHandlers
{
    public class UserEventHandler :
        INotificationHandler<UserAddedEvent>,
        INotificationHandler<UserUpdatedEvent>,
        INotificationHandler<UserRemovedEvent>
    {
        public Task Handle(UserUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Faça o pós adição, atualizar cache ou algo parecido??

            return Task.CompletedTask;
        }

        public Task Handle(UserAddedEvent message, CancellationToken cancellationToken)
        {
            // Faça o pós adição, atualizar cache ou algo parecido??

            return Task.CompletedTask;
        }

        public Task Handle(UserRemovedEvent message, CancellationToken cancellationToken)
        {
            // Faça o pós adição, atualizar cache ou algo parecido??

            return Task.CompletedTask;
        }
    }
}
