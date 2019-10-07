using IFSP.Plataforma.Domain.Core.Commands;
using IFSP.Plataforma.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IFSP.Plataforma.Domain.Commands.Chatbot
{
    public abstract class ChatbotCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public bool DiscordExported { get; protected set; }

        public bool MessengerExported { get; protected set; }

        public string DiscordBotSecret { get; protected set; }

        public List<Dialogue> Dialogues { get; protected set; }

        public Entities.User User { get; protected set; }

        public DateTime? CreatedDate { get; set; }
    }
}
