using Demo.Orders.Domain.Common.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Demo.Orders.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using DNH.Infrastructure.Queues.Kafka.Producers;
using DNH.Infrastructure.Queues.Kafka.Settings;
using Newtonsoft.Json;
using Demo.Orders.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Demo.Orders.Domain;

namespace Demo.Orders.Application.Features.PurchaseOrders.OutBox
{
    public class OutboxProcessor : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
       // private readonly IProducer<string, string> _producer;
        private const int DelayBetweenChecksInMilliseconds = 5000;
        private const int BatchSize = 10;
        KafkaSettings _kafkaSettings;
        IKafkaProducer _producer;
        public OutboxProcessor(IServiceScopeFactory scopeFactory, IKafkaProducer producer, 
            KafkaSettings kafkaSettings)
        {
            _scopeFactory = scopeFactory;
            _producer = producer;
            _kafkaSettings = kafkaSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<IOutboxRepository>();

                var messages = await context.Table.Where(x => !x.Published).Take(BatchSize).ToListAsync();

                foreach (var message in messages)
                {
                    try
                    {
                       // var order = JsonConvert.DeserializeObject<SagaEvent<Guid, PurchaseOrderDto>>(message.Payload)  ;
                        await _producer.SendStringAsync(_kafkaSettings.TopicName, message.Payload, message.id.ToString(), null);

                        message.Published = true;
                        await context.SaveChangesAsync(message);
                    }
                    catch (Exception ex)
                    {
                        string dss = ex.Message;
                    }
                  
                }

                //    await context.SaveChangesAsync(stoppingToken);

                await Task.Delay(DelayBetweenChecksInMilliseconds, stoppingToken);
            }
        }
       
    }
}
