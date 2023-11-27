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
    public class DisciplinaBLL
    {
        public void Incluir(DisciplinaInformation disciplinaObj)
        {
            if (disciplinaObj._disciplina.Equals(""))
            { throw new Exception(" o nome é obriatorio"); }

            if (disciplinaObj._horaria.Equals(""))
            { throw new Exception(" quantidade de horas"); }

            if (disciplinaObj.cd_professor.Equals(""))
            {
                throw new Exception("codigo do prevista");
            }

            if (disciplinaObj.cd_turma.Equals(""))
            { throw new Exception(" codigo da turma "); }



            DisciplinaDAL disciplinaDALobj = new DisciplinaDAL();
            disciplinaDALobj.Incluir(disciplinaObj);

        }

        public void Alterar(DisciplinaInformation disciObj)
        {
            if (disciObj._disciplina.Equals(""))
            { throw new Exception(" o nome é obriatorio"); }

            if (disciObj._horaria.Equals(""))
            { throw new Exception(" quantida de horas"); }

            if (disciObj.cd_professor.Equals(""))
            {
                throw new Exception("Codigo do professo");
            }

            if (disciObj.cd_turma.Equals(""))
            { throw new Exception(" codigo da turma "); }



            DisciplinaDAL disc = new DisciplinaDAL();
            disc.D_Alterar(disciObj);

        }

        public void Excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona uma disciplina antes de excluilo");

            }

            DisciplinaDAL disciplinaDAL = new DisciplinaDAL();
            disciplinaDAL.Exluir(Codigo);
        }

        public DataTable Listagem(string Filtro)
        {
            DisciplinaDAL OBL = new DisciplinaDAL();
            return OBL.Listagem(Filtro);

        }

        public DataTable Listageml(string Filtro,int cd)
        {
            DisciplinaDAL OBL = new DisciplinaDAL();
            return OBL.Listageml(Filtro,cd);

        }
    }
}
