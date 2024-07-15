using Demo.Orders.Application.Common;
using Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs;
using Demo.Orders.Domain.Entities;
using Demo.Orders.Domain.Interfaces.Repositories;
using DNH.Storage.EF.Paging;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Queries
{
    public class GetPurchaseOrderByIdQuery : IRequest<OrderDTO>
    {
        public Guid OrderId { get; set; }

        public GetPurchaseOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }

   
}
