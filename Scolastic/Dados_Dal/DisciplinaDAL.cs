using Scolastic.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scolastic.Dados_Dal;

namespace Scolastic.Dados_Dal
{
    public class DisciplinaDAL
    {
        public void Incluir(DisciplinaInformation pdisciplina)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_DISCIPLINA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_DISCIPLINA", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnm_disciplina = new SqlParameter("@NM_DISCIPLINA", SqlDbType.NVarChar, 100);
                pnm_disciplina.Value = pdisciplina._disciplina;
                cmd.Parameters.Add(pnm_disciplina);

                SqlParameter pcg_horaria_ds = new SqlParameter("@CARGA_HORARIA_DS", SqlDbType.NVarChar, 60);
                pcg_horaria_ds.Value = pdisciplina._horaria;
                cmd.Parameters.Add(pcg_horaria_ds);

                SqlParameter pfk_professor = new SqlParameter("@FK_CD_PROFESSOR", SqlDbType.Int);
                pfk_professor.Value = pdisciplina.cd_professor;
                cmd.Parameters.Add(pfk_professor);

                SqlParameter pfk_turma = new SqlParameter("@FKI_CD_TURMA", SqlDbType.Int);
                pfk_turma.Value = pdisciplina.cd_turma;
                cmd.Parameters.Add(pfk_turma);


                cn.Open();
                cmd.ExecuteNonQuery();
                pdisciplina.cd_disciplina = (Int32)cmd.Parameters["@PK_CD_DISCIPLINA"].Value;
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

        public void D_Alterar(DisciplinaInformation apdisciplina)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERA_DISCIPLINA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_DISCIPLINA", SqlDbType.Int);
                pcodigo.Value = apdisciplina.cd_disciplina ;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnm_disciplina = new SqlParameter("@NM_DISCIPLINA", SqlDbType.NVarChar, 100);
                pnm_disciplina.Value = apdisciplina._disciplina;
                cmd.Parameters.Add(pnm_disciplina);

                SqlParameter pcg_horaria_ds = new SqlParameter("@CARGA_HORARIA_DS", SqlDbType.NVarChar, 60);
                pcg_horaria_ds.Value = apdisciplina._horaria;
                cmd.Parameters.Add(pcg_horaria_ds);

                SqlParameter pfk_professor = new SqlParameter("@FK_CD_PROFESSOR", SqlDbType.Int);
                pfk_professor.Value = apdisciplina.cd_professor;
                cmd.Parameters.Add(pfk_professor);

                SqlParameter pfk_turma = new SqlParameter("@FKI_CD_TURMA", SqlDbType.Int);
                pfk_turma.Value = apdisciplina.cd_turma;
                cmd.Parameters.Add(pfk_turma);


                cn.Open();
                cmd.ExecuteNonQuery();
                apdisciplina.cd_disciplina = (Int32)cmd.Parameters["@PK_CD_DISCIPLINA"].Value;
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

        public void Exluir(int cd_disciplina)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "EXCLUI_DISCIPLINA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_DISCIPLINA", SqlDbType.Int);
                pcodigo.Value = cd_disciplina;
                cmd.Parameters.Add(pcodigo);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o disciplina" + cd_disciplina);
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
                da.SelectCommand.CommandText = "SELECIONA_DISCIPLINA";
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

        public DataTable Listageml(string filtro,int cd)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "SELECIONA_DISCIPLINAL";
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("@FILTRO", SqlDbType.Text);
                pfiltro.Value = filtro;

                SqlParameter pcd_professor;
                pcd_professor = da.SelectCommand.Parameters.Add("@FK_CD_PROFESSOR", SqlDbType.Int);
                pcd_professor.Value = cd;

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
