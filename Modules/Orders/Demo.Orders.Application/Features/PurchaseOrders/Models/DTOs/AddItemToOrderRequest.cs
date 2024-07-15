using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs
{
    public class AddItemToOrderRequest
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
