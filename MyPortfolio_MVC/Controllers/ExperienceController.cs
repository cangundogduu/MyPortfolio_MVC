using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        MyPortfolioDbEntities db= new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblExperiences.ToList();
            return View(values);
        }


        public ActionResult DeleteExperience(int id)
        {
            var value=db.TblExperiences.Find(id);
            db.TblExperiences.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult CreateExperience(TblExperience model) 
        {
            
            db.TblExperiences.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var value = db.TblExperiences.Find(id);
            return View(value);
        }
        
        [HttpPost]
        public ActionResult UpdateExperience(TblExperience model)
        {
            var value=db.TblExperiences.FirstOrDefault(x=>x.ExperienceId==model.ExperienceId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.CompanyName = model.CompanyName;
            value.StartDate = model.StartDate;
            value.EndDate = model.EndDate;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}