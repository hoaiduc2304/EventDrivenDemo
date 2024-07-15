using Demo.Orders.Domain.Common.Events;
using Demo.Orders.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Common.Extension
{
    public static class SagaEventExtensions
    {
        public static string ToJson(this SagaEvent<Guid,PurchaseOrder> sagaEvent)
        {
            return JsonConvert.SerializeObject(new
            {
                sagaId = sagaEvent.SagaId,
                aggregateType = sagaEvent.AggregateType,
                eventType = sagaEvent.EventType,
                payload = sagaEvent.Payload,
                timestamp = sagaEvent.Timestamp
            });
        }
    }
}
