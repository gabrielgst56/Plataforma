using IFSP.Plataforma.Domain.Commands.Chatbot;

namespace IFSP.Plataforma.Domain.Validations.Chatbot
{
    public class UpdateChatbotCommandValidator : ChatbotValidator<UpdateChatbotCommand>
    {
        public UpdateChatbotCommandValidator()
        {
            ValidateName();
        }
    }
}
