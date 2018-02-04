using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validacao.Models;

namespace Validacao.Controllers
{
    public class JogadorController : Controller
    {
        // GET: Jogador
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Lista));
        }

        public ActionResult Lista()
        {
            K19Context context = new K19Context();
            return View(context.Jogadores);
        }

        [HttpGet]
        public ActionResult Cadastra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastra(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                K19Context context = new K19Context();
                context.Jogadores.Add(jogador);
                context.SaveChanges();
                return RedirectToAction(nameof(Lista));
            }
            else
            {
                return View(jogador);
            }
        }
    }
}