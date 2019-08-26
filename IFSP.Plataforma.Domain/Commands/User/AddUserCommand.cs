using IFSP.Plataforma.Domain.Validations.User;
using System;

namespace IFSP.Plataforma.Domain.Commands.User
{
    public class AddUserCommand : UserCommand
    {
        public AddUserCommand(string name, string email, string password, DateTime birthDate)
        {
            Name = name;
            Email = email;
            Password = password;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddUserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
