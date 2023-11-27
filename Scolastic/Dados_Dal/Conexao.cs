using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Scolastic.Modelos;
using Scolastic.Dados_Dal;


namespace Scolastic.Dados_Dal
{
    class Conexao
    {

        public static string StringDeConexao
        {
            get
            {
                return "Data Source=DESKTOP-DF7LLAA\\SQLEXPRESS;Initial Catalog=DB_SCOLASTICC;Integrated Security=True";
                //return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_ESCOLA;Data Source=CRISTIANO\\SQLEXPRESS";
            }
        }


    }
}
