using System;
using Scolastic.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scolastic.Dados_Dal;
using System.Data;
using Scolastc.Modelos;

namespace Scolastic.Regra_Bll
{
    public class NotaBLL
    {
        public void Incluir(NotaInformation Avalobj)
        {
             if (Avalobj.nota_aluno.Equals("")) //trim tira todos os espaço
             { throw new Exception("nota"); }

            if (Avalobj.data_aval.Equals(""))
            { throw new Exception(" o data é obriatoria"); }

           // if (Avalobj.frequencia.Equals(""))
           // {
           //     throw new Exception("o frequencia é obriatorio!");
           // }


            if (Avalobj.cd_Matricula.Equals(""))
            { throw new Exception(" codigo do aluno é obriatorio"); }

            if (Avalobj.cd_disciplina.Equals(""))
            {
                throw new Exception("o codigo da disciplina é obriatorio!");
            }


            //if (Avalobj.cd_professor.Equals(""))
            //{ throw new Exception(" O codigo do professor é obriatorio"); }


            NotaDAL AvalDALObj = new NotaDAL();
            AvalDALObj.Incluir(Avalobj);


        }

        public void Alterar(NotaInformation Avalobj)
        {
             if (Avalobj.nota_aluno.Equals("")) //trim tira todos os espaço
             { throw new Exception("nota"); }

            if (Avalobj.data_aval.Equals(""))
            { throw new Exception(" o data é obriatoria"); }

           // if (Avalobj.frequencia.Equals(""))
           // {
           //     throw new Exception("o frequencia é obriatorio!");
           // }


            if (Avalobj.cd_Matricula.Equals(""))
            { throw new Exception(" codigo do aluno é obriatorio"); }

            if (Avalobj.cd_disciplina.Equals(""))
            {
                throw new Exception("o codigo da disciplina é obriatorio!");
            }


            // if (Avalobj.cd_professor.Equals(""))
            // { throw new Exception(" O codigo do professor é obriatorio"); }


            NotaDAL AvalDALObj = new NotaDAL();
            AvalDALObj.Alterar(Avalobj);


        }


        public void Excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona a avaliation antes de excluilo");

            }



            NotaDAL AvalDALObj = new NotaDAL();
            AvalDALObj.Excluir(Codigo);
        }

        public DataTable Listagem(string Filtro)
        {
            NotaDAL OBL = new NotaDAL();
            return OBL.Listagem(Filtro);

        }

        public DataTable Listageml(string Filtro)
        {
            NotaDAL OBL = new NotaDAL();
            return OBL.Listageml(Filtro);

        }
    }
}
