using System;
using IFSP.Plataforma.Domain.Commands.User;

namespace IFSP.Plataforma.Domain.Validations.User
{
    public class AddUserCommandValidator : UserValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            ValidateName();
            ValidateBirthDate();
            ValidatePassword();
            ValidateEmail();
        }
    }
}
