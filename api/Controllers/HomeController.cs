using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            IdentityRole user = new IdentityRole("user");
            IdentityRole seller = new IdentityRole("seller");

            var u = await RoleManager.CreateAsync(user);
            var s = await RoleManager.CreateAsync(seller);

            return View();
        }
    }
}
