using DumDum_Star.Models;
using DumDum_Star.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DumDum_Star.Controllers
{
    public class OrderController : Controller
    {
        public DDSDataContext Context { get; init; }

        public OrderController(DDSDataContext context)
        {
            Context = context;
        }

        #region Specific Handlers.

        public IActionResult Prepare()
        {
            if (SessionData.CurrentChoom != null)
            {
                PrepareViewBagForPreparePage();
                return View(SessionData.CurrentOrder);
            }

            else
                return RedirectToAction("Authorization", "User");
        }
        #endregion

        #region General Handlers.

        public IActionResult UpdateOrderDetails(int cyberWareId, int count)
        {
            SessionData.UpdateCyberWareInOrder(cyberWareId, count);

            return RedirectToAction("Prepare");
        }

        public IActionResult SaveOrder(int addressId, DateTime orderDate)
        {
            PrepareOrderByCurrentData(addressId, orderDate);

            if (ValidateCreatedModel())
            {
                SaveCreatedOrderToDb();
                SessionData.ResetOrder();

                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                return View("Order");
            }
        }
        #endregion

        #region Non-Action Functions.

        [NonAction]
        private void PrepareViewBagForPreparePage()
        {
            ViewBag.Addresses = Context.Addresses.ToList();
        }

        [NonAction]
        private void PrepareOrderByCurrentData(int addressId, DateTime orderDate)
        {
            SessionData.CurrentOrder.ChoomId = SessionData.CurrentChoom.Id;
            SessionData.CurrentOrder.Choom = SessionData.CurrentChoom;

            SessionData.CurrentOrder.AddressId = addressId;
            SessionData.CurrentOrder.Address = Context.Addresses.First(address => address.Id == addressId);

            SessionData.CurrentOrder.ChippinTime = orderDate;
        }

        private void SaveCreatedOrderToDb()
        {
            var choom = SessionData.CloneChoom();
            var order = SessionData.CloneOrder(choom);

            Context.Orders.Add(order);
            Context.CyberWareToOrders.AddRange(order.CyberWareToOrders);

            Context.SaveChanges(true);
        }

        [NonAction]
        private static bool ValidateCreatedModel()
        {
            if (SessionData.CurrentOrder != null)
            {
                var errors = new List<ValidationResult>(1);
                var context = new ValidationContext(SessionData.CurrentOrder);

                return Validator.TryValidateObject(SessionData.CurrentOrder, context, errors, true);
            }

            return false;
        }
        #endregion
    }
}
