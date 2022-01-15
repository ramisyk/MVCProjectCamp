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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

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
            messageManager.Add(message);
            return RedirectToAction("Index");
        }
    }
}