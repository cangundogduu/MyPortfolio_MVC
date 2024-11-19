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
       MyPortfolioDbEntities db =new MyPortfolioDbEntities();

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
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbar() 
        {
            ViewBag.nameSurname = db.TblAdmins.Where(x => x.Email == Session["email"].ToString()).Select(x => x.Name + " " + x.Surname);
            ViewBag.image = db.TblAdmins.Where(x => x.Email == Session["email"].ToString()).Select(x => x.ImageUrl);
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
    }
}