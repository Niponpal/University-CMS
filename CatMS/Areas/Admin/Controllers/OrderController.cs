using CatMS.Helper;
using CatMS.Models;
using CatMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace CatMS.Areas.Admin.Controllers;
[Area("Admin")]
public class OrderController : Controller
{

    private readonly IOrderRepository _orderRepository;
    private readonly ISignInHelper _signInHelper;
    public OrderController(IOrderRepository orderRepository, ISignInHelper signInHelper)
    {
        _orderRepository = orderRepository;
        _signInHelper = signInHelper;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _signInHelper.UserId;

        if (userId == null)
            return Unauthorized();

        IEnumerable<Order> orders;

        if (_signInHelper.Roles.Contains("Seller"))
        {
            orders = await _orderRepository.GetAllOrdersAsync(
                userId.Value,
                OrderUserType.Seller);
        }
        else if (_signInHelper.Roles.Contains("Buyer"))
        {
            orders = await _orderRepository.GetAllOrdersAsync(
                userId.Value,
                OrderUserType.Buyer);
        }
        else
        {
            // Admin / SuperAdmin
            orders = await _orderRepository.GetAllOrdersAsync();
        }

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

    [HttpPost]
 
    public async Task<IActionResult> Delete(int id)
    {
        await _orderRepository.DeleteOrderAsync(id);
        return RedirectToAction(nameof(Index));
    }


}
