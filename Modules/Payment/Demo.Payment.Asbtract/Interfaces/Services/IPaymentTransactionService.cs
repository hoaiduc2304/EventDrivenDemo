using Demo.Payment.Asbtract.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Asbtract.Interfaces.Services
{
    public interface IPaymentTransactionService<T, in ID> : IBaseServices<T,ID> where T : class
    {

    }
}
