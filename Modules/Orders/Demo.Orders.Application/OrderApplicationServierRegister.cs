using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Demo.Orders.Application.Features.PurchaseOrders.OutBox;

using Demo.Orders.Application.Features.PurchaseOrders.Services;
using Demo.Orders.Application.Features.PurchaseOrders.Interfaces;

namespace Demo.Orders.Application
{
    public static class OrderApplicationServierRegister
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(OrderApplicationServierRegister)));
            services.AddScoped<IOrderService, OrderService>();
            services.AddHostedService<OutboxProcessor>();
            return services;
        }
    }
}
