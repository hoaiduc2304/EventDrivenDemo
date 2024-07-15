using Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Queries;
using Demo.Orders.Domain.Entities;
using Demo.Orders.Domain.Interfaces.Repositories;
using DNH.Storage.EF.Extension;
using DNH.Storage.EF.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Orders.Application;
namespace Demo.Orders.Application.Features.PurchaseOrders.Events.Queries
{

    public class GetCustomerByIdQueryHandler :
        IRequestHandler<GetPurchaseOrderByIdQuery, OrderDTO>,
        IRequestHandler<GetPagingPurchaseOrderQuery, PagedResultDto<OrderDTO>>
    {
        IPurchaseRepository _purchaseRepository;
        public GetCustomerByIdQueryHandler(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        

        //Pagging Handler 
        public async Task<PagedResultDto<OrderDTO>> Handle(GetPagingPurchaseOrderQuery req, CancellationToken cancellationToken)
        {
            GetFilterRequest request = new GetFilterRequest();
            if (!string.IsNullOrEmpty(req.Filter) && req.Filter != "{}")
            {
                request = System.Text.Json.JsonSerializer.Deserialize<GetFilterRequest>(req.Filter);
            }
            FilterRequest filterRequest = new FilterRequest(request);
            var result =  await _purchaseRepository.TableNoTracking.GetpagingAysnc(filterRequest);
            return result.ToDto();
        }

        /// <summary>
        /// Get Element By ID 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<OrderDTO> Handle(GetPurchaseOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _purchaseRepository.TableNoTracking.Where(x => x.id == request.OrderId).FirstOrDefaultAsync();
            return entity.ToDto();
        }
    }
}