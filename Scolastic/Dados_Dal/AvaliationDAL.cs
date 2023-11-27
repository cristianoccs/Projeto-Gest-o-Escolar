using Scolastic.Modelos;
using Scolastic.Dados_Dal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Dados_Dal
{
    public class AvaliationDAL
    {
        public void Incluir(AvaliationInformation aval)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_AVALIATION";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_AVALIATION", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

              //  SqlParameter pnota = new SqlParameter("@NOTA", SqlDbType.Float);
              //  pnota.Value = aval.nota_aluno;
              //  cmd.Parameters.Add(pnota);

                SqlParameter pdat = new SqlParameter("@DAT", SqlDbType.DateTime);
                pdat.Value = aval.data_aval;
                cmd.Parameters.Add(pdat);

                SqlParameter pfrequencia = new SqlParameter("@FREQUNCIA", SqlDbType.Char);
                pfrequencia.Value = aval.frequencia;
                cmd.Parameters.Add(pfrequencia);

                SqlParameter fk_aluno = new SqlParameter("@FKI_CD_MATRICULA", SqlDbType.Int);
                fk_aluno.Value = aval.cd_Matricula;
                cmd.Parameters.Add(fk_aluno);

                SqlParameter fk_disciplina = new SqlParameter("@FKI_CD_DISCIPLINA", SqlDbType.Int);
                fk_disciplina.Value = aval.cd_disciplina;
                cmd.Parameters.Add(fk_disciplina);

               // SqlParameter fk_professor = new SqlParameter("@FKI_CD_PROFESSOR", SqlDbType.Int);
               // fk_professor.Value = aval.cd_professor;
               // cmd.Parameters.Add(fk_professor);


                cn.Open();
                cmd.ExecuteNonQuery();
                aval.cd_avaliation = (Int32)cmd.Parameters["@PK_CD_AVALIATION"].Value;


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

        public void Alterar(AvaliationInformation aval)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERA_AVALIATION";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_AVALIATION", SqlDbType.Int);
                pcodigo.Value = aval.cd_avaliation;
                cmd.Parameters.Add(pcodigo);

                //SqlParameter pnota = new SqlParameter("@NOTA", SqlDbType.Float);
                //pnota.Value = aval.nota_aluno;
                //cmd.Parameters.Add(pnota);

                SqlParameter pdat = new SqlParameter("@DAT", SqlDbType.DateTime);
                pdat.Value = aval.data_aval;
                cmd.Parameters.Add(pdat);

                SqlParameter pfrequencia = new SqlParameter("@FREQUNCIA", SqlDbType.Char);
                pfrequencia.Value = aval.frequencia;
                cmd.Parameters.Add(pfrequencia);

                SqlParameter fk_aluno = new SqlParameter("@FKI_CD_MATRICULA", SqlDbType.Int);
                fk_aluno.Value = aval.cd_Matricula;
                cmd.Parameters.Add(fk_aluno);

                SqlParameter fk_disciplina = new SqlParameter("@FKI_CD_DISCIPLINA", SqlDbType.Int);
                fk_disciplina.Value = aval.cd_disciplina;
                cmd.Parameters.Add(fk_disciplina);

                //SqlParameter fk_professor = new SqlParameter("@FKI_CD_PROFESSOR", SqlDbType.Int);
                //fk_professor.Value = aval.cd_professor;
               // cmd.Parameters.Add(fk_professor);


                cn.Open();
                cmd.ExecuteNonQuery();
                aval.cd_avaliation = (Int32)cmd.Parameters["@PK_CD_AVALIATION"].Value;


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

        public void Excluir(int CD_aluno)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "EXCLUI_AVALIATION";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_AVALIATION", SqlDbType.Int);
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
                da.SelectCommand.CommandText = "SELECIONA_AVALIATION";
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

        public DataTable Listageml(string filtro)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "SELECIONA_AVALIATIONL";
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

    }   }
}
