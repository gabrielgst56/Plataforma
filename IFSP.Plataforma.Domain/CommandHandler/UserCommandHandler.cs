using System;
using System.Threading;
using System.Threading.Tasks;
using IFSP.Plataforma.Domain.Commands.User;
using IFSP.Plataforma.Domain.Core.Bus;
using IFSP.Plataforma.Domain.Core.Notifications;
using IFSP.Plataforma.Domain.Entities;
using IFSP.Plataforma.Domain.Events.User;
using IFSP.Plataforma.Domain.Interfaces;
using MediatR;

namespace IFSP.Plataforma.Domain.CommandHandler
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<AddUserCommand, bool>,
        IRequestHandler<UpdateUserCommand, bool>,
        IRequestHandler<RemoveUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler Bus;

        public UserCommandHandler(IUserRepository userRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _userRepository = userRepository;
            Bus = bus;
        }

        public Task<bool> Handle(AddUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var user = new User(Guid.NewGuid(), message.Name, message.Password, message.Email, message.BirthDate);

            if (_userRepository.GetByEmail(user.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The user e-mail has already been taken."));
                return Task.FromResult(false);
            }

            _userRepository.Add(user);

            if (Commit())
            {
                Bus.RaiseEvent(new UserAddedEvent(user.Id, user.Name, user.Email,user.Password, user.BirthDate));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var user = new User(message.Id, message.Name, message.Password, message.Email, message.BirthDate);
            var existingUser = _userRepository.GetByEmail(user.Email);

            if (existingUser != null && existingUser.Id != user.Id)
            {
                if (!existingUser.Equals(user))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The user e-mail has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _userRepository.Update(user);

            if (Commit())
            {
                Bus.RaiseEvent(new UserUpdatedEvent(user.Id, user.Name, user.Email, user.Password, user.BirthDate));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _userRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new UserRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
