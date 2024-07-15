using Demo.Orders.Domain.Common.Events;
using Demo.Orders.Domain.Entities;
using Demo.Orders.Domain.Events.Orders;
using DNH.Storage.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Interfaces.Repositories
{
    public interface IOutboxRepository : IEFRepository<OutboxMessage>
    {
        Task SaveEventAsync(SagaEvent<Guid, PurchaseOrderSagaEvent> sagaEvent);
    }
}
