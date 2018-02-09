using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class CursoController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Cadastrar));
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}