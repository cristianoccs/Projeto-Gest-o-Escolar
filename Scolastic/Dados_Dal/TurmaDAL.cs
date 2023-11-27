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
    public class TurmaDAL
    {
        public void D_Incluir(TurmaInformation pturma)
        {
            
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_TURMA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_TURMA", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnm_TURMA = new SqlParameter("@NM_TURMA", SqlDbType.NVarChar, 60);
                pnm_TURMA.Value = pturma.NMturma;
                cmd.Parameters.Add(pnm_TURMA);

                SqlParameter pTURNO = new SqlParameter("@TURNO", SqlDbType.NVarChar, 60);
                pTURNO.Value = pturma.periodo;
                cmd.Parameters.Add(pTURNO);

                SqlParameter pANO = new SqlParameter("@ANO", SqlDbType.NVarChar, 60);
                pANO.Value = pturma.ANOTURMA;
                cmd.Parameters.Add(pANO);

                SqlParameter pFK_CURSO = new SqlParameter("@FKI_CD_CURSO", SqlDbType.Int);
                pFK_CURSO.Value = pturma.cd_curso;
                cmd.Parameters.Add(pFK_CURSO);




                cn.Open();
                cmd.ExecuteNonQuery();
                pturma.cd_turma = (Int32)cmd.Parameters["@PK_CD_TURMA"].Value;
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

        public void D_Alterar(TurmaInformation apturma)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERA_TURMA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_TURMA", SqlDbType.Int);
                pcodigo.Value = apturma.cd_turma;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnm_TURMA = new SqlParameter("@NM_TURMA", SqlDbType.NVarChar, 60);
                pnm_TURMA.Value = apturma.NMturma;
                cmd.Parameters.Add(pnm_TURMA);

                SqlParameter pTURNO = new SqlParameter("@TURNO", SqlDbType.NVarChar, 60);
                pTURNO.Value = apturma.periodo;
                cmd.Parameters.Add(pTURNO);

                SqlParameter pANO = new SqlParameter("@ANO", SqlDbType.NVarChar, 60);
                pANO.Value = apturma.ANOTURMA;
                cmd.Parameters.Add(pANO);

                SqlParameter pFK_CURSO = new SqlParameter("@FKI_CD_CURSO", SqlDbType.Int);
                pFK_CURSO.Value = apturma.cd_curso;
                cmd.Parameters.Add(pFK_CURSO);




                cn.Open();
                cmd.ExecuteNonQuery();
                apturma.cd_turma = (Int32)cmd.Parameters["@PK_CD_TURMA"].Value;
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

        public void Exluir(int cd_turma)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "EXCLUI_TURMA";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_TURMA", SqlDbType.Int);
                pcodigo.Value = cd_turma;
                cmd.Parameters.Add(pcodigo);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o CURSO" + cd_turma);
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
                da.SelectCommand.CommandText = "SELECIONA_TURMA";
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
