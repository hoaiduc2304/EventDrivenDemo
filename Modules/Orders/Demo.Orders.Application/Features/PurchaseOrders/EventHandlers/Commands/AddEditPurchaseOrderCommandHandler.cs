
using Demo.Orders.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Demo.Orders.Domain.Events.Orders;
using Newtonsoft.Json.Linq;
using Demo.Orders.Domain.Interfaces.Repositories;

using Demo.Orders.Domain.Common.Events;
using Demo.Orders.Domain;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Commands;
namespace Demo.Orders.Application.Features.PurchaseOrders.Events.Commands
{

    public class AddEditPurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand>
    {
        IPurchaseRepository _purchaseRepository;
        IOutboxRepository _outboxRepository;
        public AddEditPurchaseOrderCommandHandler(IPurchaseRepository purchaseRepository, IOutboxRepository outboxRepository)
        {
            _purchaseRepository = purchaseRepository;
            _outboxRepository = outboxRepository;
        }
        public async Task Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Guid orderId = Guid.NewGuid();
                var order = new PurchaseOrder
                {
                    id = orderId,
                    customerid = request.CustomerId,
                    orderdate = request.OrderDate,
                    status = "Create",
                    LineItems = request.LineItems.Select(li => new PurchaseOrderLine
                    {
                        id = Guid.NewGuid(),
                        //PurchaseOrderid = orderId,
                        item = li.Item,
                        quantity = li.Quantity,
                        totalprice = li.TotalPrice
                    }).ToList()
                };
                await _purchaseRepository.SaveChangesAsync(order);
                var orderCreatedEvent = new PurchaseOrderCreatedEvent(order.id, new PurchaseOrderSagaEvent()
                {
                    OrderId = orderId,
                    customerid = request.CustomerId,
                    status = order.status,
                    TotalAmount = order.GetTotalAmount()
                });

                await _outboxRepository.SaveEventAsync(orderCreatedEvent);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }



        }


    }
}
