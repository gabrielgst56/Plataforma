using System;
using System.Collections.Generic;
using IFSP.Plataforma.Domain.Entities;

namespace IFSP.Plataforma.Domain.Interfaces
{
    public interface IChatbotRepository : IRepository<Chatbot>
    {
        void Adicionar(Chatbot obj);
        void AdicionarDialogues(List<Dialogue> dialogues, Guid id, Guid? FatherId);
    }
}
