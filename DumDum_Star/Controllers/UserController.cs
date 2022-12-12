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

        public IActionResult LogIn()
        {
            return View();
        }
    }
}
