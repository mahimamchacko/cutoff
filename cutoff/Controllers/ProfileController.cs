using System;
using cutoff.Helpers;
using cutoff.Models;
using Microsoft.AspNetCore.Mvc;

namespace cutoff.Controllers
{
	public class ProfileController : Controller
	{
        private readonly DataAccessor _dataAccessor;

        public ProfileController(DataAccessor dataAccessor)
        {
            _dataAccessor = dataAccessor;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                string userName = HttpContext.Session.GetString("UserName") ?? "";
                UserDTO user = _dataAccessor.GetUsers().Where(u => u.UserName == userName).FirstOrDefault();
                UserVM profile = new UserVM
                {
                    UserEmail = user.UserEmail,
                    UserFirst = user.UserFirst,
                    UserLast = user.UserLast,
                    UserName = user.UserName,
                    UserPassword = user.UserPassword
                };
                return View(profile);
            }
            return RedirectToAction("Index", "Authorization");
        }
    }
}

