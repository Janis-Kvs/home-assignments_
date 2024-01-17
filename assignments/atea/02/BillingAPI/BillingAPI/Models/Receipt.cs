namespace BillingAPI.Models
{
    public class Receipt : Entity
    {
        public int OrderId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentGateway { get; set; }

        public Receipt(int orderId, decimal amountPaid, string paymentGateway)
        {
            OrderId = orderId;
            AmountPaid = amountPaid;
            PaymentDate = DateTime.UtcNow;
            PaymentGateway = paymentGateway;
        }
    }
}
