using Demo.Payment.Asbtract.Entities;
using Demo.Payment.Asbtract.Interfaces.Repositories;
using DNH.Storage.EF;
using DNH.Storage.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Repositories.Repositories
{
    public class PaymentTransactionRepo :EFRepository<PaymentTransaction>, IPaymentTransactionRepository
    {
        public PaymentTransactionRepo(EFDBContext dbContext) : base(dbContext)
        {

        }
    }
}
