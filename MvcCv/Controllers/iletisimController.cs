using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
       
        DbCvEntities c=new DbCvEntities();
        public ActionResult Index()
        {
            var degerler =c.Tbliletisim.OrderByDescending(x=>x.ID).ToList();
            return View(degerler);
        }
    }
}