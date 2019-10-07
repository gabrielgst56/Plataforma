using IFSP.Plataforma.Application.Interfaces;
using IFSP.Plataforma.Application.Services;
using IFSP.Plataforma.Domain.CommandHandler;
using IFSP.Plataforma.Domain.Commands.Chatbot;
using IFSP.Plataforma.Domain.Commands.User;
using IFSP.Plataforma.Domain.Core.Bus;
using IFSP.Plataforma.Domain.Core.Notifications;
using IFSP.Plataforma.Domain.EventHandlers;
using IFSP.Plataforma.Domain.Events.User;
using IFSP.Plataforma.Domain.Interfaces;
using IFSP.Plataforma.Infra.CrossCutting.Bus;
using IFSP.Plataforma.Infra.Data.Context;
using IFSP.Plataforma.Infra.Data.Repository;
using IFSP.Plataforma.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IFSP.Plataforma.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IChatbotAppService, ChatbotAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UserAddedEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserUpdatedEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserRemovedEvent>, UserEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<AddChatbotCommand, bool>, ChatbotCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateChatbotCommand, bool>, ChatbotCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveChatbotCommand, bool>, ChatbotCommandHandler>();

            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatbotRepository, ChatbotRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataContext>();

        }
    }
}
