using CatMS.Models;

namespace CatMS.Repositorys;

public interface IOrderRepository
{
    Cat? GetCatById(long catId);
    void AddOrder(Order order);
    void Save();

    Task<Order?> GetOrderDetailsAsync(long id);
    Task<IEnumerable<Order>> GetAllOrdersAsync();

}
