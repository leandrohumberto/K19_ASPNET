using CamadaDeControle.Models;
using System.Linq;
using System.Web.Mvc;

namespace CamadaDeControle.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Lista));
        }

        public ActionResult Lista(double? precoMinimo, double? precoMaximo)
        {
            K19Context context = new K19Context();
            var produtos = context.Produtos.AsEnumerable();

            if (precoMinimo != null && precoMaximo != null)
            {
                produtos = from p in produtos
                           where p.Preco >= precoMinimo && p.Preco <= precoMaximo
                           select p;
            }

            return View(produtos);
        }

        [HttpGet]
        public ActionResult Cadastra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastra(Produto produto)
        {
            K19Context context = new K19Context();
            context.Produtos.Add(produto);
            context.SaveChanges();

            TempData["Mensagem"] = "Produto cadastrado com sucesso!";
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public ActionResult Editar(int id = 0)
        {
            K19Context context = new K19Context();
            Produto produto = context.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            K19Context context = new K19Context();
            context.Entry(produto).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

            return RedirectToAction(nameof(Lista));
        }
    }
}