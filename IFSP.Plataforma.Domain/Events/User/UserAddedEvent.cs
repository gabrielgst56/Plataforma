using System;
using IFSP.Plataforma.Domain.Core.Events;

namespace IFSP.Plataforma.Domain.Events.User
{
    public class UserAddedEvent : Event
    {
        public UserAddedEvent(Guid id, string name, string email, string password, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
