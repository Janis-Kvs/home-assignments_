using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillingAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingAPI.Interfaces;
using BillingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BillingAPI.Controllers.Tests
{
    [TestClass()]
    public class OrderBillingControllerTests
    {
        private OrderBillingController _controller;
        private Mock<IBillingService> _billingServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            _billingServiceMock = new Mock<IBillingService>();
            _controller = new OrderBillingController(_billingServiceMock.Object);
        }


        [TestMethod]
        public void ProcessOrder_ValidOrder_ReturnsOkWithReceipt()
        {
            // Arrange
            var order = new Order { Id = 5, UserId = 1, PayableAmount = 40, PaymentGateway = "Gateway", Description = "Description" };
            var expectedReceipt = new Receipt(order.Id, order.PayableAmount, order.PaymentGateway);
            _billingServiceMock.Setup(x => x.ProcessOrder(order)).Returns(expectedReceipt);

            // Act
            var result = _controller.ProcessOrder(order) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedReceipt, result.Value);
        }

        [TestMethod]
        public void ProcessOrder_NullReceipt_ReturnsBadRequest()
        {
            // Arrange
            var order = new Order { Id = 5, UserId = 1, PayableAmount = 40, PaymentGateway = "Gateway", Description = "Description" };
            var expectedReceipt = new Receipt(order.Id, order.PayableAmount, order.PaymentGateway);

            _billingServiceMock.Setup(x => x.ProcessOrder(order)).Returns((Receipt)null);

            // Act
            var result = _controller.ProcessOrder(order) as BadRequestResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ProcessOrder_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var order = new Order { Id = 5, UserId = 1, PayableAmount = 40, PaymentGateway = "Gateway", Description = "Description" };
            _billingServiceMock.Setup(x => x.ProcessOrder(order)).Throws(new Exception("Some error"));

            // Act
            var result = _controller.ProcessOrder(order) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
            Assert.AreEqual("Internal Server Error", result.Value);
        }

        [TestMethod]
        public void CreateOrder_NewOrder_ReturnsOkWithCreatedOrder()
        {
            // Arrange
            var order = new Order { Id = 0, UserId = 1, PayableAmount = 40, PaymentGateway = "Gateway", Description = "Description" };
            var expectedCreatedOrder = new Order { Id = 5, UserId = 1, PayableAmount = 40, PaymentGateway = "Gateway", Description = "Description" };
            _billingServiceMock.Setup(x => x.CreateOrder(order)).Returns(expectedCreatedOrder);

            // Act
            var result = _controller.CreateOrder(order) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedCreatedOrder, result.Value);
        }

        [TestMethod]
        public void CreateOrder_ExistingOrder_ReturnsOkWithUpdatedOrder()
        {
            // Arrange
            var order = new Order { Id = 1, UserId = 1, PayableAmount = 40, PaymentGateway = "Gateway", Description = "Description" };
            var expectedUpdatedOrder = new Order { Id = 1, UserId = 1, PayableAmount = 20, PaymentGateway = "Updated Gateway", Description = "Updated Description" };
            _billingServiceMock.Setup(x => x.GetOrder(order.Id)).Returns(order);
            _billingServiceMock.Setup(x => x.UpdateOrder(order, order)).Returns(expectedUpdatedOrder);

            // Act
            var result = _controller.CreateOrder(order) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedUpdatedOrder, result.Value);
        }

        [TestMethod]
        public void CreateOrder_InvalidExistingOrder_ReturnsNotFound()
        {
            // Arrange
            var order = new Order { Id = 1, UserId = 1, PayableAmount = 40, PaymentGateway = "Gateway", Description = "Description" };
            _billingServiceMock.Setup(x => x.GetOrder(order.Id)).Returns((Order)null);

            // Act
            var result = _controller.CreateOrder(order) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void GetOrder_ExistingOrder_ReturnsOkWithOrder()
        {
            // Arrange
            var orderId = 1;
            var expectedOrder = new Order { Id = orderId };
            _billingServiceMock.Setup(x => x.GetOrder(orderId)).Returns(expectedOrder);

            // Act
            var result = _controller.GetOrder(orderId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedOrder, result.Value);
        }

        [TestMethod]
        public void GetOrder_InvalidOrder_ReturnsNotFound()
        {
            // Arrange
            var orderId = 1;
            _billingServiceMock.Setup(x => x.GetOrder(orderId)).Returns((Order)null);

            // Act
            var result = _controller.GetOrder(orderId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void DeleteOrder_ExistingOrder_ReturnsNoContent()
        {
            // Arrange
            var orderId = 1;
            var expectedOrder = new Order { Id = orderId };
            _billingServiceMock.Setup(x => x.GetOrder(orderId)).Returns(expectedOrder);

            // Act
            var result = _controller.DeleteOrder(orderId) as NoContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
            _billingServiceMock.Verify(x => x.DeleteOrder(expectedOrder), Times.Once);
        }

        [TestMethod]
        public void DeleteOrder_InvalidOrder_ReturnsNotFound()
        {
            // Arrange
            var orderId = 1;
            _billingServiceMock.Setup(x => x.GetOrder(orderId)).Returns((Order)null);

            // Act
            var result = _controller.DeleteOrder(orderId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
            _billingServiceMock.Verify(x => x.DeleteOrder(It.IsAny<Order>()), Times.Never);
        }
    }
}