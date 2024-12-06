using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        MyPortfolioDbEntities db= new MyPortfolioDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var value= db.TblAbouts.FirstOrDefault();
            return View(value);
        }




        [HttpPost]
        public ActionResult Index(TblAbout model)
        {
            var value = db.TblAbouts.FirstOrDefault(x => x.AboutId == model.AboutId);

            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                value.ImageUrl = "/images/" + model.ImageFile.FileName;
            }
            value.Title = model.Title;
            value.Description = model.Description;
            value.CvUrl = model.CvUrl;
            db.SaveChanges();

            return View(model);
        }

    }
}