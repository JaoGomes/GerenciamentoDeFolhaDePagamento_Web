using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace GerenciamentoDeFolhaDePagamento.Models
{
    public class Layout
    {
        public string PegarNomeFuncionario(int CodFuncionario)
        {
            string sqlPegarNomeFuncionario = "SELECT Nome FROM funcionario WHERE CodFuncionario = " + CodFuncionario.ToString();
            string NomeFuncionario = string.Empty;

            ConexaoModel modelConexao = new ConexaoModel();
            MySqlCommand cmdPegarNomeFuncionario = new MySqlCommand();

            cmdPegarNomeFuncionario.Connection = modelConexao.AbrirConexaoBD();
            cmdPegarNomeFuncionario.CommandText = sqlPegarNomeFuncionario;

            try
            {
                NomeFuncionario = cmdPegarNomeFuncionario.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                NomeFuncionario = "Erro ao exibir nome! Erro: " + e.Message.ToString();
            }

            return NomeFuncionario;
        }
    }
}