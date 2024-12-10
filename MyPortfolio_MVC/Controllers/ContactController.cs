using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values= db.TblContacts.ToList();
            return View(values);
        }

        public ActionResult DeleteContact (int id)
        {
            var value=db.TblContacts.Find(id);
            db.TblContacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = db.TblContacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact model) 
        {
            var value= db.TblContacts.FirstOrDefault(x=>x.ContactId==model.ContactId);
            value.Phone = model.Phone;
            value.Email = model.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(TblContact model) 
        {
            db.TblContacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}