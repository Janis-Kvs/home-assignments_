namespace BillingAPI.Models
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public decimal PayableAmount { get; set; }
        public string? PaymentGateway { get; set; }
        public string? Description { get; set; }
    }
}
