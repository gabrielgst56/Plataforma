using System;
using IFSP.Plataforma.Domain.Core.Commands;

namespace IFSP.Plataforma.Domain.Commands.User
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public DateTime BirthDate { get; protected set; }
    }
}
