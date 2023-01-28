using Flunt.Notifications;
using System;

namespace Store.Domain.Entites
{
    public class EntityBase : Notifiable<Notification>
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();    
        }
        public Guid Id { get; private set; }
    }
}
