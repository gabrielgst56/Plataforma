using IFSP.Plataforma.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IFSP.Plataforma.Domain.Entities
{
    public class Chatbot : Entity
    {
        public Chatbot(Guid id, string name, string description, bool discordExported, bool messengerExported
            , string discordBotSecret, List<Dialogue> dialogues, User user, DateTime? createdDate)
        {
            Id = id;
            Name = name;
            Description = description;
            DiscordExported = discordExported;
            MessengerExported = messengerExported;
            DiscordBotSecret = discordBotSecret;
            Dialogues = dialogues;
            User = user;
            UserId = user?.Id;
            CreatedDate = createdDate;
        }

        public Chatbot(Guid id, string name, string description, bool discordExported, bool messengerExported
            , string discordBotSecret, DateTime? createdDate)
        {
            Id = id;
            Name = name;
            Description = description;
            DiscordExported = discordExported;
            MessengerExported = messengerExported;
            DiscordBotSecret = discordBotSecret;
            User = null;
            UserId = null;
            CreatedDate = createdDate;
        }

        // Empty constructor for EF
        protected Chatbot() { }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool DiscordExported { get; set; }

        public bool MessengerExported { get; set; }

        public string DiscordBotSecret { get; set; }

        public List<Dialogue> Dialogues { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
