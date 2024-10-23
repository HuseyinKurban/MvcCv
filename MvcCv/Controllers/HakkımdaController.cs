using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        HakkimdaRepository repo = new HakkimdaRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
    }
}