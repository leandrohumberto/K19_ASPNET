using System.Diagnostics;
using System.Web.Mvc;

namespace Filtros.Filters
{
    public class ElapsedTimeAttribute : ActionFilterAttribute
    {
        private Stopwatch duration;

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            duration = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            duration.Stop();
            string info = $"Duração total: {duration.ElapsedMilliseconds} ms";
            filterContext.HttpContext.Response.Write(info);
        }
    }
}