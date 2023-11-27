using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scolastic.Dados_Dal;

namespace Dados_Dal
{
    public class MatriculaDAL
    {
        public void Incluir(MatriculaInformation pmatricula)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_MATRICULA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_MATRICULA", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pfk_turma = new SqlParameter("@FK_CD_TURMA", SqlDbType.Int);
                pfk_turma.Value = pmatricula.cd_turma;
                cmd.Parameters.Add(pfk_turma);

                SqlParameter pfk_aluno = new SqlParameter("@FK_CD_ALUNO", SqlDbType.Int);
                pfk_aluno.Value = pmatricula.cd_aluno;
                cmd.Parameters.Add(pfk_aluno);

                SqlParameter pfk_curso = new SqlParameter("@FK_CD_CURSO", SqlDbType.Int);
                pfk_curso.Value = pmatricula.cd_curso;
                cmd.Parameters.Add(pfk_curso);

                SqlParameter nmaluno = new SqlParameter("@NM_ALUNOM", SqlDbType.VarChar);
                nmaluno.Value = pmatricula.NM_aluno;
                cmd.Parameters.Add(nmaluno);

                cn.Open();
                cmd.ExecuteNonQuery();
                pmatricula.cd_matricula = (Int32)cmd.Parameters["@PK_CD_MATRICULA"].Value;
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

        public void D_Alterar(MatriculaInformation apmatricula)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERA_MATRICULA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_MATRICULA", SqlDbType.Int);
                pcodigo.Value = apmatricula.cd_matricula;
                cmd.Parameters.Add(pcodigo);

                SqlParameter cd_alun = new SqlParameter("@FK_CD_ALUNO", SqlDbType.Int);
                cd_alun.Value = apmatricula.cd_aluno;
                cmd.Parameters.Add(cd_alun);

                SqlParameter cd_tur = new SqlParameter("@FK_CD_TURMA", SqlDbType.Int);
                cd_tur.Value = apmatricula.cd_turma;
                cmd.Parameters.Add(cd_tur);

                SqlParameter cd_cur = new SqlParameter("@FK_CD_CURSO", SqlDbType.Int);
                cd_cur.Value = apmatricula.cd_curso;
                cmd.Parameters.Add(cd_cur);

                SqlParameter nmaluno = new SqlParameter("@NM_ALUNOM", SqlDbType.VarChar);
                nmaluno.Value = apmatricula.NM_aluno;
                cmd.Parameters.Add(nmaluno);



                cn.Open();
                cmd.ExecuteNonQuery();
                apmatricula.cd_matricula = (Int32)cmd.Parameters["@PK_CD_MATRICULA"].Value;
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

        public void Excluir(int cd_matricula)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "EXCLUI_MATRICULA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_MATRICULA", SqlDbType.Int);
                pcodigo.Value = cd_matricula;
                cmd.Parameters.Add(pcodigo);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o CURSO" + cd_matricula);
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
                da.SelectCommand.CommandText = "SELECIONA_MATRICULA";
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
