using System;
using cutoff.Helpers;
using cutoff.Models;
using cutoff.Services;
using Microsoft.AspNetCore.Mvc;

namespace cutoff.Controllers;

public class ShowController : Controller
{
    private readonly ILogger<ShowController> _logger;
    private readonly DataAccessor _dataAccessor;
    private readonly ShowService _showService;

    public ShowController(ILogger<ShowController> logger, DataAccessor dataAccessor, ShowService showService)
    {
        _logger = logger;
        _dataAccessor = dataAccessor;
        _showService = showService;
    }

    public IActionResult Index()
    {
        var model = new ShowVM(_dataAccessor, _showService);
        return View(model);
    }
}

