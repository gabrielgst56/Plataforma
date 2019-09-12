using IFSP.Plataforma.Domain.Validations.User;
using System;

namespace IFSP.Plataforma.Domain.Commands.User
{
    public class RemoveUserCommand : UserCommand
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
