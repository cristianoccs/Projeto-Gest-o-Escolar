using Dados_Dal;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regra_Bll
{
    public class MatriculaBLL
    {
        public void Incluir(MatriculaInformation MatriObj)
        {
            if (MatriObj.cd_aluno.Equals("")) //trim tira todos os espaço
            { throw new Exception(" Codigo do aluno é obriatorio"); }

            if (MatriObj.cd_turma.Equals(""))
            { throw new Exception(" Codigo da turma é obriatorio"); }

            if (MatriObj.cd_curso.Equals("")) //trim tira todos os espaço
            { throw new Exception(" Codigo do MATRICUAL obriatorio"); }

            if (MatriObj.NM_aluno.Equals("")) //trim tira todos os espaço
            { throw new Exception(" Codigo O NOME DO ALUNO obriatorio"); }

            MatriculaDAL MatDAL = new MatriculaDAL();
            MatDAL.Incluir(MatriObj);

        }

        public void Alterar(MatriculaInformation MatriObj)
        {
            if (MatriObj.cd_aluno.Equals("")) //trim tira todos os espaço
            { throw new Exception(" Codigo do aluno é obriatorio"); }

            if (MatriObj.cd_turma.Equals(""))
            { throw new Exception(" Codigo da turma é obriatorio"); }

            if (MatriObj.cd_curso.Equals("")) //trim tira todos os espaço
            { throw new Exception(" Codigo do curso obriatorio"); }

            if (MatriObj.NM_aluno.Equals("")) //trim tira todos os espaço
            { throw new Exception(" Codigo O NOME DO ALUNO obriatorio"); }


            MatriculaDAL MatDAL = new MatriculaDAL();
            MatDAL.D_Alterar(MatriObj);

        }

        public void Excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona um matricula antes de excluilo");

            }

            MatriculaDAL MatDAL = new MatriculaDAL();
            MatDAL.Excluir(Codigo);
        }

        public DataTable Listagem(string Filtro)
        {
            MatriculaDAL OBL = new MatriculaDAL();
            return OBL.Listagem(Filtro);

        }
    }
}
