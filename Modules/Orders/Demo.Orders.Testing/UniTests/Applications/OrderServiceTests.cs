using Demo.Orders.Application.Features.PurchaseOrders.Interfaces;
using Demo.Orders.Application.Features.PurchaseOrders.Models.DTOs;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Commands;
using Demo.Orders.Application.Features.PurchaseOrders.Models.Events.Queries;
using Demo.Orders.Application.Features.PurchaseOrders.Services;
using Demo.Orders.Domain;
using DNH.Storage.EF.Paging;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Testing.UniTests.Applications
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IMediator> _mediatorMock;
        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _orderService = new OrderService(_mediatorMock.Object);
        }

        [Test]
        public async Task CreateOrder_Should_Send_Command()
        {
            // Arrange
            var command = new CreatePurchaseOrderCommand { CustomerId = Guid.NewGuid(), OrderDate = DateTime.UtcNow, LineItems = new List<PurchaseOrderLineDto>() };

            // Act
            await _orderService.CreateOrder(command);

            // Assert
            _mediatorMock.Verify(m => m.Send(command, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task AddItemToOrder_Should_Send_Command()
        {
            // Arrange
            var command = new AddItemToOrderCommand { OrderId = Guid.NewGuid(), Item = "Item 1", Quantity = 1, Price = 100 };

            // Act
            await _orderService.AddItemToOrder(command);

            // Assert
            _mediatorMock.Verify(m => m.Send(command, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task GetOrderById_Should_Return_OrderDTO()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var orderDto = new OrderDTO { OrderId = orderId, CustomerId = Guid.NewGuid(), OrderDate = DateTime.UtcNow, Items = new List<OrderItemDTO>(), Status = "Pending", TotalAmount = 100 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPurchaseOrderByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(orderDto);

            // Act
            var result = await _orderService.GetOrderById(orderId);

            // Assert
            Assert.AreEqual(orderId, result.OrderId);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetPurchaseOrderByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task GetPaging_Should_Return_PagedResultDto_Of_OrderDTO()
        {
            // Arrange
            var query = new GetPagingPurchaseOrderQuery("");
            var pagedResult = new PagedResultDto<OrderDTO>(10, new List<OrderDTO> { new OrderDTO { OrderId = Guid.NewGuid(), CustomerId = Guid.NewGuid(), OrderDate = DateTime.UtcNow, Items = new List<OrderItemDTO>(), Status = "Pending", TotalAmount = 100 } });
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPagingPurchaseOrderQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(pagedResult);

            // Act
            var result = await _orderService.GetPaging(query);

            // Assert
            Assert.AreEqual(10, result.TotalCount);
            Assert.IsNotEmpty(result.Items);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetPagingPurchaseOrderQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
