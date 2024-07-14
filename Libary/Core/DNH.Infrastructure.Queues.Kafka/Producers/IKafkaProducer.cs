using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNH.Infrastructure.Queues.Kafka.Producers
{
    public interface IKafkaProducer
    {
        void SendBulkJson<T>(string targetTopic, IEnumerable<T> messages, string key, Dictionary<string, string> headers);
        Task SendJsonAsync(string targetTopic, object message, string messageKey, Dictionary<string, string> headers);
        Task SendStringAsync(string targetTopic, string message, string messageKey, Dictionary<string, string> headers);
    }
}

