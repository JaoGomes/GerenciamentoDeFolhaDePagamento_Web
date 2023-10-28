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

            routes.MapRoute(
                name: "Entrar",
                url: "Login/Entrar",
                defaults: new { controller = "Login", action = "Entrar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Sair",
                url: "Home/Sair",
                defaults: new { controller = "Home", action = "Sair", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Entrada",
                url: "Home/Entrada",
                defaults: new { controller = "Home", action = "Entrada", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Pausa",
                url: "Home/Pausa",
                defaults: new { controller = "Home", action = "Pausa", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Retorno",
                url: "Home/Retorno",
                defaults: new { controller = "Home", action = "Retorno", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Saida",
                url: "Home/Saida",
                defaults: new { controller = "Home", action = "Saida", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Redefinicao",
                url: "Login/Redefinicao",
                defaults: new { controller = "Login", action = "RedefinicaoDeSenha", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Redefinicao_Redefinir",
                url: "Login/Redefinicao_Redefinir",
                defaults: new { controller = "Login", action = "Redefinicao_Redefinir", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Alteracao",
                url: "Login/Alteracao",
                defaults: new { controller = "Login", action = "RedefinicaoDeSenha_Alteracao", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Alteracao_Redefinir",
                url: "Login/Alteracao_Redefinir",
                defaults: new { controller = "Login", action = "Alteracao_Redefinir", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
