using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VinaMilk.Common;

namespace VinaMilk.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session =(UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                  RouteValueDictionary(new { Controller = "Login", Action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
        protected void setAlert(string message,string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}