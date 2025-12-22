using CatMS.Helper;
using CatMS.Models;
using CatMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace CatMS.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISignInHelper _signInHelper;

        public OrderController(
            IOrderRepository orderRepository,
            ISignInHelper signInHelper)
        {
            _orderRepository = orderRepository;
            _signInHelper = signInHelper;
        }

        public IActionResult PlaceOrder(int catId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new
                {
                    ReturnUrl = Url.Action("PlaceOrder", "Order", new { catId })
                });
            }

            var cat = _orderRepository.GetCatById(catId);
            if (cat == null) return NotFound();

            var order = new Order
            {
                CatId = cat.Id,
                TotalAmount = cat.Price,
                OrderDate = DateTime.Now,
                BuyerId = (int)(_signInHelper.UserId ?? 1)
            };

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmOrder(Order order)
        {
            order.OrderDate = DateTime.Now;

            _orderRepository.AddOrder(order);
            _orderRepository.Save();

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
