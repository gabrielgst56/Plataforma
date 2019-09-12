using IFSP.Plataforma.Domain.Commands.Chatbot;

namespace IFSP.Plataforma.Domain.Validations.Chatbot
{
    public class AddChatbotCommandValidator : ChatbotValidator<AddChatbotCommand>
    {
        public AddChatbotCommandValidator()
        {
            ValidateName();
        }
    }
}
