using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GerenciamentoDeFolhaDePagamento.Controllers
{
    public class Conexao
    {
        private MySqlConnection ConexaoBD()
        {
            string ConexaoString = "Server=localhost;Database=GoodPlace;Uid=root;Pwd=root;";

            MySqlConnection ConexaoBD = new MySqlConnection();
            ConexaoBD.ConnectionString = ConexaoString;

            return ConexaoBD;
        }

        public MySqlConnection AbrirConexao()
        {
            ConexaoBD().Open();
            return ConexaoBD();
        }

        public void FecharConexao()
        {
            ConexaoBD().Close();
        }
    }
}