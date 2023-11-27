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
    public class CursoDAL
    {
        public void Incluir(CursoInformation pcurso)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_CURSO";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_CURSO", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnm_curso = new SqlParameter("@NM_CURSO", SqlDbType.NVarChar, 60);
                pnm_curso.Value = pcurso._curso;
                cmd.Parameters.Add(pnm_curso);

                SqlParameter pduracao_curso = new SqlParameter("@DURACAO_CURSO_TOTAL", SqlDbType.NVarChar, 60);
                pduracao_curso.Value = pcurso.duracao_curso;
                cmd.Parameters.Add(pduracao_curso);




                cn.Open();
                cmd.ExecuteNonQuery();
                pcurso.cd_curso = (Int32)cmd.Parameters["@PK_CD_CURSO"].Value;
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

        public void Alterar(CursoInformation pcurso)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERA_CURSO";



                SqlParameter pcodigo = new SqlParameter("@PK_CD_CURSO", SqlDbType.Int);
                pcodigo.Value = pcurso.cd_curso;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnm_curso = new SqlParameter("@NM_CURSO", SqlDbType.NVarChar, 60);
                pnm_curso.Value = pcurso._curso;
                cmd.Parameters.Add(pnm_curso);

                SqlParameter pduracao_curso = new SqlParameter("@DURACAO_CURSO_TOTAL", SqlDbType.NVarChar, 60);
                pduracao_curso.Value = pcurso.duracao_curso;
                cmd.Parameters.Add(pduracao_curso);



                cn.Open();
                cmd.ExecuteNonQuery();
                pcurso.cd_curso = (Int32)cmd.Parameters["@PK_CD_CURSO"].Value;
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

        public void Exluir(int CD_CURSO)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "EXCLUI_CURSO";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_CURSO", SqlDbType.Int);
                pcodigo.Value = CD_CURSO;
                cmd.Parameters.Add(pcodigo);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o cliente" + CD_CURSO);
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
                da.SelectCommand.CommandText = "SELECIONA_CURSO";
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
