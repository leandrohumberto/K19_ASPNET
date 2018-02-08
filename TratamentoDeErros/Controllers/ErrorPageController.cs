using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TratamentoDeErros.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }
    }
}