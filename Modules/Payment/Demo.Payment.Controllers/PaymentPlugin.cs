using Microsoft.Extensions.DependencyInjection;
using Plugin.Abstraction.Plugins;
using Microsoft.Extensions.Configuration;
using Demo.Payment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Payment.Businesses;

namespace Demo.Payment.Controllers
{
    public class PaymentPlugin : IPlugin
    {
        public string Id => Guid.NewGuid().ToString();
        public string Name => "PaymentPlugin";
        public void RegisterDI(IServiceCollection services, IConfiguration config)
        {
            services.RegisterPaymentRepository(config);
            services.RegisterPaymentServices(config);
        }
    }
}
