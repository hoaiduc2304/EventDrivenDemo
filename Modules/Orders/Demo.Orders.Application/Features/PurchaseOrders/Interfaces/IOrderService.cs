using Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Commands;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Queries;
using Demo.Orders.Domain.Entities;
using DNH.Storage.EF.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreatePurchaseOrderCommand command);
        Task AddItemToOrderAsync(AddItemToOrderCommand command);
        Task<OrderDTO> GetOrderByIdAsync(Guid OrderId);
        Task<PagedResultDto<OrderDTO>> GetPagingAsync(GetPagingPurchaseOrderQuery query);
    }
}
