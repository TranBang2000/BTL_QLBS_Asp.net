using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VinaMilk.Common;

namespace VinaMilk.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session[CommonConstants.USERCLIENT_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                  RouteValueDictionary(new { Controller = "Login", Action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}