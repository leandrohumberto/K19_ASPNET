using CamadaDeApresentacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamadaDeApresentacao.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public ActionResult Detalhes()
        {
            return View(new Aluno
            {
                AlunoID = 1,
                Nome = "Leandro",
                Email = "leandro@mail.com"
            });
        }

        public ActionResult Lista()
        {
            ICollection<Aluno> lista = new List<Aluno>();

            for (int i = 0; i < 5; i++)
            {
                lista.Add(new Aluno
                {
                    AlunoID = i + 1,
                    Nome = "Aluno " + (i + 1),
                    Email = "Email " +  (i + 1),
                });
            }

            return View(lista);
        }

        public ActionResult Editar()
        {
            return View(new Aluno
            {
                AlunoID = 1,
                Nome = "Leandro",
                Email = "leandro@mail.com"
            });
        }
    }
}