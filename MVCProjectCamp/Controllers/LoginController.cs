using DataAccess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var adminInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName);
            if (adminInfo != null)
            {
                return RedirectToAction("Index", "AdminCategory");
            }
            return RedirectToAction("Index");
        }
    }
}