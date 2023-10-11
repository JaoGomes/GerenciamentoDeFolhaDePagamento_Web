using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GerenciamentoDeFolhaDePagamento.Controllers
{
    public class Validar
    {
        public string Main()
        {
            string Teste = "select Nome from Funcionario limit 1";
            string Nome = string.Empty;

            Controllers.Conexao Conexao = new Conexao();

            MySqlCommand ComandoTeste = new MySqlCommand();
            ComandoTeste.Connection = Conexao.AbrirConexao(); 

            ComandoTeste.CommandText = Teste;
            Nome = ComandoTeste.ExecuteScalar().ToString();

            Conexao.FecharConexao();
            return Nome;
        }
    }
}