using CatMS.Data;
using CatMS.Models;

namespace CatMS.Repositorys;

public class OrderRepository:IOrderRepository
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
}
