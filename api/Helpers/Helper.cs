using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Helpers
{
    public static class Helper
    {
        public static ApplicationUser GetUser(
            System.Web.Http.Controllers.HttpRequestContext RequestContext,
            ApplicationDbContext db)
        {
            string name = RequestContext.Principal.Identity.Name;
            return db.Users.FirstOrDefault(u => u.UserName == name);
         
        }  
    }
}