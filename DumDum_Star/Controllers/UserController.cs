using DumDum_Star.Models;
using DumDum_Star.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DumDum_Star.Controllers
{
    public class UserController : Controller
    {
        public DDSDataContext Context { get; private set; }

        public UserController(DDSDataContext context)
        {
            Context = context;
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult LogIn(string login, string password)
        {
            var user = TryToGetUserByCredentials(login, password);

            if (user != null)
            {
                SessionData.CurrentChoom = user;
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                return View("Authorization");
            }
                
        }

        public IActionResult LogOut() 
        {
            return RedirectToAction("Index", "Home", null);
        }

        [NonAction]
        private Choom? TryToGetUserByCredentials(string login, string password)
        {
            Choom? auth = Context.Chooms.Where(choom => choom.Login == login &&
                                                       choom.Password == password)
                                        .FirstOrDefault();

            return auth;
        }

    }
}
