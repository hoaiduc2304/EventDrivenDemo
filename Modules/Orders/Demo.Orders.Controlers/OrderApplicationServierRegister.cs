using Microsoft.Extensions.DependencyInjection;
using Plugin.Abstraction.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Demo.Orders.Application
{
    public static class OrderApplicationServierRegister
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services, IConfiguration config)
        {
            
            return services;
        }
    }
}
