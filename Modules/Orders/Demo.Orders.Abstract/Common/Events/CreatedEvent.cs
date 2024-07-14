using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Common.Events
{
    public class CreatedEvent<T> : DomainEvent where T : IEntity
    {
        public CreatedEvent(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }
}
