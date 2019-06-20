using api.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace api.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }
        public async Task<ActionResult> Index()
        {
           
            ViewBag.Title = "Home Page";
            /*
            IdentityRole user = new IdentityRole("user");
            IdentityRole seller = new IdentityRole("seller");

            var u = await RoleManager.CreateAsync(user);
            var s = await RoleManager.CreateAsync(seller);
            */
            return View();
        }
    }
}
