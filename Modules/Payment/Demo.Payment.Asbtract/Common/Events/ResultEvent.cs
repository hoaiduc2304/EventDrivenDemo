using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Demo.Payment.Asbtract.Dtos.Orders.Event;
namespace Demo.Payment.Asbtract.Common.Events
{

    public class EventMessage
    {
        [JsonPropertyName("SagaId")]
        public Guid SagaId { get; set; }

        [JsonPropertyName("AggregateType")]
        public string AggregateType { get; set; }

        [JsonPropertyName("EventType")]
        public string EventType { get; set; }

        [JsonPropertyName("Payload")]
        public Payload Payload { get; set; }

        [JsonPropertyName("Timestamp")]
        public DateTime Timestamp { get; set; }
    }

    public class Payload
    {
        [JsonPropertyName("OrderId")]
        public Guid OrderId { get; set; }

        [JsonPropertyName("CustomerId")]
        public Guid CustomerId { get; set; }
    }

    public class ResultEvent
    {
        public string Value { get; set; }
    }
    public class Saga
    {
        public PurchaseOrderEvent Payload { get; set; }
    }
}
