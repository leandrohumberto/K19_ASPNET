using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamadaDeApresentacao.Controllers
{
    public class SorteController : Controller
    {
        // GET: Sorte
        public ActionResult Index()
        {
            Random random = new Random();
            ViewBag.NumeroDaSorte = random.Next();
            return View();
        }
    }
}