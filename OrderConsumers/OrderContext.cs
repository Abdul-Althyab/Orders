using System.Data.Entity;

namespace OrderConsumers
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=OrderDb")
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
