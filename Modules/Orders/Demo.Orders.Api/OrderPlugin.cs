using Demo.Orders.Application.Features.PurchaseOrders.OutBox;
using Demo.Orders.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plugin.Abstraction.Plugins;

using DNH.Infrastructure.Queues.Kafka.Settings;

using Demo.Orders.Application;
using Demo.Orders.Domain.Common;
using DNH.Infrastructure.Queues.Kafka.Producers;
using Demo.Orders.Infastructure.Persistence.Repositories;
using Demo.Orders.Infastructure;
namespace Demo.Orders.Api
{
    public  class OrderPlugin : IPlugin
    {
        public string Id => Guid.NewGuid().ToString();
        public string Name => "OrderPlugin";
        public void RegisterDI(IServiceCollection services, IConfiguration config)
        {
            services.AddOrderRepository(config);
            services.AddOrderServices(config);
        }
       
    }
}
