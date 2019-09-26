using System;
using IFSP.Plataforma.Domain.Core.Models;

namespace IFSP.Plataforma.Domain.Entities
{
    public class User : Entity
    {
        public User(Guid id, string name, string password, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            BirthDate = birthDate;
        }

        // Empty constructor for EF
        protected User() { }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
