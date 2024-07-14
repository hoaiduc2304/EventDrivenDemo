using Demo.Payment.Asbtract.Entities;
using Demo.Payment.Asbtract.Interfaces.Services;
using Demo.Payment.Businesses.Services;
using Microsoft.AspNetCore.Mvc;
using Plugin.OpenAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Controllers.Controllers
{
    public class PaymentTransactionController : BaseApi
    {
        IPaymentTransactionService<PaymentTransaction,Guid> _paymentTransactionService;
        public PaymentTransactionController(IPaymentTransactionService<PaymentTransaction, Guid> paymentTransactionService) 
        {
            _paymentTransactionService = paymentTransactionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _paymentTransactionService.getbyIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
