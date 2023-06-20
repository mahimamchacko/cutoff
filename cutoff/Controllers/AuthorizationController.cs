using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using cutoff.Models;
using cutoff.Helpers;

namespace cutoff.Controllers;

public class AuthorizationController : Controller
{
    private readonly DataAccessor _dataAccessor;

    public AuthorizationController(DataAccessor dataAccessor)
    {
        _dataAccessor = dataAccessor;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("UserName") != null)
            return RedirectToAction("Index", "Home");
        return View();
    }

    public IActionResult Register()
    {
        if (HttpContext.Session.GetString("UserName") != null)
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpGet]
    public bool CheckUserName(string userName)
    {
        return _dataAccessor.GetUsers().Where(u => u.UserName == userName).Count() == 0;
    }

    [HttpGet]
    public bool CheckUserEmail(string userEmail)
    {
        return _dataAccessor.GetUsers().Where(u => u.UserEmail == userEmail).Count() == 0;
    }

    [HttpPost]
    public IActionResult RegisterUser(UserRegisterVM user)
    {
        var userDTO = new UserDTO
        {
            UserEmail = user.UserEmail,
            UserFirst = user.UserFirst,
            UserLast = user.UserLast,
            UserName = user.UserName,
            UserPassword = user.UserPassword
        };

        _dataAccessor.RegisterUser(userDTO);

        return View("Index");
    }

    [HttpPost]
    public IActionResult LoginUser(UserLoginVM user)
    {
        var correctUser = _dataAccessor.GetUsers().Where(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);
        if (correctUser.Count() > 0)
        {
            HttpContext.Session.SetString("UserName", user.UserName);
            return RedirectToAction("Index", "Home");
        }
        return View("Index", user);
    }

    [HttpPost]
    public IActionResult LogoutUser(UserLoginVM user)
    {
        HttpContext.Session.Remove("UserName");
        return View("Index", user);
    }
}

