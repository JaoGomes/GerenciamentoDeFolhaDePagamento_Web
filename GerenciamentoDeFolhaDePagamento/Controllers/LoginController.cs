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
            if (Helper.Sessao.CodFuncionario != -1)
            {
                return RedirectToRoute("Home");
            }

            return View();
        }

        public ActionResult RedefinicaoDeSenha_Alteracao()
        {
            if (Helper.Sessao.CodFuncionario != -1)
            {
                TempData["MensagemErro"] = "Faça Login!";
                return RedirectToRoute("Home");
            }
            else if(Helper.Sessao.CodFuncionario_Redefinicao == -1)
            {
                TempData["MensagemErro"] = "CPF inválido, tente novamente!";
                return RedirectToRoute("Redefinicao");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Entrar(string LoginEmail, string LoginSenha)
        {
            try
            {
                LoginEmail = LoginEmail.ToLower();

                Models.LoginModel modelLogin = new Models.LoginModel();
                
                int CodFuncionario = modelLogin.ValidarUsuario(LoginEmail, LoginSenha);

                //Armazenar o CodFuncionario na Sessao Global
                if (CodFuncionario != -1)
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

        [HttpPost]
        public ActionResult Redefinicao_Redefinir(string RedefinicaoCpf)
        {
            Models.LoginModel modelLogin = new Models.LoginModel();
            int CodFuncionario = modelLogin.ValidarCpf(RedefinicaoCpf);

            if (CodFuncionario != -1)
            {
                Helper.Sessao.CodFuncionario_Redefinicao = CodFuncionario;
                return RedirectToRoute("Alteracao");
            }
            else
            {
                TempData["MensagemErro"] = "CPF inválido, tente novamente!";
            }

            return RedirectToRoute("Redefinicao");
        }

        [HttpPost]
        public ActionResult Alteracao_Redefinir(string PrimeiraSenha, string SegundaSenha)
        {
            Models.LoginModel modelLogin = new Models.LoginModel();

            if (PrimeiraSenha == SegundaSenha)
            {
                string RetornoMensagem = modelLogin.RedefinirSenha(PrimeiraSenha);
                TempData["MensagemErro"] = RetornoMensagem;

                if (RetornoMensagem == "Senha alterada com sucesso!")
                {
                    return RedirectToRoute("Default");
                }
                else
                {
                    return RedirectToRoute("Redefinicao");
                }
            }
            else
            {
                TempData["MensagemErro"] = "A confirmação de senha precisa ser igual!";
            }

            return RedirectToRoute("Alteracao");
        }
    }
}