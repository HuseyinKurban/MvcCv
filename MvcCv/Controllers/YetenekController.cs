using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {

            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult YetenekGetir(TblYeteneklerim p)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == p.ID);
            t.Resim = p.Resim;
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}