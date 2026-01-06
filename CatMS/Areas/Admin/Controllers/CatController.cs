using CatMS.Helper;
using CatMS.Models;
using CatMS.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatMS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator,Seller")]
public class CatController : Controller
{
    private readonly ICatRepository _catRepository;
   private readonly ISignInHelper _signInHelper;


    public CatController(ICatRepository catRepository, ISignInHelper signInHelper)
    {
        _catRepository = catRepository;
        _signInHelper = signInHelper;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _signInHelper.UserId;

        if (userId != null && _signInHelper.Roles.Contains("Seller"))
        {
            var sellerCats = await _catRepository.GetAllCatsAsync(userId.Value);
            return View(sellerCats);
        }

        var cats = await _catRepository.GetAllCatsAsync();
        return View(cats);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id)
    {
        if (id == 0)
        {
            return View(new Cat());
        }
        
        var data = await _catRepository.GetCatByIdAsync(id);
        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Cat cat)
    {
         cat.SellerId = _signInHelper.UserId ?? 0;
        if (cat.Id == 0)
        {
            await _catRepository.AddCatAsync(cat);
            return RedirectToAction("Index");
        }
        else
        {
            await _catRepository.UpdateCatAsync(cat);
            return RedirectToAction("Index");
        }
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var data = await _catRepository.GetCatByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _catRepository.DeleteCatAsync(id);

        if (data == null)
        {
            return NotFound();
        }
        return RedirectToAction("Index");
    }
}
