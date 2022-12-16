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

        #region Views Controllers.

        public IActionResult Overview()
        {
            if (ValidateUserAccess())
                return View();
            else
                return RedirectToAction("Status", "Home", new { code = 401 });
        }

        public IActionResult CreateCyberWare()
        {
            if (ValidateUserAccess())
                return View();
            else
                return RedirectToAction("Status", "Home", new { code = 401 });
        }

        public IActionResult UpdateCyberWare()
        {
            if (ValidateUserAccess())
                return View();
            else
                return RedirectToAction("Status", "Home", new { code = 401 });
        }

        public IActionResult DeleteCyberWare()
        {
            if (ValidateUserAccess())
                return View();
            else
                return RedirectToAction("Status", "Home", new { code = 401 });
        }

        public IActionResult OrdersWork()
        {
            if (ValidateUserAccess())
                return View();
            else
                return RedirectToAction("Status", "Home", new { code = 401 });
        }

        public IActionResult Exit()
        {
            SessionData.ResetChoom();

            return RedirectToAction("Index", "Home", null);
        }
        #endregion

        #region Non-Action Functions.

        [NonAction]
        private bool ValidateUserAccess()
        {
            var choomId = SessionData.CurrentChoom?.Id ?? -1;
            if (Context.Admins.Any(admin => admin.Id == choomId))
                return true;

            return false;
        }
        #endregion
    }
}
