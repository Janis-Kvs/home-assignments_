using BillingAPI.Models;

namespace BillingAPI.Interfaces
{
    public interface IBillingService
    {
        Order CreateOrder(Order order);
        Order GetOrder(int id);
        Order UpdateOrder(Order dbOrder, Order order);
        void DeleteOrder(Order order);
        Receipt ProcessOrder(Order order);
    }
}
