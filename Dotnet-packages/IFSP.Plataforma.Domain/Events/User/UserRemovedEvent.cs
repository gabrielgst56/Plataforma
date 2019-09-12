using System;
using IFSP.Plataforma.Domain.Core.Events;

namespace IFSP.Plataforma.Domain.Events.User
{
    public class UserRemovedEvent : Event
    {
        public UserRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
