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
            if(Helper.Sessao.CodFuncionario == -1)
            {
                return View();
            }
            return RedirectToRoute("Home");
        }
        
        public ActionResult RedefinicaoDeSenha()
        {
            if (Helper.Sessao.CodFuncionario == -1)
            {
                return View();
            }
            return RedirectToRoute("Home");
        }

        public ActionResult RedefinicaoDeSenha_Alteracao()
        {
            if (Helper.Sessao.CodFuncionario == -1)
            {
                return View();
            }
            return RedirectToRoute("Home");
        }

        [HttpPost]
        public ActionResult Entrar(string LoginEmail, string LoginSenha)
        {
            try
            {
                LoginEmail = LoginEmail.ToLower();

                ConsultaModel modelConsulta = new ConsultaModel();
                int CodFuncionario = modelConsulta.ValidarUsuario(LoginEmail, LoginSenha);
                //Armazenar o CodFuncionario na Sessao Global

                if(CodFuncionario != -1)
                {
                    Helper.Sessao.CodFuncionario = CodFuncionario;
                    return RedirectToRoute("Home");
                }

                TempData["MensagemErro"] = "Email e/ou Senha inválido(s). Por favor, tente novamente.";
                return RedirectToRoute("Default");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops, não conseguimos realizar seu login, tente novamente. Detalhe do erro: " + erro.Message;
                return RedirectToRoute("Default");
            }
        }
    }
}