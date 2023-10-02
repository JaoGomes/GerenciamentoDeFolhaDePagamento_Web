using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciamentoDeFolhaDePagamento.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            /*
            FAZER LÓGICA
            - Se o usuário já estiver conectado, entrar no gerenciamento de folha automatiamente.
            - Caso o usuário não esteja conectado, redirecionar automaticamente para a tela de login.
             */

            //View da tela de Login
            GerenciamentoDeFolhaDePagamento.Controllers.LoginController ControllerLogin = new GerenciamentoDeFolhaDePagamento.Controllers.LoginController();
            //return ControllerLogin.Index();

            //View do Gerenciamento de Folha de Pagamento
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}