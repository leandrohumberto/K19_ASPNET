using System;
using System.IO;
using System.Web.Mvc;

namespace Filtros.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private static string filename = "RequisicoesInfo.log";
        private static string logFilePath;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SaveInfo(filterContext);
        }

        private void SaveInfo(ControllerContext context)
        {
            string usuario = context.HttpContext.User.Identity.Name;
            string ip = context.HttpContext.Request.UserHostAddress;
            string url = context.HttpContext.Request.RawUrl;

            string info = $"Usuário: {usuario}, IP: {ip}, Data/Hora: {DateTime.UtcNow}, Url: {url}";
            string path = GetLogFilePath(context);
            File.AppendAllLines(path, new[] { info });
        }

        private static string GetLogFilePath(ControllerContext context)
        {
            if (logFilePath == null)
            {
                var logPath = context.HttpContext.Server.MapPath("~/Logs");

                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                var path = Path.Combine(logPath, filename);
                logFilePath = path;
            }

            return logFilePath;
        }
    }
}