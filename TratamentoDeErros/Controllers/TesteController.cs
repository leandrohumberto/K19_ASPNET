using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TratamentoDeErros.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult TestaErro()
        {
            string[] nomes = { "Leandro", "Humberto" };
            string nome = nomes[2];
            return View();
        }
    }
}