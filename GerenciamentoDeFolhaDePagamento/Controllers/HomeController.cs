using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace GerenciamentoDeFolhaDePagamento.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            int CodFuncionario = Helper.Sessao.CodFuncionario;

            if(CodFuncionario != -1)
            {
                Models.HomeModel modelHome = new Models.HomeModel();
                ViewBag.TabelaPontoFuncionario = modelHome.PegarPontoFuncionario(CodFuncionario);

                return View();
            }
            TempData["MensagemErro"] = "Faça Login!";
            return RedirectToRoute("Default");
        }

        public ActionResult Entrada()
        {
            // 1 = Entrada

            Models.HomeModel modelHome = new Models.HomeModel();
            string mensagemEntrada = modelHome.CadastrarPonto(1);

            if(mensagemEntrada != "Cadastrado!")
            {
                TempData["MensagemErro"] = mensagemEntrada;
            }
            return RedirectToRoute("Home");
        }

        public ActionResult Pausa()
        {
            // 2 = Pausa

            Models.HomeModel modelHome = new Models.HomeModel();
            string mensagemPausa = modelHome.CadastrarPonto(2);

            if (mensagemPausa != "Cadastrado!")
            {
                TempData["MensagemErro"] = mensagemPausa;
            }
            return RedirectToRoute("Home");
        }

        public ActionResult Retorno()
        {
            // 3 = Retorno

            Models.HomeModel modelHome = new Models.HomeModel();
            string mensagemRetorno = modelHome.CadastrarPonto(3);

            if (mensagemRetorno != "Cadastrado!")
            {
                TempData["MensagemErro"] = mensagemRetorno;
            }
            return RedirectToRoute("Home");
        }

        public ActionResult Saida()
        {
            // 4 = Saida

            Models.HomeModel modelHome = new Models.HomeModel();
            string mensagemSaida = modelHome.CadastrarPonto(4);

            if (mensagemSaida != "Cadastrado!")
            {
                TempData["MensagemErro"] = mensagemSaida;
            }
            return RedirectToRoute("Home");
        }

        public ActionResult Sair()
        {
            Helper.Sessao.CodFuncionario = -1;
            Helper.Sessao.CodFuncionario_Redefinicao = -1;
            return RedirectToRoute("Default");
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