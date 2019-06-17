using System.Web.Mvc;
using System.Web.Routing;

namespace SMS.Api.SampleApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Submit",
              url: "submit",
              defaults: new { controller = "Authorization", action = "Submit" }
          );

            routes.MapRoute(
               name: "GetAccessToken",
               url: "anything",
               defaults: new { controller = "Authorization", action = "GetAccessToken" }
            );

            routes.MapRoute(
               name: "RefreshAccessToken",
               url: "refresh_token",
               defaults: new { controller = "Authorization", action = "RefreshAccessToken" }
            );

            routes.MapRoute(
              name: "GetUsers",
              url: "users",
              defaults: new { controller = "Users", action = "GetUsers" }
           );

            routes.MapRoute(
              name: "UpdateUser",
              url: "updateuser/{userId}",
              defaults: new { controller = "Users", action = "UpdateUser", userId = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Error",
                url: "common/error",
                defaults: new { controller = "Common", action = "Error", userId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GetWebHook",
                url: "webhooksetting",
                defaults: new { controller = "WebHookSetting", action = "Index" }
            );

            routes.MapRoute(
                name: "SubscribeWebHook",
                url: "webhooksetting/subscribe",
                defaults: new { controller = "WebHookSetting", action = "Subscribe" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authorization", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
