using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Dados_Dal
{
    public class ConsultaDAL
    {

        public DataTable FiltroA(int filtro, string disc )
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "FILTRO_AVALIATION";
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("@FILTRO", SqlDbType.Text);
                pfiltro.Value = filtro;

                SqlParameter pdfiltro;
                pdfiltro = da.SelectCommand.Parameters.Add("@NM_DISC", SqlDbType.Text);
                pdfiltro.Value = disc;

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



        public DataTable FiltroN(int filtro, string disc)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "FILTRO_NOTA";
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("@FILTRO", SqlDbType.Text);
                pfiltro.Value = filtro;

                SqlParameter pdfiltro;
                pdfiltro = da.SelectCommand.Parameters.Add("@NM_DISC", SqlDbType.Text);
                pdfiltro.Value = disc;


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
