using Scolastic.Dados_Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Regra_Bll
{
    public class ConsultaBLL
    {
        public DataTable filtroAvaliation(int Filtro,string disc)
        {
            ConsultaDAL OBL = new ConsultaDAL();
            return OBL.FiltroA(Filtro, disc);

        }

        public DataTable filtroNota(int Filtro,string disc)
        {
            ConsultaDAL OBL = new ConsultaDAL();
            return OBL.FiltroN(Filtro,disc);

        }
    }
}
