using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial

        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }



        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial model, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    model.ImageUrl = "/images/" + model.ImageFile.FileName;
                }
                db.TblTestimonials.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            return View(value);
        }


        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial model, HttpPostedFileBase ImageFile)
        {
            var value = db.TblTestimonials.Find(model.TestimonialId);

            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                model.ImageUrl = "/images/" + model.ImageFile.FileName;
            }
            value.NameSurname = model.NameSurname;
            value.Title = model.Title;
            value.Comment = model.Comment;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index", "Testimonial");
        }
    }
}