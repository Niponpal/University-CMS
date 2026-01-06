using CatMS.Data;
using CatMS.Helper;
using CatMS.Models;
using Microsoft.EntityFrameworkCore;
using static CatMS.Auth_IdentityModel.IdentityModel;

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

    public async Task<IEnumerable<Order>> GetAllOrdersAsync(long? Id, OrderUserType userType)
    {
        var query = _context.Orders
         .Include(o => o.Buyer)
         .Include(o => o.Cat)
         .AsQueryable();

        if (userType == OrderUserType.Buyer)
        {
            query = query.Where(o => o.BuyerId == Id);
        }
        else if (userType == OrderUserType.Seller)
        {
            query = query.Where(o => o.Cat.SellerId == Id);
        }

        return await query
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }
}
