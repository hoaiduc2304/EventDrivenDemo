using Demo.Orders.Domain;
using Demo.Orders.Domain.Common.Events;
using Demo.Orders.Domain.Entities;
using Demo.Orders.Domain.Interfaces.Repositories;
using DNH.Storage.EF;
using DNH.Storage.EF.Services;
using Newtonsoft.Json;


namespace Demo.Orders.Infastructure.Repositories
{
    public class OutboxRepository : EFRepository<OutboxMessage>, IOutboxRepository
    {
        public OutboxRepository(EFDBContext dbContext) : base(dbContext)
        {
        }
        public async Task SaveEventAsync(SagaEvent<Guid, PurchaseOrderDto> sagaEvent)
        {
            var outboxMessage = new OutboxMessage
            {
                id = Guid.NewGuid(),
                AggregateType = sagaEvent.GetAggregateType(),
                AggregateId = Guid.Parse(sagaEvent.GetAggregateId()),
                EventType = sagaEvent.GetType(),
                Payload = JsonConvert.SerializeObject(sagaEvent),
                CreatedAt = DateTime.UtcNow,
                Published = false
            };

            await SaveChangesAsync(outboxMessage);
        }
    }
}
