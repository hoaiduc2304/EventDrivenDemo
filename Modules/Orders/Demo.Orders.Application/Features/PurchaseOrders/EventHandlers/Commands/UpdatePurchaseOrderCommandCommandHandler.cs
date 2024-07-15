//using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Commands;
//using Demo.Orders.Domain;
//using Demo.Orders.Domain.Events.Orders;
//using Demo.Orders.Domain.Interfaces.Repositories;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Demo.Orders.Application.Features.PurchaseOrders.Events.Commands
//{

//    public class UpdatePurchaseOrderCommandCommandHandler : IRequestHandler<UpdatePurchaseOrderCommand>
//    {
//        IPurchaseRepository _purchaseRepository;
//        IOutboxRepository _outboxRepository;
//        public UpdatePurchaseOrderCommandCommandHandler(IPurchaseRepository purchaseRepository, IOutboxRepository outboxRepository)
//        {
//            _purchaseRepository = purchaseRepository;
//            _outboxRepository = outboxRepository;
//        }

//        public async Task Handle(UpdatePurchaseOrderCommand request, CancellationToken cancellationToken)
//        {
//            var order = await _purchaseRepository.TableNoTracking.Where(x => x.id == request.Id).FirstOrDefaultAsync();
//            if (order != null)
//            {
//                order.customerid = request.CustomerId;
//                //update line 
//            }

//            await _purchaseRepository.SaveChangesAsync(order);
//            var orderCreatedEvent = new PurchaseOrderUpdateEvent(order.id, new PurchaseOrderDto()
//            {
//                CustomerId = order.customerid,
//                OrderId = order.id
//            });
//            await _outboxRepository.SaveEventAsync(orderCreatedEvent);
//        }
//    }
//}
