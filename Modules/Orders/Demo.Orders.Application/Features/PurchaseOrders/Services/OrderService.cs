using Demo.Orders.Application.Features.PurchaseOrders.Interfaces;
using Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Commands;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Queries;
using Demo.Orders.Domain.Entities;
using DNH.Storage.EF.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediator _mediator;

        public OrderService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CreateOrderAsync(CreatePurchaseOrderCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task AddItemToOrderAsync(AddItemToOrderCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(Guid orderId)
        {
            return await _mediator.Send(new GetPurchaseOrderByIdQuery(orderId));
        }

        public async Task<PagedResultDto<OrderDTO>> GetPagingAsync(GetPagingPurchaseOrderQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
