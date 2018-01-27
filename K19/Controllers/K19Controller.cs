using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K19.Controllers
{
    public class K19Controller : Controller
    {
        // GET: K19
        public ActionResult Index()
        {
            Random random = new Random();
            ViewBag.NumeroDaSorte = random.Next();
            return View();
        }
    }
}