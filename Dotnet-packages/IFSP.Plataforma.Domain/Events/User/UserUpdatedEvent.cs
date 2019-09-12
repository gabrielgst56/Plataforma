using IFSP.Plataforma.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFSP.Plataforma.Domain.Events.User
{
    public class UserUpdatedEvent : Event
    {
        public UserUpdatedEvent(Guid id, string name, string email, string password, DateTime birthDate)
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
