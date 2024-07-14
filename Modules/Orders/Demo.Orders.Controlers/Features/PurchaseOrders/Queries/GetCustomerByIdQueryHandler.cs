using Demo.Orders.Domain.Entities;
using Demo.Orders.Domain.Interfaces.Repositories;

using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Features.PurchaseOrders.Queries
{

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetPurchaseOrderByIdQuery, PurchaseOrder>
    {
        IPurchaseRepository _purchaseRepository;
        public GetCustomerByIdQueryHandler(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<PurchaseOrder> Handle(GetPurchaseOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _purchaseRepository.TableNoTracking.Where(x => x.id == request.OrderId).FirstOrDefaultAsync();
        }

    }
}