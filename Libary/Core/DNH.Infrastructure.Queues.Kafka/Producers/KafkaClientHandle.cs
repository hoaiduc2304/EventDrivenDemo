using Ardalis.GuardClauses;
using Confluent.Kafka;
using DNH.Infrastructure.Queues.Kafka.Settings;
using System;

using System.Collections.Generic;
using System.Text;

namespace DNH.Infrastructure.Queues.Kafka.Producers
{
    public class KafkaClientHandle : IDisposable
    {
        IProducer<byte[], byte[]> kafkaProducer;

        public KafkaClientHandle(KafkaSettings kafkaConfiguration)
        {
            Guard.Against.Null(kafkaConfiguration, nameof(kafkaConfiguration));

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = kafkaConfiguration.BootstrapServers,
              //  Debug = kafkaConfiguration.Debug
            };

            this.kafkaProducer = new ProducerBuilder<byte[], byte[]>(producerConfig).Build();
        }

        public Handle Handle { get => this.kafkaProducer.Handle; }

        public void Dispose()
        {
            kafkaProducer.Flush();
            kafkaProducer.Dispose();
        }
    }
}
