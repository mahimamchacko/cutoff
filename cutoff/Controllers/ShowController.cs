using System;
using cutoff.Helpers;
using cutoff.Models;
using cutoff.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cutoff.Controllers;

public class ShowController : Controller
{
    private readonly DataAccessor _dataAccessor;
    private readonly ShowService _showService;

    public ShowController(DataAccessor dataAccessor, ShowService showService)
    {
        _dataAccessor = dataAccessor;
        _showService = showService;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("UserName") != null)
        {
            var model = new ShowGridVM(_dataAccessor, _showService);
            return View(model);
        }
        return RedirectToAction("Index", "Authorization");
    }

    public IActionResult ShowModal(int showId)
    {
        var model = new ShowMovalVM(_dataAccessor, _showService, showId);
        return View("ShowModalPartial", model);
    } 
}

