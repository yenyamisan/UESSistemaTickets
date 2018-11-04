using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UESTicketsProject.Controllers;
using UESTicketsProject.Services.Impl;

namespace UESTicketsProject.Filters
{
    public class UserValiationFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var uId=filterContext.HttpContext.Session.Contents["UId"];
            var rolId= filterContext.HttpContext.Session.Contents["RoleId"];
            if (uId == null || rolId == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Account", action = "Login" })
                );

                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            }

        }
    }
}