using Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs;
using Demo.Orders.Domain.Entities;
using DNH.Storage.EF.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Queries
{
    public class GetPagingPurchaseOrderQuery : IRequest<PagedResultDto<OrderDTO>>
    {
        public string Filter { get; set; }

        public GetPagingPurchaseOrderQuery(string filter)
        {
            Filter = filter;
        }
    }
}
