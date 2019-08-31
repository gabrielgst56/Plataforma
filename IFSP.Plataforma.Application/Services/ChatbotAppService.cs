using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using IFSP.Plataforma.Application.Interfaces;
using IFSP.Plataforma.Application.ViewModels;
using IFSP.Plataforma.Domain.Commands.Chatbot;
using IFSP.Plataforma.Domain.Core.Bus;
using IFSP.Plataforma.Domain.Interfaces;

namespace IFSP.Plataforma.Application.Services
{
    public class ChatbotAppService : IChatbotAppService
    {
        private readonly IMapper _mapper;
        private readonly IChatbotRepository _chatbotRepository;
        private readonly IMediatorHandler Bus;

        public ChatbotAppService(IMapper mapper,
                                  IChatbotRepository chatbotRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _chatbotRepository = chatbotRepository;
            Bus = bus;
        }

        public IEnumerable<ChatbotViewModel> GetAll()
        {
            return _chatbotRepository.GetAll().ProjectTo<ChatbotViewModel>(_mapper.ConfigurationProvider);
        }

        public ChatbotViewModel GetById(Guid id)
        {
            return _mapper.Map<ChatbotViewModel>(_chatbotRepository.GetById(id));
        }

        public void Register(ChatbotViewModel chatbotViewModel)
        {
            var registerCommand = _mapper.Map<AddChatbotCommand>(chatbotViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ChatbotViewModel chatbotViewModel)
        {
            var updateCommand = _mapper.Map<UpdateChatbotCommand>(chatbotViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveChatbotCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
