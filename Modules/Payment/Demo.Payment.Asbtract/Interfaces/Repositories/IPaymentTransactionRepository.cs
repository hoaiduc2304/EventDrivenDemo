using Demo.Payment.Asbtract.Entities;
using DNH.Storage.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Asbtract.Interfaces.Repositories
{
    public interface IPaymentTransactionRepository : IEFRepository<PaymentTransaction>
    {

    }
}
