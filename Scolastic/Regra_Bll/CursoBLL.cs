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
    public class CursoBLL
    {
        public void Incluir(CursoInformation cursoObj)
        {
            if (cursoObj._curso.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (cursoObj.duracao_curso.Equals(""))
            { throw new Exception(" o duração do curso é obriatorio"); }


            CursoDAL CursoDALObj = new CursoDAL();
            CursoDALObj.Incluir(cursoObj);

        }

        public void Alterar(CursoInformation cursoObj)
        {
            if (cursoObj._curso.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (cursoObj.duracao_curso.Equals(""))
            { throw new Exception(" o duração do curso é obriatorio"); }



            CursoDAL CursoDALObj = new CursoDAL();
            CursoDALObj.Alterar(cursoObj);

        }
        public void Excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona O Curso antes de excluilo");

            }

            CursoDAL obj = new CursoDAL();
            obj.Exluir(Codigo);
        }
        public DataTable Listagem(string Filtro)
        {
            CursoDAL OBL = new CursoDAL();
            return OBL.Listagem(Filtro);

        }
    }
}
