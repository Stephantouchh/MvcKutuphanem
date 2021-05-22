using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphanem.Models.Entity;

namespace MvcKutuphanem.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var kullanicilar = db.TBLADMİN.ToList();
            return View(kullanicilar);
        }
        public ActionResult Index2()
        {
            var kullanicilar = db.TBLADMİN.ToList();
            return View(kullanicilar);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMİN p)
        {
            db.TBLADMİN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.TBLADMİN.Find(id);
            db.TBLADMİN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.TBLADMİN.Find(id);
            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMİN p)
        {
            var adm = db.TBLADMİN.Find(p.ID);
            adm.KULLANİCİ = p.KULLANİCİ;
            adm.SİFRE = p.SİFRE;
            adm.YETKİ = p.YETKİ;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}