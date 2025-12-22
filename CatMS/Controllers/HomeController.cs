using CatMS.Models;
using CatMS.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatMS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICatRepository _catRepository;


    public HomeController(ILogger<HomeController> logger, ICatRepository catRepository)
    {
        _logger = logger;
        _catRepository = catRepository;
    }

    public async Task<IActionResult> Index()
    {
        List<HomeViewModel> homeViews = new List<HomeViewModel>();
        homeViews = await _catRepository.GetHomeViewModelCat();
        return View(homeViews);

    }

    public async Task<IActionResult> Details(int id)
    {
        var homeView = await _catRepository.GetHomeViewDetals(id);

        if (homeView == null)
            return NotFound();

        return View(homeView);
    }

    


    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult Contact()
    {
        return View();
    }


  



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public override bool Equals(object? obj)
    {
        return obj is HomeController controller &&
               EqualityComparer<ILogger<HomeController>>.Default.Equals(_logger, controller._logger);
    }
               
}
