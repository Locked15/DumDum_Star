using DumDum_Star.Models;
using DumDum_Star.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        public IActionResult Create(CyberWare? model = null)
        {
            if (ValidateUserAccess())
            {
                PrepareViewBagToCreation();
                return View("Create", model ?? new CyberWare());
            }

            else
                return RedirectToAction("Status", "Home", new { code = 401 });
        }

        public IActionResult Update()
        {
            if (ValidateUserAccess())
                return View();
            else
                return RedirectToAction("Status", "Home", new { code = 401 });
        }

        public IActionResult Delete()
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

        #region Data Controllers.

        public IActionResult CreateCyberWare(string price, string loadLevel, CyberWare model)
        {
            SetFloatValuesToModel(model, price, loadLevel);
            UpdateModelImage(model);

            if (ValidateCreationModel(model))
            {
                model.Custom = true;

                Context.CyberWares.Add(model);
                Context.SaveChangesAsync();

                return RedirectToAction("Overview");
            }
            else
            {
                return RedirectToAction("Create", model);
            }
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

        [NonAction]
        private void PrepareViewBagToCreation()
        {
            ViewBag.Manufacturers = Context.Corporations.ToList();
            ViewBag.Types = Context.CyberWareTypes.ToList();
            ViewBag.Targets = Context.CyberWareTargets.ToList();
        }

        [NonAction]
        private static bool SetFloatValuesToModel(CyberWare model, string originalPrice, string originalLoad)
        {
            if (originalPrice != null && originalLoad != null)
            {
                originalLoad = originalLoad.Replace('.', ',');
                originalPrice = originalPrice.Replace('.', ',');

                if (decimal.TryParse(originalPrice, out decimal result) && float.TryParse(originalLoad, out float load))
                {
                    model.Price = result;
                    model.LoadLevel = load;

                    return true;
                }
            }

            return false;
        }

        [NonAction]
        private static void UpdateModelImage(CyberWare model)
        {
            if (Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                var request = new HttpClient()
                {
                    BaseAddress = new(model.Image)
                };
                var result = request.GetAsync(model.Image).Result;

                if (result.IsSuccessStatusCode)
                    return;
            }

            model.Image = null;
        }

        [NonAction]
        private static bool ValidateCreationModel(CyberWare model)
        {
            var context = new ValidationContext(model);
            var errors = new List<ValidationResult>(1);

            if (Validator.TryValidateObject(model, context, errors, true))
                return true;

            return false;
        }
        #endregion
    }
}
