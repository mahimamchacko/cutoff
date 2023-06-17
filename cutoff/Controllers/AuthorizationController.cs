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

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
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

        return View("Login");
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
        return View("Login", user);
    }
}

