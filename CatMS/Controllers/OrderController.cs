using CatMS.Helper;
using CatMS.Models;
using CatMS.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CatMS.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISignInHelper _signInHelper;
        private readonly ICatRepository _catRepository;



        public OrderController(
            IOrderRepository orderRepository,
            ISignInHelper signInHelper,
            ICatRepository catRepository)
        {
            _orderRepository = orderRepository;
            _signInHelper = signInHelper;
            _catRepository = catRepository;
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
        public async Task<IActionResult> ConfirmOrder(Order order)
        {
            order.OrderDate = DateTime.Now;

            _orderRepository.AddOrder(order);
            _orderRepository.Save();
            if(order != null)
            {
               var data = await _catRepository.GetCatByIdAsync((int)order.CatId);
                if(data != null)
                {
                     data.IsPubliced = true;
                     await _catRepository.UpdateCatAsync(data);
                }
            }

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
