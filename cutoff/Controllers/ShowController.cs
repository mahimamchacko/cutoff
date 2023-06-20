using System;
using cutoff.Helpers;
using cutoff.Models;
using cutoff.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

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
            string userName = HttpContext.Session.GetString("UserName") ?? "";
            var model = new ShowGridVM(_dataAccessor, _showService, userName);
            return View(model);
        }
        return RedirectToAction("Index", "Authorization");
    }

    public IActionResult ShowModal(int showId)
    {
        if (HttpContext.Session.GetString("UserName") != null)
        {
            string userName = HttpContext.Session.GetString("UserName") ?? "";
            var model = new ShowModalVM(_dataAccessor, _showService, userName, showId);
            return View("ShowModalPartial", model);
        }
        return RedirectToAction("Index", "Authorization");
    }

    [HttpPost]
    public void ToggleShow(int showId)
    {
        if (HttpContext.Session.GetString("UserName") != null)
        {
            string userName = HttpContext.Session.GetString("UserName") ?? "";
            _showService.ToggleShow(userName, showId);
        }
    }

    [HttpPost]
    public void ToggleShowEpisode(int showId, int seasonNumber, int episodeNumber)
    {
        if (HttpContext.Session.GetString("UserName") != null)
        {
            string userName = HttpContext.Session.GetString("UserName") ?? "";
            _showService.ToggleShowEpisode(userName, showId, seasonNumber, episodeNumber);
        }
    }
}

