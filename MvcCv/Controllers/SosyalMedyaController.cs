using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
      
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya t)
        {
            t.Durum = true;
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            var deger = repo.Find(x => x.ID == id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult SosyalMedyaGetir(TblSosyalMedya p)
        {
            var deger = repo.Find(x => x.ID == p.ID);
            deger.Ad=p.Ad;
            deger.Icon = p.Icon;
            deger.Link = p.Link;
            deger.Durum = p.Durum;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaSil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

    }
}