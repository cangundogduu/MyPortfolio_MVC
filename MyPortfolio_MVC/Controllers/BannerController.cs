using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class BannerController : Controller
    {
        // GET: Banner
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
            var values = db.TblBanners.ToList();
            return View(values);
        }


        public ActionResult DeleteBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            db.TblBanners.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            var values = db.TblBanners.ToList();
            foreach (var banner in values)
            {
                banner.IsShown = false;
            }

            var selectedBanner= db.TblBanners.FirstOrDefault(b=>b.BannerId == id);
            if(selectedBanner != null)
            {
                selectedBanner.IsShown = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public ActionResult UpdateBanner(int id)
        //{
        //    var value = db.TblBanners.Find(id);
        //    return View(value);
        //}

        //[HttpPost]
        //public ActionResult UpdateBanner(TblBanner model)
        //{
        //    var value= db.TblBanners.FirstOrDefault(x=>x.BannerId==model.BannerId);
        //    value.Title = model.Title;
        //    value.Description = model.Description;
        //    value.IsShown = model.IsShown;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult CreateBanner ()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult CreateBanner(TblBanner banner)
        {
            db.TblBanners.Add(banner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }


}