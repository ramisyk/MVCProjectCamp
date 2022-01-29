using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeadings(int id=4)
        {
            var results = headingManager.GetAllByWriterId(id);
            return View(results);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            
            ViewBag.categories = categories;
            
            return View();
        }


        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 4;
            heading.HeadingStatus = true;
            headingManager.Add(heading);
            return RedirectToAction("MyHeadings");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categories = (from x in categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.categories = categories;

            var heading = headingManager.GetById(id);
            return View(heading);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {

            headingManager.Update(heading);
            return RedirectToAction("MyHeadings");
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = headingManager.GetById(id);
            heading.HeadingStatus = false;
            headingManager.Update(heading);
            return RedirectToAction("MyHeadings");
        }
    }
}