using IFSP.Plataforma.Domain.Entities;
using IFSP.Plataforma.Domain.Interfaces;
using IFSP.Plataforma.Infra.Data.Context;

namespace IFSP.Plataforma.Infra.Data.Repository
{
    public class ChatbotRepository : Repository<Chatbot>, IChatbotRepository
    {
        public ChatbotRepository(DataContext context)
            : base(context)
        {

        }
    }
}
