using Filtros.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Filtros.Controllers
{
    public class K19AutenticadorController : Controller
    {
        // GET: k19Autenticador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario, string returnUrl)
        {
            if (usuario.Username.EndsWith("@k19.com.br") && usuario.Password == "k32")
            {
                FormsAuthentication.SetAuthCookie(usuario.Username, false);

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return Redirect(Url.Action(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", "")));
            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return View();
            }
        }
    }
}