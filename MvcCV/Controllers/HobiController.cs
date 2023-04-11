using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }
      
        [HttpPost]
        public ActionResult Index(TblHobilerim h)
        {
            var hobi = repo.Find(x => x.ID ==1);
            hobi.HobiAdi = h.HobiAdi;
            hobi.Aciklama1 = h.Aciklama1;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }
    }
    
}