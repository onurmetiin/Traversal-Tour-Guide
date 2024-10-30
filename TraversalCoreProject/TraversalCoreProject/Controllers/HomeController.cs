using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Index sayfası çağrıldı");
        return View();
    }

    public IActionResult Privacy()
    {
        _logger.LogInformation("Privacy sayfası çağrıldı");

        return View();
    }

    public IActionResult Test()
    {
        _logger.LogInformation("Test sayfası çağrıldı");
        _logger.LogError("Test sayfası çağrıldı");
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}