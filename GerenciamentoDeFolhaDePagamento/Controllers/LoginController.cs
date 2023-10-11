using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciamentoDeFolhaDePagamento.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            /*
            Validar Validacao = new Validar();
            string Nome = Validacao.Main();

            ViewBag.Nome = Nome;
            */
            return View();
        }
        
        public ActionResult RedefinicaoDeSenha()
        {
            return View();
        }

        public ActionResult RedefinicaoDeSenha_Alteracao()
        {
            return View();
        }
    }
}