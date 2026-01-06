using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatMS.Areas.Admin.Controllers;

public class DashboardController : Controller
{   
    [Area("Admin")]
    [Authorize(Roles = "Administrator,Seller,Buyer")]
    public IActionResult Index()
    {
        return View();
    }
}
