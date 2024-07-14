using Demo.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain
{
    public class PurchaseOrderDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
     
    }
}
