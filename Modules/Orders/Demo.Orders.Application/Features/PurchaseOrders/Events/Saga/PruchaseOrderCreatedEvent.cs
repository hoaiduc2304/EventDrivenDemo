using Castle.Core.Resource;
using Demo.Orders.Domain.Common;
using Demo.Orders.Domain.Common.Events;
using Demo.Orders.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Events.Orders
{
    public class PurchaseOrderCreatedEvent: SagaEvent<Guid, PurchaseOrderSagaEvent>
    {
        public PurchaseOrderCreatedEvent(Guid sagaId, PurchaseOrderSagaEvent payload)
            : base(sagaId, "order", "OrderCreated", payload)
        {
        }
    }
}
