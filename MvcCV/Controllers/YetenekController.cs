using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class YetenekController : Controller
    {
        
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler=repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGüncelle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekGüncelle(TblYeteneklerim p)
        {
            var y = repo.Find(x => x.ID ==p.ID);
            y.Yetenek = p.Yetenek;
            y.Oran = p.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }

    }
}