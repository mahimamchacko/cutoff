using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cutoff.Models;
using cutoff.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace cutoff.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataAccessor _dataAccessor;

    public HomeController(ILogger<HomeController> logger, DataAccessor dataAccessor)
    {
        _logger = logger;
        _dataAccessor = dataAccessor;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("UserName") != null)
            return View();
        return RedirectToAction("Index", "Authorization");
    }

    public IActionResult Privacy()
    {
        if (HttpContext.Session.GetString("UserName") != null)
            return View();
        return RedirectToAction("Index", "Authorization");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

