using Scolastic.Dados_Dal;
using Scolastic.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Regra_Bll
{
    public class TurmaBLL
    {
        public void Incluir(TurmaInformation turObj)
        {
            if (turObj.NMturma.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (turObj.periodo.Equals(""))
            { throw new Exception(" o perido obriatorio"); }

            if (turObj.ANOTURMA.Equals(""))
            { throw new Exception(" o Ano da turma é obriatorio"); }

            if (turObj.cd_curso.Equals(""))
            {
                throw new Exception("codigo curso");
            }



            TurmaDAL turDAL = new TurmaDAL();
            turDAL.D_Incluir(turObj);

        }

        public void Alterar(TurmaInformation turmObj)
        {
            if (turmObj.NMturma.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (turmObj.periodo.Equals(""))
            { throw new Exception(" periodo do turma é obriga"); }

            if (turmObj.ANOTURMA.Equals(""))
            { throw new Exception(" o Ano da turma é obriatorio"); }

            if (turmObj.cd_curso.Equals(""))
            {
                throw new Exception("codigo do curso");
            }



            TurmaDAL turDAL = new TurmaDAL();
            turDAL.D_Alterar(turmObj);

        }

        public void Excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona um Cliente antes de excluilo");

            }

            TurmaDAL TurDAL = new TurmaDAL();
            TurDAL.Exluir(Codigo);
        }

        public DataTable Listagem(string Filtro)
        {
            TurmaDAL OBL = new TurmaDAL();
            return OBL.Listagem(Filtro);

        }
    }
}
