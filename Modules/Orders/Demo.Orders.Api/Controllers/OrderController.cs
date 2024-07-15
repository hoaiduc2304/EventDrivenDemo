using Demo.Orders.Application.Features.PurchaseOrders.Interfaces;
using Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Commands;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Plugin.OpenAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Api.Controllers
{
    public class OrderController: BaseApi
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var command = new CreatePurchaseOrderCommand
            {
                CustomerId = request.CustomerId,
                OrderDate = request.OrderDate,
                LineItems = request.LineItems
            };
            await _orderService.CreateOrder(command);
            return Ok();
        }


        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItemToOrder(Guid orderId, [FromBody] AddItemToOrderRequest request)
        {
            var command = new AddItemToOrderCommand
            {
                OrderId = orderId,
                Item = request.Item,
                Quantity = request.Quantity,
                Price = request.Price
            };
            await _orderService.AddItemToOrder(command);
            return Ok();
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
           
            var order = await _orderService.GetOrderById(orderId);
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetPagingPurchaseOrderQuery query)
        {
            var orders = await _orderService.GetPaging(query);
            return Ok(orders);
        }
    }
}
