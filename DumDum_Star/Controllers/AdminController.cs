using DumDum_Star.Models;
using DumDum_Star.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DumDum_Star.Controllers
{
    public class AdminController : Controller
    {
        public DDSDataContext Context { get; private set; }

        public AdminController(DDSDataContext context) 
        {
            Context = context;
        }

        public IActionResult Overview()
        {
            var choomId = SessionData.CurrentChoom?.Id ?? -1;

            if (Context.Admins.Any(admin => admin.Id == choomId))
                return View();
            else
                return RedirectToAction("Status", "Home", new { code = 401 });
        }
    }
}
