using DumDum_Star.Models;
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
                LimitLoad = 1.0,
                ManufacturerId = 0,
                TypeId = 0,
            };
            model.AvailableCyberWares.AddRange(Context.CyberWares.Where(cyb => 
                                                                        cyb.Quantity > 0));

            PrepareViewBag();
            return View("Index", model);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Locations()
        {
            return View();
        }

        public IActionResult Search(string search, float limitLoad, int manufacturerId, int typeId)
        {
            HomeModel model = PrepareIndexModelBySelections(search, limitLoad, manufacturerId, typeId);

            PrepareViewBag();
            return View("Index", model);
        }

        public IActionResult AddToCart(int id, int count = 1)
        {
            if (SessionData.CurrentChoom != null)
            {
                SessionData.InsertCyberWareToOrder(Context.CyberWares.FirstOrDefault(cb => cb.Id == id), count);
                return RedirectToAction("Prepare", "Order", null);
            }
            else
            {
                return RedirectToAction("Authorization", "User", null);
            }
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

        #region Non-Action Functions.

        [NonAction]
        private void PrepareViewBag()
        {
            ViewBag.Corporations = Context.Corporations.ToList();
            ViewBag.Corporations.Insert(0, new Corporation() { Id = 0, Name = "Все" });

            ViewBag.Types = Context.CyberWareTypes.ToList();
            ViewBag.Types.Insert(0, new CyberWareType() { Id = 0, Type = "Все" });
        }

        [NonAction]
        private HomeModel PrepareIndexModelBySelections(string search, float limitLoad, int manufacturerId, int typeId)
        {
            search ??= string.Empty;
            var model = new HomeModel()
            {
                AvailableCyberWares = Context.CyberWares.ToList().Where(cyb =>
                {
                    var basicComparison = cyb.Name.Contains(search, StringComparison.OrdinalIgnoreCase) && cyb.LoadLevel <= limitLoad;
                    var corpoSearch = manufacturerId == 0 || cyb.ManufacturerId == manufacturerId;
                    var typeSearch = typeId == 0 || cyb.TypeId == typeId;
                    var count = cyb.Quantity > 0;

                    return basicComparison && corpoSearch && typeSearch & count;
                }).ToList(),

                Search = search,
                LimitLoad = limitLoad,
                ManufacturerId = manufacturerId,
                TypeId = typeId
            };
            model.AvailableCyberWares = model.AvailableCyberWares.ToList();

            return model;
        }
        #endregion
    }
}
