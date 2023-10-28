using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace GerenciamentoDeFolhaDePagamento.Models
{
    public class ConexaoModel
    {
        private string ConexaoString = "Persist Security Info=False;server=localhost;database=GoodPlace;uid=root;pwd=root";
        public string Mensagem = "";

        MySqlConnection connConexaoBD = new MySqlConnection();

        public MySqlConnection AbrirConexaoBD()
        {
            this.Mensagem = "";
        
            try
            {
                this.connConexaoBD.ConnectionString = ConexaoString;
                this.connConexaoBD.Open();
            }
            catch(Exception e)
            {
                Mensagem = "Erro [Abrir Conexao] - " + e.Message;
            }

            return this.connConexaoBD;
        }

        public void FecharConexaoBD()
        {
            this.Mensagem = "";

            try
            {
                this.connConexaoBD.Close();
            }
            catch(Exception e)
            {
                Mensagem = "Erro [Fechar Conexao] - " + e.Message;
            }
        }
    }
}