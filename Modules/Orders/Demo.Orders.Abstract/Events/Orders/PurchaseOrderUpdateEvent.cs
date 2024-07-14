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
    public class PurchaseOrderUpdateEvent : SagaEvent<Guid, PurchaseOrderDto>
    {
        public PurchaseOrderUpdateEvent(Guid sagaId, PurchaseOrderDto payload)
           : base(sagaId, "order", "OrderUpdate", payload)
        {
        }
    }
}
