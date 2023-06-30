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
    private readonly NetworkService _networkService;
    private readonly GenreService _genreService;
    private readonly LanguageService _languageService;

    public ShowController(DataAccessor dataAccessor, ShowService showService, NetworkService networkService, GenreService genreService, LanguageService languageService)
    {
        _dataAccessor = dataAccessor;
        _showService = showService;
        _networkService = networkService;
        _genreService = genreService;
        _languageService = languageService;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("UserName") != null)
        {
            string userName = HttpContext.Session.GetString("UserName") ?? "";
            var model = new ShowIndexVM(_dataAccessor, _networkService, _genreService, _languageService, userName);
            return View(model);
        }
        return RedirectToAction("Index", "Authorization");
    }

    public IActionResult ShowGrid(int networkId, int genreId, int languageId)
    {
        if (HttpContext.Session.GetString("UserName") != null)
        {
            string userName = HttpContext.Session.GetString("UserName") ?? "";
            var model = new ShowGridVM(_dataAccessor, _showService, userName, networkId, genreId, languageId);
            return PartialView("ShowGridPartial", model);
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

