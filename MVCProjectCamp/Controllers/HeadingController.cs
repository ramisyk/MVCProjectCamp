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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var result = headingManager.GetAll();
            return View(result);
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

            List<SelectListItem> writers = (from x in writerManager.GetAll()
                                            select new SelectListItem
                                            {
                                                Text = x.WriterName + " " + x.WriterSurname,
                                                Value = x.WriterId.ToString()
                                            }).ToList();
            ViewBag.categories = categories;
            ViewBag.writers = writers;
            return View();
        }


        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.Add(heading);
            return RedirectToAction("Index");
        }

        public ActionResult ContentByHeading()
        {
            return View();
        }
    }
}