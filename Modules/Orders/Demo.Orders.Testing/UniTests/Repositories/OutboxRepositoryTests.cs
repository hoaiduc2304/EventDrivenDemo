using Demo.Orders.Infastructure.Persistence.Repositories;
using DNH.Storage.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Orders.Domain.Events.Orders;
using Demo.Orders.Domain.Common.Events;
using Demo.Orders.Domain.Entities;
using Newtonsoft.Json;
using Azure.Core;
namespace Demo.Orders.Testing.UniTests.Repositories
{
    public class OutboxRepositoryTests
    {
        private OutboxRepository _outboxRepository;
        private DbContextOptions<EFDBContext> _dbContextOptions;
        private EFDBContext _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<EFDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new EFDBContext(_dbContextOptions);
            _outboxRepository = new OutboxRepository(_dbContext);
        }

        [Test]
        public async Task SaveEventAsync_Should_Save_OutboxMessage()
        {
            // Arrange
            Guid orderId = Guid.NewGuid();
            var sagaEvent = new PurchaseOrderCreatedEvent(orderId, new PurchaseOrderSagaEvent()
            {
                OrderId = orderId,
                customerid = Guid.NewGuid(),
                status = "Pending",
                TotalAmount = 100
            });
            var aggregateId = sagaEvent.GetAggregateId().ToString();

            // Act
            await _outboxRepository.SaveEventAsync(sagaEvent);

            // Assert
            var savedMessage = await _dbContext.Set<OutboxMessage>().FirstOrDefaultAsync(m => m.AggregateId == Guid.Parse(aggregateId));
            Assert.IsNotNull(savedMessage);
            Assert.AreEqual(sagaEvent.GetAggregateType(), savedMessage.AggregateType);
            Assert.AreEqual(Guid.Parse(aggregateId), savedMessage.AggregateId);
            Assert.AreEqual(sagaEvent.GetType(), savedMessage.EventType);
            Assert.AreEqual(JsonConvert.SerializeObject(sagaEvent), savedMessage.Payload);
            Assert.IsFalse(savedMessage.Published);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
