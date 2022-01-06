using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        // GET: AdminCategory
        public ActionResult Index()
        {
            var result = categoryManager.GetAll();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //categoryManager.Add(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("GetCategoryList");
            }
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
    }
}