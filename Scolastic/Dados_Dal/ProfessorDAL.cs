using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scolastic.Modelos;
using Scolastic.Dados_Dal;
using Modelos;

namespace Scolastic.Dados_Dal
{
    public class ProfessorDAL
    {
        public void Incluir(ProfessorInformation pprofessor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_PROFESSOR";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_PROFESSOR", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnm_professor = new SqlParameter("@NM_PROFESSOR", SqlDbType.NVarChar, 60);
                pnm_professor.Value = pprofessor._professor;
                cmd.Parameters.Add(pnm_professor);

                SqlParameter pnacimento = new SqlParameter("@DT_NASCIMENTO", SqlDbType.DateTime);
                pnacimento.Value = pprofessor.nascimento;
                cmd.Parameters.Add(pnacimento);

                SqlParameter prg_professor = new SqlParameter("@RG_PROFESSOR", SqlDbType.NVarChar, 60);
                prg_professor.Value = pprofessor.rg;
                cmd.Parameters.Add(prg_professor);

                SqlParameter pcpf_professor = new SqlParameter("@CPF_PROFESSOR", SqlDbType.NVarChar, 60);
                pcpf_professor.Value = pprofessor.cpf;
                cmd.Parameters.Add(pcpf_professor);

                SqlParameter psexo_professor = new SqlParameter("@SEXO_PROFESSOR", SqlDbType.Char);
                psexo_professor.Value = pprofessor.sexo;
                cmd.Parameters.Add(psexo_professor);

                SqlParameter pnm_cidade = new SqlParameter("@NM_CIDADE", SqlDbType.NVarChar, 60);
                pnm_cidade.Value = pprofessor.cidade;
                cmd.Parameters.Add(pnm_cidade);

                SqlParameter pend_cidade = new SqlParameter("@END_CIDADE", SqlDbType.NVarChar, 60);
                pend_cidade.Value = pprofessor.end_cid;
                cmd.Parameters.Add(pend_cidade);

                SqlParameter pend_bairro = new SqlParameter("@END_BAIRRO", SqlDbType.NVarChar, 60);
                pend_bairro.Value = pprofessor.end_bair;
                cmd.Parameters.Add(pend_bairro);


                SqlParameter pcep_cidade = new SqlParameter("@CEP_CIDADE", SqlDbType.NVarChar, 60);
                pcep_cidade.Value = pprofessor.cep;
                cmd.Parameters.Add(pcep_cidade);

                SqlParameter ptelefone = new SqlParameter("@NR_TELEFONE", SqlDbType.NVarChar, 60);
                ptelefone.Value = pprofessor.telefone;
                cmd.Parameters.Add(ptelefone);

                SqlParameter pt_academico = new SqlParameter("@TITULO_ACADEMICO", SqlDbType.NVarChar, 60);
                pt_academico.Value = pprofessor.t_academico;
                cmd.Parameters.Add(pt_academico);


                SqlParameter pemail = new SqlParameter("@DS_EMAIL", SqlDbType.NVarChar, 60);
                pemail.Value = pprofessor.email;
                cmd.Parameters.Add(pemail);


                cn.Open();
                cmd.ExecuteNonQuery();
                pprofessor.cd_professor = (Int32)cmd.Parameters["@PK_CD_PROFESSOR"].Value;
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

        public void Alterar(ProfessorInformation pprofessor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERA_PROFESSOR";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_PROFESSOR", SqlDbType.Int);
                pcodigo.Value = pprofessor.cd_professor;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnm_professor = new SqlParameter("@NM_PROFESSOR", SqlDbType.NVarChar, 60);
                pnm_professor.Value = pprofessor._professor;
                cmd.Parameters.Add(pnm_professor);

                SqlParameter pnacimento = new SqlParameter("@DT_NASCIMENTO", SqlDbType.DateTime);
                pnacimento.Value = pprofessor.nascimento;
                cmd.Parameters.Add(pnacimento);

                SqlParameter prg_professor = new SqlParameter("@RG_PROFESSOR", SqlDbType.NVarChar, 60);
                prg_professor.Value = pprofessor.rg;
                cmd.Parameters.Add(prg_professor);

                SqlParameter pcpf_professor = new SqlParameter("@CPF_PROFESSOR", SqlDbType.NVarChar, 60);
                pcpf_professor.Value = pprofessor.cpf;
                cmd.Parameters.Add(pcpf_professor);

                SqlParameter psexo_professor = new SqlParameter("@SEXO_PROFESSOR", SqlDbType.Char);
                psexo_professor.Value = pprofessor.sexo;
                cmd.Parameters.Add(psexo_professor);

                SqlParameter pnm_cidade = new SqlParameter("@NM_CIDADE", SqlDbType.NVarChar, 60);
                pnm_cidade.Value = pprofessor.cidade;
                cmd.Parameters.Add(pnm_cidade);

                SqlParameter pend_cidade = new SqlParameter("@END_CIDADE", SqlDbType.NVarChar, 60);
                pend_cidade.Value = pprofessor.end_cid;
                cmd.Parameters.Add(pend_cidade);

                SqlParameter pend_bairro = new SqlParameter("@END_BAIRRO", SqlDbType.NVarChar, 60);
                pend_bairro.Value = pprofessor.end_bair;
                cmd.Parameters.Add(pend_bairro);


                SqlParameter pcep_cidade = new SqlParameter("@CEP_CIDADE", SqlDbType.NVarChar, 60);
                pcep_cidade.Value = pprofessor.cep;
                cmd.Parameters.Add(pcep_cidade);

                SqlParameter ptelefone = new SqlParameter("@NR_TELEFONE", SqlDbType.NVarChar, 60);
                ptelefone.Value = pprofessor.telefone;
                cmd.Parameters.Add(ptelefone);

                SqlParameter pt_academico = new SqlParameter("@TITULO_ACADEMICO", SqlDbType.NVarChar, 60);
                pt_academico.Value = pprofessor.t_academico;
                cmd.Parameters.Add(pt_academico);

                SqlParameter pemail = new SqlParameter("@DS_EMAIL", SqlDbType.NVarChar, 60);
                pemail.Value = pprofessor.email;
                cmd.Parameters.Add(pemail);



                cn.Open();
                cmd.ExecuteNonQuery();
                pprofessor.cd_professor = (Int32)cmd.Parameters["@PK_CD_PROFESSOR"].Value;
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

        public void Excluir(int cd_prefessor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "EXCLUI_PROFESSOR";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_PROFESSOR", SqlDbType.Int);
                pcodigo.Value = cd_prefessor;
                cmd.Parameters.Add(pcodigo);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o PROFESSOR" + cd_prefessor);
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
                da.SelectCommand.CommandText = "SELECIONA_PROFESSOR";
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
    }
}
