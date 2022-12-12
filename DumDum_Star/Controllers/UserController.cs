using DumDum_Star.Models;
using DumDum_Star.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DumDum_Star.Controllers
{
    public class UserController : Controller
    {
        public DDSDataContext Context { get; private set; }

        public UserController(DDSDataContext context)
        {
            Context = context;
        }

        #region Controller Handlers.

        public IActionResult Account()
        {
            if (SessionData.CurrentChoom != null)
                return View();

            else
                return RedirectToAction("Authorization");
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Authorization()
        {
            return View();
        }
        #endregion

        #region Action Handlers.

        public IActionResult RegisterUser(Choom? newChoom)
        {
            if (newChoom != null)
            {
                var errors = new List<ValidationResult>(1);
                ValidationContext context = new(newChoom);
                Validator.TryValidateObject(newChoom, context, errors, true);

                if (!errors.Any() && CheckCredentialsToUnique(newChoom.Login, newChoom.MailAddress))
                {
                    Context.Chooms.Add(newChoom);
                    Context.SaveChangesAsync();

                    return RedirectToActionPermanent("Index", "Home", null);
                }
            }

            return View("Registration");
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
        #endregion

        #region Non-Action Functions.

        [NonAction]
        private bool CheckCredentialsToUnique(string login, string email)
        {
            return !Context.Chooms.Any(choom => choom.Login == login ||
                                               choom.MailAddress == email);
        } 

        [NonAction]
        private Choom? TryToGetUserByCredentials(string login, string password)
        {
            Choom? auth = Context.Chooms.Where(choom => choom.Login == login &&
                                                       choom.Password == password)
                                        .FirstOrDefault();

            return auth;
        }
        #endregion
    }
}
