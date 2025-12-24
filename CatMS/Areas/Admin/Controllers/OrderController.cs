using CatMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace CatMS.Areas.Admin.Controllers;
[Area("Admin")]
public class OrderController : Controller
{

    private readonly IOrderRepository _orderRepository;
    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _orderRepository.GetAllOrdersAsync();
        return View(orders);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderRepository.GetOrderDetailsAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

}
