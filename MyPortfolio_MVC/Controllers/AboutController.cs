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
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

       
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }


        public ActionResult DeleteAbout(int id)
        {
            var value= db.TblAbouts.Find(id);
            db.TblAbouts.Remove(value);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbouts.Find(id);
            return View(value);
        }


        [HttpPost]
        public ActionResult UpdateAbout(TblAbout model)
        {
            var value = db.TblAbouts.Find(model.AboutId);

            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                model.ImageUrl = "/images/" + model.ImageFile.FileName;
            }

            if (model.CvFile != null)
            { 
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "Cv\\";
                if (!Directory.Exists(saveLocation))
                {
                    Directory.CreateDirectory(saveLocation);
                }
                var fileName = Path.Combine(saveLocation, model.CvFile.FileName);
                model.CvFile.SaveAs(fileName);
                model.CvUrl = "/Cv/" + model.CvFile.FileName;
 
            }

            value.Title = model.Title;
            value.Description = model.Description;
            value.ImageUrl=model.ImageUrl;
            value.CvUrl = model.CvUrl;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}