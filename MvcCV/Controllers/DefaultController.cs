using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var degerler=db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();

            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler=db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalarım()
        {
            var sertifika = db.TblSertifikalarım.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult İletisim()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletisim(Tblİletisim t)
        {
            t.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tblİletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}