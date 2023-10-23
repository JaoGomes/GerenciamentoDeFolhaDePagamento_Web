using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.Mvc;

namespace GerenciamentoDeFolhaDePagamento.Models
{
    public class HomeModel
    {
        public string CadastrarPonto(int TipoCadastro)
        {
            /*
                1 = Entrada
                2 = Pausa
                3 = Retorno
                4 = Saida
            */
            string sqlCadastroPonto = string.Empty;

            //Entrada
            if(TipoCadastro == 1)
            {
                //Caso tenha feito nada de cadastro
                if(Helper.Sessao.SituacaoCadastroPonto == 0)
                {
                    string Data = DateTime.Now.ToShortDateString();
                    string DataLonga = DateTime.Now.ToLongDateString();
                    string Semana = string.Empty;
                    string Entrada = DateTime.Now.ToShortTimeString();

                    for (int a = 0; DataLonga[a].ToString() != ","; a++)
                    {
                        Semana += DataLonga[a].ToString();
                    }

                    sqlCadastroPonto = "insert into ponto (CodFuncionario, DataPonto, SemanaPonto, HoraEntrada, HoraPausa, HoraRetorno, HoraSaida, Total) values(" + Helper.Sessao.CodFuncionario.ToString() + ", '" + Data + "', '" + Semana.ToUpper() + "', '" + Entrada + "', 'xx:xx', 'xx:xx', 'xx:xx', 0);";

                    try
                    {
                        Controllers.ConexaoModel modelConexao = new Controllers.ConexaoModel();
                        MySqlCommand cmdCadastrarPonto = new MySqlCommand();
                        cmdCadastrarPonto.Connection = modelConexao.AbrirConexaoBD();
                        cmdCadastrarPonto.CommandText = sqlCadastroPonto;
                        cmdCadastrarPonto.ExecuteNonQuery();
                        modelConexao.FecharConexaoBD();
                        Helper.Sessao.SituacaoCadastroPonto += 1;
                        return "Cadastrado!";
                    }
                    catch (Exception e)
                    {
                        return "Erro ao tentar salvar a Entrada! Erro: " + e.Message.ToString();
                    }
                }
            }
            //Pausa
            else if(TipoCadastro == 2)
            {
                //Caso já tenha feito a Entrada
                if (Helper.Sessao.SituacaoCadastroPonto == 1)
                {
                    string Pausa = DateTime.Now.ToShortTimeString();
                    sqlCadastroPonto = "update ponto set HoraPausa = '" + Pausa + "' order by CodPonto desc limit 1;";

                    try
                    {
                        Controllers.ConexaoModel modelConexao = new Controllers.ConexaoModel();
                        MySqlCommand cmdCadastrarPonto = new MySqlCommand();
                        cmdCadastrarPonto.Connection = modelConexao.AbrirConexaoBD();
                        cmdCadastrarPonto.CommandText = sqlCadastroPonto;
                        cmdCadastrarPonto.ExecuteNonQuery();
                        modelConexao.FecharConexaoBD();
                        Helper.Sessao.SituacaoCadastroPonto += 1;
                        return "Cadastrado!";
                    }
                    catch (Exception e)
                    {
                        return "Erro ao tentar salvar a Pausa! Erro: " + e.Message.ToString();
                    }
                }
            }
            //Retorno
            else if(TipoCadastro == 3)
            {
                //Caso já tenha feito a Pausa
                if (Helper.Sessao.SituacaoCadastroPonto == 2)
                {
                    string Retorno = DateTime.Now.ToShortTimeString();
                    sqlCadastroPonto = "update ponto set HoraRetorno = '" + Retorno + "' order by CodPonto desc limit 1;";

                    try
                    {
                        Controllers.ConexaoModel modelConexao = new Controllers.ConexaoModel();
                        MySqlCommand cmdCadastrarPonto = new MySqlCommand();
                        cmdCadastrarPonto.Connection = modelConexao.AbrirConexaoBD();
                        cmdCadastrarPonto.CommandText = sqlCadastroPonto;
                        cmdCadastrarPonto.ExecuteNonQuery();
                        modelConexao.FecharConexaoBD();
                        Helper.Sessao.SituacaoCadastroPonto += 1;
                        return "Cadastrado!";
                    }
                    catch (Exception e)
                    {
                        return "Erro ao tentar salvar o Retorno! Erro: " + e.Message.ToString();
                    }
                }
            }
            //Saida
            else if(TipoCadastro == 4)
            {
                //Caso já tenha feito o Retorno
                if (Helper.Sessao.SituacaoCadastroPonto == 3)
                {
                    string Saida = DateTime.Now.ToShortTimeString();
                    string Total = "0";
                    sqlCadastroPonto = "update ponto set HoraSaida = '" + Saida + "', Total = " + Total + " order by CodPonto desc limit 1;";

                    try
                    {
                        Controllers.ConexaoModel modelConexao = new Controllers.ConexaoModel();
                        MySqlCommand cmdCadastrarPonto = new MySqlCommand();
                        cmdCadastrarPonto.Connection = modelConexao.AbrirConexaoBD();
                        cmdCadastrarPonto.CommandText = sqlCadastroPonto;
                        cmdCadastrarPonto.ExecuteNonQuery();
                        modelConexao.FecharConexaoBD();
                        Helper.Sessao.SituacaoCadastroPonto = 0;
                        return "Cadastrado!";
                    }
                    catch (Exception e)
                    {
                        return "Erro ao tentar salvar a Saida! Erro: " + e.Message.ToString();
                    }
                }
            }

            /*
                0 = Nenhum Cadastro
                1 = Entrada
                2 = Pausa
                3 = Retorno
                4 = Saida
            */
            //Mensagem Personalizada caso não seja possível cadastrar por causa de outro cadastro em espera
            if(Helper.Sessao.SituacaoCadastroPonto == 0)
            {
                return "Precisa clicar no botão 'Entrada'!";
            }
            else if(Helper.Sessao.SituacaoCadastroPonto == 1)
            {
                return "Precisa clicar no botão 'Pausa'!";
            }
            else if(Helper.Sessao.SituacaoCadastroPonto == 2)
            {
                return "Precisa clicar no botão 'Retorno'!";
            }
            else if(Helper.Sessao.SituacaoCadastroPonto == 3)
            {
                return "Precisa clicar no botão 'Saida'!";
            }
            else
            {
                return "Algo de errado não está certo!";
            }
        }
    }
}