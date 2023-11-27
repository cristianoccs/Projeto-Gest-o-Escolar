using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Scolastc.Modelos;

namespace Scolastic.Dados_Dal
{
    public class NotaDAL
    { 
        
        public void Incluir(NotaInformation noti)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_NOTA";

                SqlParameter pcodnota = new SqlParameter("@PK_CD_NOTA", SqlDbType.Int);
                pcodnota.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodnota);

                SqlParameter pnm_nota = new SqlParameter("@NOTA", SqlDbType.Float);
                pnm_nota.Value = noti.nota_aluno;
                cmd.Parameters.Add(pnm_nota);

                SqlParameter pdat = new SqlParameter("@DAT", SqlDbType.DateTime);
                pdat.Value = noti.data_aval;
                cmd.Parameters.Add(pdat);

                SqlParameter Fk_maticula = new SqlParameter("@FKII_CD_MATRICULA", SqlDbType.Int);
                Fk_maticula.Value = noti.cd_Matricula;
                cmd.Parameters.Add(Fk_maticula);

                SqlParameter Fk_disciplina = new SqlParameter("@FKIII_CD_DISCIPLINA", SqlDbType.Int);
                Fk_disciplina.Value = noti.cd_disciplina;
                cmd.Parameters.Add(Fk_disciplina);




                cn.Open();
                cmd.ExecuteNonQuery();
                noti.cd_Nota = (Int32)cmd.Parameters["@PK_CD_NOTA"].Value;
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

        public void Alterar(NotaInformation aval)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERA_NOTA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_NOTA", SqlDbType.Int);
                pcodigo.Value = aval.cd_Nota;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnota = new SqlParameter("@NOTA", SqlDbType.Float);
                pnota.Value = aval.nota_aluno;
                cmd.Parameters.Add(pnota);

                SqlParameter pdat = new SqlParameter("@DAT", SqlDbType.DateTime);
                pdat.Value = aval.data_aval;
                cmd.Parameters.Add(pdat);

               // SqlParameter pfrequencia = new SqlParameter("@FREQUNCIA", SqlDbType.Char);
               // pfrequencia.Value = aval.frequencia;
               // cmd.Parameters.Add(pfrequencia);

                SqlParameter fk_aluno = new SqlParameter("@FKII_CD_MATRICULA", SqlDbType.Int);
                fk_aluno.Value = aval.cd_Matricula;
                cmd.Parameters.Add(fk_aluno);

                SqlParameter fk_disciplina = new SqlParameter("@FKIII_CD_DISCIPLINA", SqlDbType.Int);
                fk_disciplina.Value = aval.cd_disciplina;
                cmd.Parameters.Add(fk_disciplina);

                //SqlParameter fk_professor = new SqlParameter("@FKI_CD_PROFESSOR", SqlDbType.Int);
                //fk_professor.Value = aval.cd_professor;
                // cmd.Parameters.Add(fk_professor);


                cn.Open();
                cmd.ExecuteNonQuery();
                aval.cd_Nota = (Int32)cmd.Parameters["@PK_CD_NOTA"].Value;


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

        public void Excluir(int Codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "EXCLUI_NOTA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_NOTA", SqlDbType.Int);
                pcodigo.Value = Codigo;
                cmd.Parameters.Add(pcodigo);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o cliente" + Codigo);
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
                da.SelectCommand.CommandText = "SELECIONA_NOTA";
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
                da.SelectCommand.CommandText = "SELECIONA_NOTAL";
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
