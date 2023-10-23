using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Mvc;

namespace GerenciamentoDeFolhaDePagamento.Controllers
{
    public class ConsultaModel : Controller
    {
        public void Main()
        {
            
        }

        public int ValidarUsuario(string Email, string Senha)
        {
            int CodFuncionario = -1;
            string sqlValidarUsuario = "SELECT CodFuncionario FROM funcionario WHERE Email = '" + Email + "' AND Senha = '" + Senha + "';";

            ConexaoModel modelConexao = new ConexaoModel();

            MySqlCommand cmdValidarUsuario = new MySqlCommand();
            cmdValidarUsuario.Connection = modelConexao.AbrirConexaoBD();

            try
            {
                cmdValidarUsuario.CommandText = sqlValidarUsuario;
                if (cmdValidarUsuario.ExecuteScalar().ToString() != "-1")
                {
                    CodFuncionario = int.Parse(cmdValidarUsuario.ExecuteScalar().ToString());
                    modelConexao.FecharConexaoBD();
                }
            }
            catch(Exception e)
            {
                CodFuncionario = -1;
            }

            return CodFuncionario;
        }

        public DataTable PegarPontoFuncionario(int CodFuncionario)
        {
            string sqlPegarPontoFuncionario = "SELECT * FROM ponto WHERE CodFuncionario = " + CodFuncionario;
            string DataPonto = string.Empty;
            string SemanaPonto = string.Empty;
            string HoraEntrada = string.Empty;
            string HoraPausa = string.Empty;
            string HoraRetorno = string.Empty;
            string HoraSaida = string.Empty;
            string Total = string.Empty;
            DataTable TabelaPontoFuncionario = new DataTable();

            MySqlCommand cmdPegarPontoFuncionario = new MySqlCommand();
            cmdPegarPontoFuncionario.CommandText = sqlPegarPontoFuncionario;

            ConexaoModel modelConexao = new ConexaoModel();
            cmdPegarPontoFuncionario.Connection = modelConexao.AbrirConexaoBD();

            MySqlDataAdapter adapterPontoFuncionario = new MySqlDataAdapter();
            adapterPontoFuncionario.SelectCommand = cmdPegarPontoFuncionario;

            adapterPontoFuncionario.Fill(TabelaPontoFuncionario);
            modelConexao.FecharConexaoBD();

            return TabelaPontoFuncionario;
        }

        public string PegarNomeFuncionario(int CodFuncionario)
        {
            string NomeFuncionario = string.Empty;
            string sqlNomeFuncionario = "SELECT Nome FROM funcionario WHERE CodFuncionario = " + CodFuncionario;

            MySqlCommand cmdNomeFuncionario = new MySqlCommand();
            cmdNomeFuncionario.CommandText = sqlNomeFuncionario;

            ConexaoModel modelConexao = new ConexaoModel();
            cmdNomeFuncionario.Connection = modelConexao.AbrirConexaoBD();

            NomeFuncionario = cmdNomeFuncionario.ExecuteScalar().ToString();
            return NomeFuncionario;
        }
    }
}