using CatMS.Data;
using CatMS.Helper;
using CatMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatMS.Controllers;

public class OrderController(ApplicationDbContext _context, ISignInHelper signInHelper) : Controller
{
    public IActionResult PlaceOrder(int catId)
    {
        //if (!User.Identity.IsAuthenticated)
        //{
        //    return RedirectToAction("Login", "Account", new
        //    {
        //        ReturnUrl = Url.Action("PlaceOrder", "Order", new { catId})
        //    });
        //}
        //else
        //{
            var cat = _context.Cats.Find(catId);
            if (cat == null) return NotFound();
        var order = new Order
        {
            CatId = cat.Id,
            TotalAmount = cat.Price,
            OrderDate = DateTime.Now,
            BuyerId = (int)(signInHelper.UserId ?? 1)
        };
            return View(order);
       
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmOrder(Order order)
    {
       

        order.OrderDate = DateTime.Now;

        _context.Orders.Add(order);
        _context.SaveChanges();

        return RedirectToAction("Success");
    }

    public IActionResult Success()
    {
        return View();
    }

}
