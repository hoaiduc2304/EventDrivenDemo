using System;
using System.Collections.Generic;
using System.Text;

namespace DNH.Infrastructure.Queues.Kafka.Settings
{
    public class KafkaSettings
    {
        public string BootstrapServers { get; set; }
        public string TopicName { get; set; }
        public ProducerConfigSettings ProducerConfig { get; set; }
        public ConsumerConfigSettings ConsumerConfig { get; set; }
    }

    public class ProducerConfigSettings
    {
        public string Acks { get; set; }
        public bool EnableIdempotence { get; set; }
        public int MessageTimeoutMs { get; set; }
        public int RetryBackoffMs { get; set; }
        public int ReconnectBackoffMs { get; set; }
    }

    public class ConsumerConfigSettings
    {
        public string GroupId { get; set; }
        public string AutoOffsetReset { get; set; }
        public bool EnableAutoCommit { get; set; }
    }
}
