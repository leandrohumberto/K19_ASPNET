using Filtros.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Filtros.Controllers
{
    public class AutenticadorController : Controller
    {
        // GET: Autenticador
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Logar));
        }

        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario, string returnUrl)
        {
            if (FormsAuthentication.Authenticate(usuario.Username, usuario.Password))
            {
                FormsAuthentication.SetAuthCookie(usuario.Username, false);

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction(nameof(ProdutoController.Index), nameof(ProdutoController).Replace("Controller", ""));
            }
            else
            {
                ViewBag.Mensagem = "Usuário ou senha incorretos";
                return View(usuario);
            }
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(nameof(Logar));
        }
    }
}