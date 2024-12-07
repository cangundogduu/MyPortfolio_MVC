using Microsoft.Ajax.Utilities;
using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        public ActionResult Layout()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar()
        {
            var email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);

            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageUrl;
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbar()
        {
            var email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);

            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageUrl;
            return PartialView();
        }

        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutScripts()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbarMessage()
        {
            //var email=Session["email"].ToString();
            //var admin = db.TblAdmins.FirstOrDefault(x=>x.Email==email);
            //ViewBag.nameSurname = admin.Name;
            //ViewBag.image = admin.ImageUrl;
            var unReadMessages=db.TblMessages.Where(x=>x.IsRead==false).OrderByDescending(x=>x.MessageId).Take(3).ToList();
          
            return PartialView(unReadMessages);
        }
    }
}