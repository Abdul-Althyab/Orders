using Microsoft.EntityFrameworkCore;
using OrderViewer.Models;

public class OrderDbContext : DbContext
{
    public OrderDbContext()
    {
    }

    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }
}