using System;
using System.Collections.Generic;
using IFSP.Plataforma.Application.ViewModels;

namespace IFSP.Plataforma.Application.Interfaces
{
    public interface IChatbotAppService : IDisposable
    {
        void Add(ChatbotViewModel chatbotViewModel);
        IEnumerable<ChatbotViewModel> GetAll();
        ChatbotViewModel GetById(Guid id);
        void Update(ChatbotViewModel chatbotViewModel);
        void Remove(Guid id);
    }
}
