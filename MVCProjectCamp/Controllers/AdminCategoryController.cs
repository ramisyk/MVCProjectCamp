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
        [Authorize]
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
                return RedirectToAction("Index");
            }
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.Delete(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var selectedCategory = categoryManager.GetById(id);
            return View(selectedCategory);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }
    }
}