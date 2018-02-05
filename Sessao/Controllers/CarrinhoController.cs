using Sessao.Models;
using System.Web.Mvc;

namespace Sessao.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult Index()
        {
            return View(PegarCarrinhoDaSessao());
        }

        public ActionResult Cancelar()
        {
            Session.Abandon();
            return RedirectToAction(nameof(ProdutoController.Index), nameof(ProdutoController).Replace("Controller", ""));
        }

        public ActionResult Adicionar(int id = 0)
        {
            K19Context context = new K19Context();
            Produto produto = context.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            Carrinho carrinho = PegarCarrinhoDaSessao();
            carrinho.Produtos.Add(produto);

            TempData["Mensagem"] = "Produto adicionado ao carrinho com sucesso!";

            return RedirectToAction(nameof(ProdutoController.Index), nameof(ProdutoController).Replace("Controller", ""));
        }

        public ActionResult Remover(int idx = 0)
        {
            Carrinho carrinho = PegarCarrinhoDaSessao();
            carrinho.Produtos.RemoveAt(idx);

            return RedirectToAction(nameof(Index));
        }

        private Carrinho PegarCarrinhoDaSessao()
        {
            if (Session["Carrinho"] == null)
            {
                Session["Carrinho"] = new Carrinho();
            }

            return Session["Carrinho"] as Carrinho;
        }
    }
}