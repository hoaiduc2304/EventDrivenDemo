using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Common.Events
{
    public class DeletedEvent<T> : DomainEvent where T : IEntity
    {
        public DeletedEvent(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }
}
