using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Entities
{
    public class OutboxMessage: IEntity<Guid>
    {
        public Guid id { get; set; }
        public string AggregateType { get; set; }
        public Guid AggregateId { get; set; }
        public string EventType { get; set; }
        public string Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Published { get; set; }
    }
}
