using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Common.Events
{
    public interface IExportedEvent<out TKey, out TPayload>
    {
        TKey GetAggregateId();
        string GetAggregateType();
        TPayload GetPayload();
        string GetType();
        DateTime GetTimestamp();
    }
    public class SagaEvent<Guid, TPayload> : IExportedEvent<string, TPayload>
    {
        public Guid SagaId { get; }
        public string AggregateType { get; }
        public string EventType { get; }
        public TPayload Payload { get; }
        public DateTime Timestamp { get; }

        public SagaEvent(Guid sagaId, string aggregateType, string eventType, TPayload payload)
        {
            SagaId = sagaId;
            AggregateType = aggregateType;
            EventType = eventType;
            Payload = payload;
            Timestamp = DateTime.UtcNow;
        }

        public string GetAggregateId() => SagaId.ToString();
        public string GetAggregateType() => AggregateType;
        public TPayload GetPayload() => Payload;
        public string GetType() => EventType;
        public DateTime GetTimestamp() => Timestamp;
    }
}
