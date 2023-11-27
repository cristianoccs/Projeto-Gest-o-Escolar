using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Scolastic.Dados_Dal;
using System.Data;
using Scolastic.Modelos;
using System.Configuration;

namespace Scolastic.Dados_Dal
{
    public class AlunoDAL
    {

        public void D_Incluir(AlunoInformation Aluno)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_ALUNO";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_ALUNO", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);


                SqlParameter pnome = new SqlParameter("@NM_ALUNO", SqlDbType.NVarChar, 60);
                pnome.Value = Aluno._aluno;
                cmd.Parameters.Add(pnome);

                SqlParameter pcpf_aluno = new SqlParameter("@CPF_ALUNO", SqlDbType.NVarChar, 60);
                pcpf_aluno.Value = Aluno.cpf;
                cmd.Parameters.Add(pcpf_aluno);

                SqlParameter prg_aluno = new SqlParameter("@RG_ALUNO", SqlDbType.NVarChar, 60);
                prg_aluno.Value = Aluno.rg;
                cmd.Parameters.Add(prg_aluno);

                SqlParameter psexo_aluno = new SqlParameter("@SEXO_ALUNO", SqlDbType.NVarChar, 60);
                psexo_aluno.Value = Aluno.sexo;
                cmd.Parameters.Add(psexo_aluno);


                SqlParameter pnm_cidade = new SqlParameter("@NM_CIDADE", SqlDbType.NVarChar, 60);
                pnm_cidade.Value = Aluno.cidade;
                cmd.Parameters.Add(pnm_cidade);

                SqlParameter pend_cidade = new SqlParameter("@END_CIDADE", SqlDbType.NVarChar, 60);
                pend_cidade.Value = Aluno.end_cid;
                cmd.Parameters.Add(pend_cidade);


                SqlParameter pend_bairro = new SqlParameter("@END_BAIRRO", SqlDbType.NVarChar, 60);
                pend_bairro.Value = Aluno.end_bair;
                cmd.Parameters.Add(pend_bairro);

                SqlParameter pcep_cidade = new SqlParameter("@CEP_CIDADE", SqlDbType.NVarChar, 60);
                pcep_cidade.Value = Aluno.cep;
                cmd.Parameters.Add(pcep_cidade);


                SqlParameter ptelefone = new SqlParameter("@NR_TELEFONE", SqlDbType.NVarChar, 60);
                ptelefone.Value = Aluno.telefone;
                cmd.Parameters.Add(ptelefone);

                SqlParameter pemail = new SqlParameter("@DS_EMAIL", SqlDbType.NVarChar, 60);
                pemail.Value = Aluno.email;
                cmd.Parameters.Add(pemail);

                SqlParameter pnascimento = new SqlParameter("@DT_NASCIMENTO", SqlDbType.DateTime);
                pnascimento.Value = Aluno.nascimento;
                cmd.Parameters.Add(pnascimento);


                cn.Open();
                cmd.ExecuteNonQuery();
                Aluno.cd_aluno = (Int32)cmd.Parameters["@PK_CD_ALUNO"].Value;






            }

            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL erro: camdad Dall" + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                cn.Close();
            }

        }

        public void D_Alterar(AlunoInformation Aluno)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERA_ALUNO";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_ALUNO", SqlDbType.Int);
                pcodigo.Value = Aluno.cd_aluno;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@NM_ALUNO", SqlDbType.NVarChar, 60);
                pnome.Value = Aluno._aluno;
                cmd.Parameters.Add(pnome);

                SqlParameter pnacimento = new SqlParameter("@DT_NASCIMENTO", SqlDbType.DateTime);
                pnacimento.Value = Aluno.nascimento;
                cmd.Parameters.Add(pnacimento);

                SqlParameter prg_aluno = new SqlParameter("@RG_ALUNO", SqlDbType.NVarChar, 60);
                prg_aluno.Value = Aluno.rg;
                cmd.Parameters.Add(prg_aluno);

                SqlParameter pcpf_aluno = new SqlParameter("@CPF_ALUNO", SqlDbType.NVarChar, 60);
                pcpf_aluno.Value = Aluno.cpf;
                cmd.Parameters.Add(pcpf_aluno);

                SqlParameter psexo_aluno = new SqlParameter("@SEXO_ALUNO", SqlDbType.NVarChar, 25);
                psexo_aluno.Value = Aluno.sexo;
                cmd.Parameters.Add(psexo_aluno);

                SqlParameter pnm_cidade = new SqlParameter("@NM_CIDADE", SqlDbType.NVarChar, 60);
                pnm_cidade.Value = Aluno.cidade;
                cmd.Parameters.Add(pnm_cidade);

                SqlParameter pend_cidade = new SqlParameter("@END_CIDADE", SqlDbType.NVarChar, 60);
                pend_cidade.Value = Aluno.end_cid;
                cmd.Parameters.Add(pend_cidade);

                SqlParameter pend_bairro = new SqlParameter("@END_BAIRRO", SqlDbType.NVarChar, 60);
                pend_bairro.Value = Aluno.end_bair;
                cmd.Parameters.Add(pend_bairro);


                SqlParameter pcep_cidade = new SqlParameter("@CEP_CIDADE", SqlDbType.NVarChar, 60);
                pcep_cidade.Value = Aluno.cep;
                cmd.Parameters.Add(pcep_cidade);

                SqlParameter ptelefone = new SqlParameter("@NR_TELEFONE", SqlDbType.NVarChar, 60);
                ptelefone.Value = Aluno.telefone;
                cmd.Parameters.Add(ptelefone);

                SqlParameter pemail = new SqlParameter("@DS_EMAIL", SqlDbType.NVarChar, 60);
                pemail.Value = Aluno.email;
                cmd.Parameters.Add(pemail);



                cn.Open();
                cmd.ExecuteNonQuery();
                Aluno.cd_aluno = (Int32)cmd.Parameters["@PK_CD_ALUNO"].Value;

            }

            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL erro: " + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                cn.Close();
            }

        }

        public void Exluir(int CD_aluno)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "EXCLUI_ALUNO";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_ALUNO", SqlDbType.Int);
                pcodigo.Value = CD_aluno;
                cmd.Parameters.Add(pcodigo);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o cliente" + CD_aluno);
                }
            }

            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL erro: " + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                cn.Close();
            }

        }

        public DataTable Listagem(string filtro)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "SELECIONA_ALUNO";
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("@FILTRO", SqlDbType.Text);
                pfiltro.Value = filtro;

                da.Fill(dt);
                return dt;
            }

            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL erro: " + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                cn.Close();
            }
        }

        public DataTable selec_n () {


            SqlConnection con = new SqlConnection();

            con.ConnectionString = Conexao.StringDeConexao;
            SqlCommand cmd = new SqlCommand("SP_LISTA_ALUNO", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

    }
}

