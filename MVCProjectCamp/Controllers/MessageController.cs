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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message
        public ActionResult Inbox()
        {
            var result = messageManager.GetAllInbox();
            return View(result);
        }
        public ActionResult Sendbox()
        {
            var result = messageManager.GetAllSendbox();
            return View(result);
        }
        public ActionResult GetMessageDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult validationResult = messageValidator.Validate(message);

            if (validationResult.IsValid)
            {
                message.MessageDate = DateTime.Now;
                messageManager.Add(message);
                return RedirectToAction("Inbox");
            }
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();

            
        }
    }
}