using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace GerenciamentoDeFolhaDePagamento.Models
{
    public class LoginModel
    {
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
            catch (Exception e)
            {
                CodFuncionario = -1;
            }

            return CodFuncionario;
        }

        public int ValidarCpf(string Cpf)
        {
            int CodFuncionario = -1;
            string sqlValidarUsuario = "SELECT CodFuncionario FROM funcionario WHERE Cpf = '" + Cpf + "';";

            ConexaoModel modelConexao = new ConexaoModel();
            MySqlCommand cmdValidarUsuario = new MySqlCommand();

            try
            {
                cmdValidarUsuario.Connection = modelConexao.AbrirConexaoBD();
                cmdValidarUsuario.CommandText = sqlValidarUsuario;
                if (cmdValidarUsuario.ExecuteScalar().ToString() != "-1")
                {
                    CodFuncionario = int.Parse(cmdValidarUsuario.ExecuteScalar().ToString());
                    modelConexao.FecharConexaoBD();
                }
            }
            catch (Exception e)
            {
                CodFuncionario = -1;
            }

            return CodFuncionario;
        }

        public string RedefinirSenha(string Senha)
        {
            /*
                0 = Sem Solicitação
                1 = Solicitado
                2 = Solitacao Aceita
            */

            string RetornoMensagem = string.Empty;
            string sqlRedefinirSenha = "update funcionario set Senha = '" + Senha + "' where CodFuncionario = " + Helper.Sessao.CodFuncionario_Redefinicao + ";";

            MySqlCommand cmdRedefinirSenha = new MySqlCommand();
            ConexaoModel modelConexao = new ConexaoModel();

            try
            {
                cmdRedefinirSenha.Connection = modelConexao.AbrirConexaoBD();
                cmdRedefinirSenha.CommandText = sqlRedefinirSenha;
                cmdRedefinirSenha.ExecuteNonQuery();
                modelConexao.FecharConexaoBD();
                RetornoMensagem = "Senha alterada com sucesso!";
            }
            catch (Exception e)
            {
                RetornoMensagem = "Ocorreu um erro ao salvar a senha! Erro: " + e.Message.ToString();
            }

            return RetornoMensagem;
        }
    }
}