using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.Mvc;
using System.Data;

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

                    sqlCadastroPonto = "INSERT INTO ponto (CodFuncionario, DataPonto, SemanaPonto, HoraEntrada, HoraPausa, HoraRetorno, HoraSaida, Total) VALUES(" + Helper.Sessao.CodFuncionario.ToString() + ", '" + Data + "', '" + Semana.ToUpper() + "', '" + Entrada + "', 'xx:xx', 'xx:xx', 'xx:xx', 0);";

                    try
                    {
                        ConexaoModel modelConexao = new ConexaoModel();
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
                        //Mensagem de erro
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
                    sqlCadastroPonto = "UPDATE ponto SET HoraPausa = '" + Pausa + "' ORDER BY CodPonto DESC LIMIT 1;";

                    try
                    {
                        ConexaoModel modelConexao = new ConexaoModel();
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
                        //Mensagem de erro
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
                    sqlCadastroPonto = "UPDATE ponto SET HoraRetorno = '" + Retorno + "' ORDER BY CodPonto DESC LIMIT 1;";

                    try
                    {
                        ConexaoModel modelConexao = new ConexaoModel();
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
                        //Mensagem de erro
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
                    sqlCadastroPonto = "UPDATE ponto SET HoraSaida = '" + Saida + "', Total = " + Total + " ORDER BY CodPonto DESC LIMIT 1;";

                    try
                    {
                        ConexaoModel modelConexao = new ConexaoModel();
                        MySqlCommand cmdCadastrarPonto = new MySqlCommand();
                        cmdCadastrarPonto.Connection = modelConexao.AbrirConexaoBD();
                        cmdCadastrarPonto.CommandText = sqlCadastroPonto;
                        cmdCadastrarPonto.ExecuteNonQuery();
                        modelConexao.FecharConexaoBD();
                        Helper.Sessao.SituacaoCadastroPonto = 0;

                        if(CalcularTotalPonto() == "Cadastrado!")
                        {
                            return "Cadastrado!";
                        }
                        else
                        {
                            //Mensagem de erro
                            return "Erro [pegar horários de ponto]";
                        }
                    }
                    catch (Exception e)
                    {
                        //Mensagem de erro
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
                //Mensagem de erro
                return "Algo de errado não está certo!";
            }
        }

        public string CalcularTotalPonto()
        {
            int TotalPonto = 0;
            string HorarioEntrada, HorarioPausa, HorarioRetorno, HorarioSaida;
            int HorarioTrabalho, MinutoTrabalho;
            DataTable tabelaHorarioPonto = new DataTable();
            string sqlConsultaPonto = "SELECT HoraEntrada, HoraPausa, HoraRetorno, HoraSaida FROM Ponto ORDER BY CodPonto DESC LIMIT 1";

            ConexaoModel modelConexao = new ConexaoModel();
            MySqlCommand cmdCalcularTotalPonto = new MySqlCommand();
            MySqlDataAdapter adapterHorarioPonto = new MySqlDataAdapter();

            try
            {
                cmdCalcularTotalPonto.Connection = modelConexao.AbrirConexaoBD();
                cmdCalcularTotalPonto.CommandText = sqlConsultaPonto;
                adapterHorarioPonto.SelectCommand = cmdCalcularTotalPonto;
                adapterHorarioPonto.Fill(tabelaHorarioPonto);
                modelConexao.FecharConexaoBD();

                foreach (DataRow linhaTabelaHorarioPonto in tabelaHorarioPonto.Rows)
                {
                    //Pegando todos os horários
                    HorarioEntrada = linhaTabelaHorarioPonto["HoraEntrada"].ToString();
                    HorarioPausa = linhaTabelaHorarioPonto["HoraPausa"].ToString();
                    HorarioRetorno = linhaTabelaHorarioPonto["HoraRetorno"].ToString();
                    HorarioSaida = linhaTabelaHorarioPonto["HoraSaida"].ToString();

                    //Transformando em minuto e somando
                    TotalPonto = (SomarIntervalo(HorarioEntrada, HorarioPausa) + SomarIntervalo(HorarioRetorno, HorarioSaida));
                }

                //Cadastrando o Total de Ponto
                string sqlCadastroTotalPonto = "UPDATE ponto SET Total = " + TotalPonto.ToString() + " ORDER BY CodPonto DESC LIMIT 1;";
                MySqlCommand cmdCadastrarTotalPonto = new MySqlCommand();
                cmdCadastrarTotalPonto.Connection = modelConexao.AbrirConexaoBD();
                cmdCadastrarTotalPonto.CommandText = sqlCadastroTotalPonto;
                cmdCadastrarTotalPonto.ExecuteNonQuery();
                modelConexao.FecharConexaoBD();
                
                //Mensagem de aviso
                return "Cadastrado!";
            }
            catch (Exception e)
            {
                //Mensagem de erro
                return "Erro [pegar horários de ponto]";
            }
        }

        public int SomarIntervalo(string HorarioUm, string HorarioDois)
        {
            int TotalMinutos = 0;
            int intHoraPontoUm , intMinutoPontoUm;
            int intHoraPontoDois, intMinutoPontoDois;

            string HoraPontoUm = string.Empty, MinutoPontoUm = string.Empty;
            string HoraPontoDois = string.Empty, MinutoPontoDois = string.Empty;

            //Horario Um
            for (int a = 0; a <= 4; a++)
            {
                if(a <= 1)
                {
                    HoraPontoUm += HorarioUm[a];
                }
                else if (a >= 3)
                {
                    MinutoPontoUm += HorarioUm[a];
                }
            }

            //Horario Dois
            for (int a = 0; a <= 4; a++)
            {
                if (a <= 1)
                {
                    HoraPontoDois += HorarioDois[a];
                }
                else if (a >= 3)
                {
                    MinutoPontoDois += HorarioDois[a];
                }
            }

            intHoraPontoUm = int.Parse(HoraPontoUm);
            intHoraPontoDois = int.Parse(HoraPontoDois);
            intMinutoPontoUm = int.Parse(MinutoPontoUm);
            intMinutoPontoDois = int.Parse(MinutoPontoDois);

            TotalMinutos = ((intHoraPontoDois - intHoraPontoUm) * 60) + (intMinutoPontoDois - intMinutoPontoUm);
            return TotalMinutos;
        }

        public DataTable PegarPontoFuncionario(int CodFuncionario)
        {
            string sqlPegarPontoFuncionario = "SELECT * FROM ponto WHERE CodFuncionario = " + CodFuncionario + " ORDER BY CodPonto DESC;";
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
    }
}