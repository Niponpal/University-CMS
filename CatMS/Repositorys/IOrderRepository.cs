using CatMS.Models;

namespace CatMS.Repositorys;

public interface IOrderRepository
{
    Cat? GetCatById(long catId);
    void AddOrder(Order order);
    void Save();
}
