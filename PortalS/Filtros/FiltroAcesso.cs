using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalS.Filtros
{
    public class FiltroAcesso : ActionFilterAttribute
    {
        // GET: FiltroAcesso
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuarioLogado = filterContext.HttpContext.Session["User"];
            if (usuarioLogado == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { action = "Index", Controller = "Home" }));
            }
        }
        
    }
}