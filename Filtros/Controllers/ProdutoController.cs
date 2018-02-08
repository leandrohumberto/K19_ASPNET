using Filtros.Filters;
using Filtros.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Filtros.Controllers
{
    public class ProdutoController : Controller
    {
        private K19Context db = new K19Context();

        // GET: Produto
        [ElapsedTime]
        public ActionResult Index()
        {
            return View(db.Produtos.ToList());
        }

        [Authorize]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        [HandleError(ExceptionType = typeof(System.ArgumentOutOfRangeException), View = "PosicaoInvalida")]
        public ActionResult Visualizar(int posicao)
        {
            List<Produto> produtos = db.Produtos.ToList();
            return View(produtos[posicao]);
        }
    }
}