using CatMS.Data;
using CatMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CatMS.Repositorys;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Cat? GetCatById(long catId)
    {
        return _context.Cats.Find(catId);
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
    public async Task<Order?> GetOrderDetailsAsync(long id)
    {
        return await _context.Orders
            .Include(o => o.Buyer)
            .Include(o => o.Cat)
            .FirstOrDefaultAsync(o => o.Id == id);

    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.Buyer)
            .Include(o => o.Cat)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task DeleteOrderAsync(long id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
