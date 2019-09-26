using IFSP.Plataforma.Domain.Commands.User;

namespace IFSP.Plataforma.Domain.Validations.User
{
    public class RemoveUserCommandValidator : UserValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            ValidateId();
        }
    }
}
