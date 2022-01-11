using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var result = contactManager.GetAll();
            return View(result);
        }
        public ActionResult GetContactDetails (int id)
        {
            var contact = contactManager.GetById(id);
            return View(contact);
        }

        public PartialViewResult MessageSideNav()
        {
            return PartialView();
        }
    }
}