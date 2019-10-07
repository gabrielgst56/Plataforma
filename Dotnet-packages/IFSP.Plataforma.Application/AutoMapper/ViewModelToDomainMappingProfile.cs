using AutoMapper;
using IFSP.Plataforma.Application.ViewModels;
using IFSP.Plataforma.Domain.Commands.Chatbot;
using IFSP.Plataforma.Domain.Commands.User;
using IFSP.Plataforma.Domain.Entities;
using System.Collections.Generic;

namespace IFSP.Plataforma.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        private readonly Mapper _mapper;

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, AddUserCommand>()
                .ConstructUsing(c => new AddUserCommand(c.Name, c.Email, c.Password, c.BirthDate));
            CreateMap<UserViewModel, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id, c.Name, c.Email, c.Password, c.BirthDate));
            CreateMap<Dialogue, Dialogue>();
            CreateMap<Dialogue, DialogueViewModel>().ReverseMap();
            CreateMap<Chatbot, Chatbot>();
            CreateMap<Chatbot, ChatbotViewModel>().ReverseMap();
            CreateMap<User, User>();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<ChatbotViewModel, AddChatbotCommand>()
                .ConstructUsing(c => new AddChatbotCommand(c.Id, c.Name, c.Description, c.DiscordExported, c.MessengerExported,
                c.DiscordBotSecret, _mapper.Map<List<Dialogue>>(c.Dialogues), _mapper.Map<User>(c.User), c.CreatedDate));
            CreateMap<UserViewModel, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id, c.Name, c.Email, c.Password, c.BirthDate));
        }
    }
}
