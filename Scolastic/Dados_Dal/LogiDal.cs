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
    public class LogiDal
    {



        public DataTable D_logar(LogiInformation obje)
        {

            SqlConnection con = new SqlConnection();

            con.ConnectionString = Conexao.StringDeConexao;
            SqlCommand cmd = new SqlCommand("SP_LOGAR", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOME", obje.logim);
            cmd.Parameters.AddWithValue("@SENHA", obje.senha);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_login(LogiInformation obje)
        {

            SqlConnection con = new SqlConnection();

            con.ConnectionString = Conexao.StringDeConexao;
            SqlCommand cmd = new SqlCommand("SP_BUCAR_LOGIN", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOME", obje.logim);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_lista_login(string filtro)
        {

            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();


            cn.ConnectionString = Conexao.StringDeConexao;
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.CommandText = "SELECIONA_LOGIN";
            da.SelectCommand.Connection = cn;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter pfiltro;
            pfiltro = da.SelectCommand.Parameters.Add("@FILTRO", SqlDbType.Text);
            pfiltro.Value = filtro;

            da.Fill(dt);
            return dt;


        }

        public void D_inclui_login(LogiInformation obje)
        {

            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "INSERE_LOGIN";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_LOGIN", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@NOME", SqlDbType.NVarChar, 60);
                pnome.Value = obje.logim;
                cmd.Parameters.Add(pnome);


                SqlParameter psenha = new SqlParameter("@SENHA", SqlDbType.NVarChar, 60);
                psenha.Value = obje.senha;
                cmd.Parameters.Add(psenha);

                SqlParameter pidtipo = new SqlParameter("@FK_CD_TIPO", SqlDbType.NVarChar, 60);
                pidtipo.Value = obje.id_tipo;
                cmd.Parameters.Add(pidtipo);

                SqlParameter pNumatric = new SqlParameter("@MAT_LOG", SqlDbType.Int);
                pNumatric.Value = obje.Num_matric;
                cmd.Parameters.Add(pNumatric);

                cn.Open();
                cmd.ExecuteNonQuery();
                obje.id_login = (Int32)cmd.Parameters["@PK_CD_LOGIN"].Value;


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

        public void D_alterar_login(LogiInformation obje)
        {

            SqlConnection cn = new SqlConnection();


            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure; // Comando Stored Procedure
                cmd.CommandText = "ALTERAR_LOGIN";

                SqlParameter pcodigo = new SqlParameter("@PK_CD_LOGIN", SqlDbType.Int);
                pcodigo.Value = obje.id_login;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@NOME", SqlDbType.NVarChar, 60);
                pnome.Value = obje.logim;
                cmd.Parameters.Add(pnome);


                SqlParameter psenha = new SqlParameter("@SENHA", SqlDbType.NVarChar, 60);
                psenha.Value = obje.senha;
                cmd.Parameters.Add(psenha);

                SqlParameter pidtipo = new SqlParameter("@FK_CD_TIPO", SqlDbType.NVarChar, 60);
                pidtipo.Value = obje.id_tipo;
                cmd.Parameters.Add(pidtipo);

                //obje.id_login = (Int32)cmd.Parameters["@PK_CD_LOGIN"].Value;
                cn.Open();
                cmd.ExecuteNonQuery();
                obje.id_login = (Int32)cmd.Parameters["@PK_CD_LOGIN"].Value;

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
        public void D_excluir_login(int obje)
        {
            SqlConnection con = new SqlConnection();

            try
            {

                con.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand("EXCLUI_LOGIN", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                SqlParameter pcodigo = new SqlParameter("@PK_CD_LOGIN", SqlDbType.Int);
                pcodigo.Value = obje;
                cmd.Parameters.Add(pcodigo);

                con.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o Usuario" + obje);
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
                con.Close();
            }











        }
    }
}
