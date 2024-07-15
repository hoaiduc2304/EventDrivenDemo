using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Events.Orders
{
    public class PurchaseOrderSagaEvent
    {
        public Guid OrderId { get; set; }
        public Guid customerid { get; set; }
        public string status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
