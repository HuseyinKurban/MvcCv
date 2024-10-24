using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();

        public ActionResult Index()
        {
            ViewBag.Foto=db.TblHakkimda.Select(x=>x.Resim).FirstOrDefault();
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var degerler = db.TblDeneyimlerim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Egitim()
        {
            var degerler = db.TblEgitimlerim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Yetenek()
        {
            var degerler = db.TblYeteneklerim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Hobi()
        {
            var degerler = db.TblHobilerim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Sertifika()
        {
            var degerler = db.TblSertifikalarim.ToList();
            return PartialView(degerler);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }

    }
}