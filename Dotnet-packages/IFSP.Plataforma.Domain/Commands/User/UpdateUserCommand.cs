using System;
using IFSP.Plataforma.Domain.Validations.User;

namespace IFSP.Plataforma.Domain.Commands.User
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(Guid id, string name, string email, string password, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
