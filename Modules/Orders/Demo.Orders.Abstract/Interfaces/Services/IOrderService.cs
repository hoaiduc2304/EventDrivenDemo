using Demo.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        //Task CreateOrderAsync(CreatePurchaseOrderCommand command);
        //Task UpdateOrderAsync(UpdatePurchaseOrderCommand command);
        Task<PurchaseOrder> GetOrderByIdAsync(Guid orderId);
        Task<List<PurchaseOrder>> GetAllOrdersAsync();
    }
}
