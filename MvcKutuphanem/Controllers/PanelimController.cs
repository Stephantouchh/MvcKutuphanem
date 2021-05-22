using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphanem.Models.Entity;

namespace MvcKutuphanem.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {
        // GET: Panelim
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]

        public ActionResult Index()
        {
            var uyemail = (string)Session["MAIL"];
            // var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var degerler = db.TBLDUYURULAR.ToList();

            var d1 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.AD).FirstOrDefault();
            ViewBag.d1 = d1;

            var d2 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;

            var d3 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;

            var d4 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;

            var d5 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d5 = d5;

            var d6 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;

            var d7 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d7 = d7;

            var uyeid = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.ID).FirstOrDefault();
            var d8 = db.TBLHAREKET.Where(x => x.UYE == uyeid).Count();
            ViewBag.d8 = d8;

            var d9 = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d9 = d9;

            var d10 = db.TBLDUYURULAR.Count();
            ViewBag.d10 = d10;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string)Session["MAIL"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.ŞIFRE = p.ŞIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["MAIL"];
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["MAIL"];
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanici).Select(y => y.ID).FirstOrDefault();
            var uyebul = db.TBLUYELER.Find(id);
            return PartialView("Partial2",uyebul);
        }
    }
}