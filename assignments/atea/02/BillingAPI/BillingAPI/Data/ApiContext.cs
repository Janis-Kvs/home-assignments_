using Microsoft.EntityFrameworkCore;
using BillingAPI.Models;

namespace BillingAPI.Data
{
    public class ApiContext :DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
               
        }
    }
}
