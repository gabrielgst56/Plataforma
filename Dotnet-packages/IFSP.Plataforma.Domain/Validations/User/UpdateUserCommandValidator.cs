using IFSP.Plataforma.Domain.Commands.User;

namespace IFSP.Plataforma.Domain.Validations.User
{
    public class UpdateUserCommandValidator : UserValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            ValidateId();
            ValidateName();
            ValidatePassword();
            ValidateEmail();
        }
    }
}
