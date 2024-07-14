using Demo.Orders.Application.Common;

using Demo.Orders.Domain.Entities;
using Demo.Orders.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Queries
{
    public class GetPurchaseOrderByIdQuery : IRequest<PurchaseOrder>
    {
        public Guid OrderId { get; set; }

        public GetPurchaseOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
   
}
