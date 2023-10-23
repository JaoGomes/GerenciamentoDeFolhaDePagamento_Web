using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeFolhaDePagamento.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}