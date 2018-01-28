using CamadaDeApresentacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamadaDeApresentacao.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Lista));
        }

        public ActionResult Lista()
        {
            ICollection<Post> posts = new List<Post>();

            for (int i = 0; i < 10; i++)
            {
                posts.Add(new Post
                {
                    Autor = $"Autor do Post {i + 1}",
                    Categoria = $"Categoria {i + 1}",
                    Data = DateTime.Now.Subtract(TimeSpan.FromDays(i)),
                    Texto = $"{i + 1} - Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Titulo = $"Título do Post {i + 1}"
                });
            }

            return View(posts);
        }
    }
}