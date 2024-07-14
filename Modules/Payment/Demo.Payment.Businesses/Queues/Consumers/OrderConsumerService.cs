using DNH.Infrastructure.Queues.Kafka.Settings;
using Microsoft.Extensions.Hosting;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Demo.Payment.Asbtract.Interfaces.Services;
using Demo.Payment.Asbtract.Entities;
using System.Text.Json;
using Demo.Payment.Asbtract.Dtos.Orders.Event;
using Demo.Payment.Asbtract.Common.Events;
using Newtonsoft.Json;

namespace Demo.Payment.Businesses.Queues.Consumers
{
    public class OrderConsumerService : IHostedService
    {
        KafkaSettings _kafkaSettings;
        private readonly IConsumer<string, string> _consumer;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _consumeTask;
        IServiceScopeFactory _scopeFactory;
        public OrderConsumerService(IServiceScopeFactory scopeFactory, KafkaSettings kafkaSettings)
        {
            _kafkaSettings = kafkaSettings;
            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaSettings.BootstrapServers,
                GroupId = _kafkaSettings.ConsumerConfig.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _scopeFactory = scopeFactory;
            _consumer = new ConsumerBuilder<string, string>(config).Build();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _consumeTask = Task.Run(() => ConsumeMessages(_cancellationTokenSource.Token), _cancellationTokenSource.Token);
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            try
            {
                await _consumeTask;
            }
            catch (OperationCanceledException)
            {
                // Expected exception when task is cancelled
            }
            _consumer.Close();
        }
        private async Task ConsumeMessages(CancellationToken cancellationToken)
        {
            _consumer.Subscribe(_kafkaSettings.TopicName);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    using var scope = _scopeFactory.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<IPaymentTransactionService<PaymentTransaction, Guid>>();
                    var consumeResult = _consumer.Consume(cancellationToken);
                    if (consumeResult != null)
                    {
                        var message = consumeResult.Message.Value;
                       
                        var result = JsonConvert.DeserializeObject<SagaEvent<Guid, PurchaseOrderEvent>>(message);
                        if (result != null)
                        {
                            try
                            {
                                await context.SaveChangeAsync(new PaymentTransaction()
                                {
                                    OrderId = result.Payload.OrderId,
                                    CustomerId = result.Payload.CustomerId,
                                    id = Guid.NewGuid(),
                                });
                            }
                            catch (Exception ex)
                            {
                                string error = ex.Message;
                            }

                        }

                    }
                    Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'.");

                    _consumer.Commit(consumeResult);
                }
            }
            catch (OperationCanceledException exd)
            {
                // Expected exception when task is cancelled
                Console.WriteLine($"Exception: {exd.Message}");
            }
            catch (Exception ex)
            {
                // Log other exceptions
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                _consumer.Close();
            }
        }
    }
}
