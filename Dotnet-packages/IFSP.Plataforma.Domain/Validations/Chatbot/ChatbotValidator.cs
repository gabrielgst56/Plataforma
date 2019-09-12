using FluentValidation;
using IFSP.Plataforma.Domain.Commands.Chatbot;
using System;

namespace IFSP.Plataforma.Domain.Validations.Chatbot
{
    public abstract class ChatbotValidator<T> : AbstractValidator<T> where T : ChatbotCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
    }
}
