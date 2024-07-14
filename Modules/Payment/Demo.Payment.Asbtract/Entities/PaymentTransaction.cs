using Demo.Payment.Asbtract.Common;
using Demo.Payment.Asbtract.Common.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Asbtract.Entities
{
    public class PaymentTransaction: IEntity<Guid>
    {
        public Guid id { get; set; }

        [Column("orderid")]
        public Guid OrderId { get; set; }

        [Column("customerid")]
        public Guid CustomerId { get; set; }


        [Column("creditcardno")]
        public string? CreditCardNo { get; set; }

        [JsonProperty("paymenttype")]
        [Column(TypeName = "varchar(50)")]
        public PaymentRequestType? PaymentType { get; set; }
        

        public PaymentTransaction() { }

        public PaymentTransaction(Guid orderId, Guid customerId,  string creditCardNo, PaymentRequestType PaymentType)
        {
            OrderId = orderId;
            CustomerId = customerId;
            CreditCardNo = creditCardNo;
            PaymentType = PaymentType;
        }
    }

}
