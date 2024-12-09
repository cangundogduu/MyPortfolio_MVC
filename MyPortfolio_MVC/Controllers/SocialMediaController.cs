using Antlr.Runtime.Tree;
using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        MyPortfolioDbEntities db=new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values=db.TblSocialMedias.ToList();
            return View(values);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value= db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id) 
        {
            var value = db.TblSocialMedias.Find(id);
            return View(value);
        }


        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia model) 
        {
            var values = db.TblSocialMedias.FirstOrDefault(x => x.SocialMediaId == model.SocialMediaId);
            values.Name = model.Name;
            values.Url = model.Url;
            db.SaveChanges();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocialMedia model)
        {
            
            db.TblSocialMedias.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}