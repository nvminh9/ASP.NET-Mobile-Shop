using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobile_Shop.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var quyen = httpContext.Session["Quyen"] as string;
            {
                return quyen == "1" || quyen == "2";
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext fileterContext)
        {
            if (!fileterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                fileterContext.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}