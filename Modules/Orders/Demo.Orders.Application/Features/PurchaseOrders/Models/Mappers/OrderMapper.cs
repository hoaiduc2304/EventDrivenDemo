using Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs;
using Demo.Orders.Domain.Entities;
using DNH.Storage.EF.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application
{
    public static class OrderMapper
    {
        public static OrderDTO ToDto(this PurchaseOrder order)
        {
            return new OrderDTO
            {
                OrderId = order.id,
                Items = order.LineItems.Select(item => new OrderItemDTO
                {
                    Item = item.item,
                    Quantity = item.quantity,
                    TotalPrice = item.totalprice
                }).ToList(),
                // Status = order.Status.ToString(),
                TotalAmount = order.GetTotalAmount()
            };
        }
        public static PagedResultDto<OrderDTO> ToDto(this PagedResultDto<PurchaseOrder> pagedResult)
        {
            return new PagedResultDto<OrderDTO>
            {
                TotalCount = pagedResult.TotalCount,
                Message = pagedResult.Message,
                Items = pagedResult.Items.Select(order => order.ToDto()).ToList()
            };
        }
    }
}
