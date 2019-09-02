using AutoMapper;
using IFSP.Plataforma.Application.ViewModels;
using IFSP.Plataforma.Domain.Entities;

namespace IFSP.Plataforma.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Chatbot, ChatbotViewModel>();
            CreateMap<Dialogue, DialogueViewModel>();
        }
    }
}
