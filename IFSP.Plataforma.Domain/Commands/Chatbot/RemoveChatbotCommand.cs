using IFSP.Plataforma.Domain.Validations.Chatbot;
using System;

namespace IFSP.Plataforma.Domain.Commands.Chatbot
{
    public class RemoveChatbotCommand : ChatbotCommand
    {
        public RemoveChatbotCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveChatbotCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
