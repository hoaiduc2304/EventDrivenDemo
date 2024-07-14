using Demo.Orders.Application.Features.PurchaseOrders.Commands.AddEdit;
using Demo.Orders.Application.Features.PurchaseOrders.Queries;
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
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _mediator.Send(new GetPurchaseOrderByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreatePurchaseOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdatePurchaseOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
