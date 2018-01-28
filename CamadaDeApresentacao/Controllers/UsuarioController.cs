using CamadaDeApresentacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamadaDeApresentacao.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Editar));
        }

        public ActionResult Editar()
        {
            return View(new Usuario
            {
                Id = 1,
                Nome = "Leandro Humberto",
                Email = "leandro@mail.com",
                Senha = "123",
                Descricao = "Software Developer",
                DataDeCadastramento = DateTime.Now
            });
        }
    }
}