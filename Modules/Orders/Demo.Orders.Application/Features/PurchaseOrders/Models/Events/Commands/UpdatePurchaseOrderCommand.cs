using Demo.Orders.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Commands
{
    public class UpdatePurchaseOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<PurchaseOrderLineDto> LineItems { get; set; }
    }
}
