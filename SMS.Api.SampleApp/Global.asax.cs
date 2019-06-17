using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SMS.Api.SampleApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            Response.RedirectToRoute("Error");
        }
    }
}