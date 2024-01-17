using BillingAPI.Data;
using BillingAPI.Interfaces;
using BillingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingAPI.Services
{
    public class BillingService : IBillingService
    {
        private readonly ApiContext _context;

        public BillingService(ApiContext context)
        {
            _context = context;  
        }

        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }
        public Order UpdateOrder(Order dbOrder, Order order)
        {
            dbOrder.UserId = order.UserId;
            dbOrder.PayableAmount = order.PayableAmount;
            dbOrder.PaymentGateway = order.PaymentGateway;
            dbOrder.Description = order.Description;

            _context.Entry(dbOrder).State = EntityState.Modified;
            _context.SaveChanges();
            
            return dbOrder;
        }

        public Order GetOrder(int id)
        {
            Order order = _context.Orders.Find(id);

            return order;
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }


        public Receipt ProcessOrder(Order order)
        {
            //if payment is successful after payment process
            var receipt = new Receipt(order.Id, order.PayableAmount, order.PaymentGateway);

            return receipt;
        }
    }
}
