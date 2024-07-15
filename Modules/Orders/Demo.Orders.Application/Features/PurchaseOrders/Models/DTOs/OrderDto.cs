using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
