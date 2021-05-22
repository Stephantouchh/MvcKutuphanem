using MvcKutuphanem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphanem.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMİN p)
        {
            var bilgiler = db.TBLADMİN.FirstOrDefault(x => x.KULLANİCİ == p.KULLANİCİ && x.SİFRE == p.SİFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANİCİ, false);
                Session["KULLANİCİ"] = bilgiler.KULLANİCİ.ToString();
                return RedirectToAction("Index", "istatistik");
            }
            else
            {
                return View();
            }
        }
    }
}