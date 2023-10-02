using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GerenciamentoDeFolhaDePagamento
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute (
                name: "Login",
                url: "Login",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RedefinicaoDeSenha",
                url: "RedefinicaoDeSenha",
                defaults: new { controller = "Login", action = "RedefinicaoDeSenha", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RedefinicaoDeSenha_Alteracao",
                url: "RedefinicaoDeSenha_Alteracao",
                defaults: new { controller = "Login", action = "RedefinicaoDeSenha_Alteracao", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
