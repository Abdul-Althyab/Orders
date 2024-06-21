using Microsoft.AspNetCore.Mvc;
using OrderViewer.Models;

public class OrdersController : Controller
{
    private readonly OrderDbContext _context;

    public OrdersController(OrderDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(DateTime? filterDate)
    {
        List<Order> orders;

        if (filterDate.HasValue)
        {
            orders = _context.Orders
                             .Where(o => o.OrderDate.Date == filterDate.Value.Date)
                             .ToList();
            ViewData["FilterDate"] = filterDate.Value.ToString("yyyy-MM-dd");
        }
        else
        {
            orders = _context.Orders.ToList();
            ViewData["FilterDate"] = string.Empty;
        }

        return View(orders);
    }
}
