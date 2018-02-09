using System.Collections.Generic;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CursosController : ApiController
    {
        private static List<Curso> cursos = new List<Curso>
        {
            new Curso{ Sigla = "K31", Nome = "C# e Orientação a Objetos" },
            new Curso{ Sigla = "K32", Nome = "Desenvlvimento Web com ASP.NET MVC" }
        };

        public List<Curso> Get()
        {
            return cursos;
        }

        public Curso Get(string sigla)
        {
            Curso curso = cursos.Find(c => c.Sigla.Equals(sigla));
            return curso;
        }

        public Curso Get(int id)
        {
            Curso curso = cursos.Find(c => c.Id == id);
            return curso;
        }

        public void Post(Curso curso)
        {
            cursos.Add(curso);
        }
    }
}
