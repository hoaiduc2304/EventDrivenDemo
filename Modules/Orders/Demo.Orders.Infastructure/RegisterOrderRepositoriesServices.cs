using Demo.Orders.Domain.Common;
using Demo.Orders.Domain.Interfaces.Repositories;
using Demo.Orders.Infastructure.Persistence.Repositories;
using DNH.Infrastructure.Queues.Kafka.Producers;
using DNH.Infrastructure.Queues.Kafka.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Infastructure
{
    public static class RegisterOrderRepositoriesServices
    {
        public static IServiceCollection AddOrderRepository(this IServiceCollection services, IConfiguration config)
        {
            var kaffka = new KafkaSettings();
            config.Bind(SystemConfigCons.KafkaConfig, kaffka);
            services.AddSingleton(kaffka);
            // register KafkaProducer
            services.AddSingleton<KafkaClientHandle>();
            services.AddSingleton<IKafkaProducer, JsonKafkaProducer>();

            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IOutboxRepository, OutboxRepository>();
            return services;
        }
    }
}
