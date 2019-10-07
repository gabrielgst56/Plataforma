using System;
using System.Threading;
using System.Threading.Tasks;
using IFSP.Plataforma.Domain.Commands.Chatbot;
using IFSP.Plataforma.Domain.Core.Bus;
using IFSP.Plataforma.Domain.Core.Notifications;
using IFSP.Plataforma.Domain.Entities;
using IFSP.Plataforma.Domain.Interfaces;
using MediatR;

namespace IFSP.Plataforma.Domain.CommandHandler
{
    public class ChatbotCommandHandler : CommandHandler,
        IRequestHandler<AddChatbotCommand, bool>,
        IRequestHandler<UpdateChatbotCommand, bool>,
        IRequestHandler<RemoveChatbotCommand, bool>
    {
        private readonly IChatbotRepository _chatbotRepository;
        private readonly IMediatorHandler Bus;

        public ChatbotCommandHandler(IChatbotRepository chatbotRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _chatbotRepository = chatbotRepository;
            Bus = bus;
        }

        public Task<bool> Handle(AddChatbotCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var chatbot = new Chatbot(message.Id, message.Name, message.Description, message.DiscordExported, message.MessengerExported,
                message.DiscordBotSecret, message.CreatedDate);

            _chatbotRepository.Adicionar(chatbot);

            _chatbotRepository.AdicionarDialogues(message.Dialogues, chatbot.Id, null);

            /*if (Commit())
            {
                Bus.RaiseEvent(new ChatbotAddedEvent(user.Id, user.Name, user.Email, user.Password, user.BirthDate));
            }*/

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateChatbotCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var chatbot = new Chatbot(message.Id, message.Name, message.Description, message.DiscordExported, message.MessengerExported,
                message.DiscordBotSecret, message.Dialogues, message.User, message.CreatedDate);

            _chatbotRepository.Update(chatbot);

            /*
            if (Commit())
            {
                Bus.RaiseEvent(new UserUpdatedEvent(user.Id, user.Name, user.Email, user.Password, user.BirthDate));
            }*/

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveChatbotCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _chatbotRepository.Remove(message.Id);
            /*
            if (Commit())
            {
                Bus.RaiseEvent(new UserRemovedEvent(message.Id));
            }*/

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _chatbotRepository.Dispose();
        }
    }
}
