using Azure.Core;
using Demo.Payment.Asbtract.Entities;
using Demo.Payment.Asbtract.Interfaces.Repositories;
using Demo.Payment.Asbtract.Interfaces.Services;
using DNH.Storage.EF.Extension;
using DNH.Storage.EF.Paging;
using DNH.Storage.EF.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Businesses.Services
{
    public class PaymentTransactionServices : IPaymentTransactionService<PaymentTransaction, Guid>
    {
        private IPaymentTransactionRepository _paymentTransactionRepository;
        public PaymentTransactionServices(IPaymentTransactionRepository paymentTransactionRepository) 
        {
            _paymentTransactionRepository = paymentTransactionRepository;
        }
        public async Task<PaymentTransaction> getbyIdAsync(Guid id)
        {
            return await _paymentTransactionRepository.TableNoTracking.Where(x=>x.id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedResultDto<PaymentTransaction>> PagingAsync(string filter = "")
        {
            GetFilterRequest request = new GetFilterRequest();
            if (!string.IsNullOrEmpty(filter) && filter != "{}")
            {
                request = System.Text.Json.JsonSerializer.Deserialize<GetFilterRequest>(filter);
            }
            FilterRequest filterRequest = new FilterRequest(request);
            return await _paymentTransactionRepository.TableNoTracking.GetpagingAysnc(filterRequest);
        }

        public async Task<PaymentTransaction> SaveChangeAsync(PaymentTransaction entity)
        {
            entity.id = Guid.NewGuid();
            entity = await _paymentTransactionRepository.SaveChangesAsync(entity);
            return entity;
        }
    }
}
