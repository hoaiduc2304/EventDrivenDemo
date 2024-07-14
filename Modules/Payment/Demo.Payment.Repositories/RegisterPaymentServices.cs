using Demo.Payment.Asbtract.Interfaces.Repositories;
using Demo.Payment.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Repositories
{
    public static class RegisterPaymentServices
    {
        public static IServiceCollection RegisterPaymentRepository(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepo>();
            return services;
        }
    }
}
