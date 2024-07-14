using Demo.Payment.Asbtract.Interfaces.Repositories;
using Demo.Payment.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Payment.Asbtract.Interfaces.Services;
using Demo.Payment.Businesses.Services;
using Demo.Payment.Asbtract.Entities;
using Demo.Payment.Businesses.Queues.Consumers;

namespace Demo.Payment.Businesses
{
    public static class RegisterPaymentBusinessServices
    {
        public static IServiceCollection RegisterPaymentServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPaymentTransactionService<PaymentTransaction,Guid>, PaymentTransactionServices>();
            services.AddHostedService<OrderConsumerService>();
            return services;
        }
    }
}
