using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Asbtract.Common.Events
{
    public interface IExportedEvent<out TKey, out TPayload>
    {
        TKey GetAggregateId();
        string GetAggregateType();
        TPayload GetPayload();
        string GetType();
        DateTime GetTimestamp();
    }
    public class SagaEvent<TKey, TPayload> //: IExportedEvent<TKey, TPayload>
    {
        //public TKey SagaId { get; }
        //public string AggregateType { get; }
        //public string EventType { get; }
        public TPayload Payload { get; }
        //public DateTime Timestamp { get; }

        public SagaEvent(TKey sagaId,  TPayload payload)
        {
           // SagaId = sagaId;
          //  AggregateType = aggregateType;
          //  EventType = eventType;
            Payload = payload;
         //   Timestamp = DateTime.UtcNow;
        }

        //public string GetAggregateId() => SagaId.ToString();
        //public string GetAggregateType() => AggregateType;
        //public TPayload GetPayload() => Payload;
        //public string GetType() => EventType;
        //public DateTime GetTimestamp() => Timestamp;
    }
}
