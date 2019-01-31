using Market.Models;
using Market.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            // Listado de usuarios
            var users = userManager.Users.ToList();
            var usersView = new List<UserView>();
            foreach (var user in users)
            {
                var userView = new UserView
                {
                    Email = user.Email,
                    Name = user.UserName,
                    UserID = user.Id
                };

                usersView.Add(userView);

            }
            return View(usersView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}