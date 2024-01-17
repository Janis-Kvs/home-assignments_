using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillingAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows.Input;
using BillingAPI.Interfaces;
using BillingAPI.Data;
using BillingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingAPI.Services.Tests
{
    [TestClass()]
    public class BillingServiceTests
    {
        private DbContextOptions<ApiContext> _options;

        [TestInitialize]
        public void Initialize()
        {
            _options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "BillingDb")
                .Options;
        }

        [TestMethod()]
        public void CreateOrderTest_ValidOrderInput_ValidOrderPropertiesExpected()
        {
            using (var context = new ApiContext(_options))
            {
                // Arrange
                var billingService = new BillingService(context);

                var order = new Order
                {
                    UserId = 1,
                    PayableAmount = 50.0m,
                    PaymentGateway = "Gateway",
                    Description = "Description",
                };

                // Act
                var createdOrder = billingService.CreateOrder(order);
                var savedOrder = context.Orders.FirstOrDefault();

                // Assert
                Assert.IsNotNull(createdOrder);
                Assert.AreEqual(order.UserId, createdOrder.UserId);
                Assert.AreEqual(order.PayableAmount, createdOrder.PayableAmount);
                Assert.AreEqual(order.PaymentGateway, createdOrder.PaymentGateway);
                Assert.AreEqual(order.Description, createdOrder.Description);

                Assert.IsNotNull(savedOrder);
                Assert.AreEqual(order.UserId, savedOrder.UserId);
                Assert.AreEqual(order.PayableAmount, savedOrder.PayableAmount);
                Assert.AreEqual(order.PaymentGateway, savedOrder.PaymentGateway);
                Assert.AreEqual(order.Description, savedOrder.Description);
            }
        }

        [TestMethod()]
        public void UpdateOrderTest_ValidInput_UpdatesOrderInDatabaseExpected()
        {
            using (var context = new ApiContext(_options))
            {
                // Arrange
                var order = new Order { Id = 2, UserId = 1, PayableAmount = 12, PaymentGateway = "Gateway", Description = "Description" };
                context.Orders.Add(order);
                context.SaveChanges();

                var billingService = new BillingService(context);

                var updatedOrder = new Order { Id = 2, UserId = 2, PayableAmount = 150, PaymentGateway = "Updated Gateway", Description = "Updated Description" };

                // Act
                var result = billingService.UpdateOrder(order, updatedOrder);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(updatedOrder.Id, result.Id);
                Assert.AreEqual(updatedOrder.UserId, result.UserId);
                Assert.AreEqual(updatedOrder.PayableAmount, result.PayableAmount);
                Assert.AreEqual(updatedOrder.PaymentGateway, result.PaymentGateway);
                Assert.AreEqual(updatedOrder.Description, result.Description);

                var dbOrder = context.Orders.Find(result.Id);
                Assert.IsNotNull(dbOrder);
                Assert.AreEqual(updatedOrder.UserId, dbOrder.UserId);
                Assert.AreEqual(updatedOrder.PayableAmount, dbOrder.PayableAmount);
                Assert.AreEqual(updatedOrder.PaymentGateway, dbOrder.PaymentGateway);
                Assert.AreEqual(updatedOrder.Description, dbOrder.Description);
            }
        }

        [TestMethod()]
        public void GetOrderTest_GetOrderWithId3FromDataBaseExpected()
        {
            using (var context = new ApiContext(_options))
            {
                // Arrange
                var order = new Order { Id = 3, UserId = 1, PayableAmount = 20, PaymentGateway = "Gateway", Description = "Description" };
                context.Orders.Add(order);
                context.SaveChanges();

                var billingService = new BillingService(context);

                // Act
                var result = billingService.GetOrder(3);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(order.Id, result.Id);
                Assert.AreEqual(order.UserId, result.UserId);
                Assert.AreEqual(order.PayableAmount, result.PayableAmount);
                Assert.AreEqual(order.PaymentGateway, result.PaymentGateway);
                Assert.AreEqual(order.Description, result.Description);
            }
        }

        [TestMethod()]
        public void DeleteOrderTest_NullInDataBaseExcepted()
        {
            using (var context = new ApiContext(_options))
            {
                // Arrange
                var order = new Order { Id = 4, UserId = 1, PayableAmount = 30, PaymentGateway = "Gateway", Description = "Description" };
                context.Orders.Add(order);
                context.SaveChanges();

                var billingService = new BillingService(context);

                // Act
                billingService.DeleteOrder(order);

                // Assert
                var deletedOrder = context.Orders.Find(4);

                Assert.IsNull(deletedOrder);
            }
        }

        [TestMethod()]
        public void ProcessOrderTest()
        {
            using (var context = new ApiContext(_options))
            {
                // Arrange
                var order = new Order { Id = 5, UserId = 1, PayableAmount = 40, PaymentGateway = "Gateway", Description = "Description" };
                context.Orders.Add(order);
                context.SaveChanges();

                var billingService = new BillingService(context);

                // Act
                Receipt receipt = billingService.ProcessOrder(order);

                // Assert
                Assert.IsNotNull(receipt); 
                Assert.AreEqual(order.Id, receipt.OrderId); 
                Assert.AreEqual(order.PayableAmount, receipt.AmountPaid); 
                Assert.AreEqual(order.PaymentGateway, receipt.PaymentGateway);
            }
        }
    }
}