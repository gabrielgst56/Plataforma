using IFSP.Plataforma.Domain.Entities;
using IFSP.Plataforma.Domain.Validations.Chatbot;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFSP.Plataforma.Domain.Commands.Chatbot
{
    public class AddChatbotCommand : ChatbotCommand
    {
        public AddChatbotCommand(Guid id, string name, string description, bool discordExported, bool messengerExported
            , string discordBotSecret, List<Dialogue> dialogues, Entities.User user, DateTime? createdDate)
        {
            Id = id;
            Name = name;
            Description = description;
            DiscordExported = discordExported;
            MessengerExported = messengerExported;
            DiscordBotSecret = discordBotSecret;
            Dialogues = dialogues;
            User = user;
            CreatedDate = createdDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddChatbotCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
