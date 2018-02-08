using Filtros.Controllers;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filtros.Filters
{
    public class K19AutorizacaoAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity identity = filterContext.Principal.Identity;

            if (!identity.IsAuthenticated || !identity.Name.EndsWith("@k19.com.br"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = nameof(K19AutenticadorController).Replace("Controller", ""),
                    action = nameof(K19AutenticadorController.Logar),
                    returnUrl = filterContext.HttpContext.Request.RawUrl
                }));
            }
        }
    }
}