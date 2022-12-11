using DumDum_Star.Models.Entities;
using DumDum_Star.Models.Views;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DumDum_Star.Controllers
{
    public class HomeController : Controller
    {
        public DDSDataContext Context { get; private set; }

        public HomeController(DDSDataContext context) 
        {
            Context = context;
        }

        #region Specific Handlers.

        public IActionResult Index()
        {
            var model = new HomeModel()
            {
                Search = string.Empty,
                LimitLoad = 1.0
            };
            model.AvailableCyberWares.AddRange(Context.CyberWares);

            return View(model);
        }

        public IActionResult Search(string search, float limitLoad)
        {
            search ??= string.Empty;
            var model = new HomeModel()
            {
                AvailableCyberWares = Context.CyberWares.ToList().Where(cyb => 
                    {
                        return cyb.Name.Contains(search, StringComparison.OrdinalIgnoreCase) && cyb.LoadLevel <= limitLoad;
                    }
                ).ToList(),
                Search = search,
                LimitLoad = limitLoad
            };

            return View("Index", model);
        }

        public IActionResult AddToCart(int id)
        {

            return null;
        }
        #endregion

        #region General Handlers.

        public IActionResult Status(int code) => Error((HttpStatusCode)code);

        public IActionResult Error(HttpStatusCode code = default)
        {
            var model = new ErrorModel()
            {
                ID = Guid.NewGuid(),
                Code = code
            };
            model.GenerateMessage();

            return View("Error", model);
        }
        #endregion
    }
}
