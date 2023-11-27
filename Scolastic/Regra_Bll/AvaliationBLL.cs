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
    public class AvaliationBLL
    {

        public void Incluir(AvaliationInformation Avalobj)
        {
           // if (Avalobj.nota_aluno.Equals("")) //trim tira todos os espaço
           // { throw new Exception("nota"); }

            if (Avalobj.data_aval.Equals(""))
            { throw new Exception(" o data é obriatoria"); }

            if (Avalobj.frequencia.Equals(""))
            {
                throw new Exception("o frequencia é obriatorio!");
            }


            if (Avalobj.cd_Matricula.Equals(""))
            { throw new Exception(" codigo do aluno é obriatorio"); }

            if (Avalobj.cd_disciplina.Equals(""))
            {
                throw new Exception("o codigo da disciplina é obriatorio!");
            }


            //if (Avalobj.cd_professor.Equals(""))
            //{ throw new Exception(" O codigo do professor é obriatorio"); }


            AvaliationDAL AvalDALObj = new AvaliationDAL();
            AvalDALObj.Incluir(Avalobj);


        }

        public void Alterar(AvaliationInformation Avalobj)
        {
           // if (Avalobj.nota_aluno.Equals("")) //trim tira todos os espaço
           // { throw new Exception("nota"); }

            if (Avalobj.data_aval.Equals(""))
            { throw new Exception(" o data é obriatoria"); }

            if (Avalobj.frequencia.Equals(""))
            {
                throw new Exception("o frequencia é obriatorio!");
            }


            if (Avalobj.cd_Matricula.Equals(""))
            { throw new Exception(" codigo do aluno é obriatorio"); }

            if (Avalobj.cd_disciplina.Equals(""))
            {
                throw new Exception("o codigo da disciplina é obriatorio!");
            }


           // if (Avalobj.cd_professor.Equals(""))
           // { throw new Exception(" O codigo do professor é obriatorio"); }


            AvaliationDAL AvalDALObj = new AvaliationDAL();
            AvalDALObj.Alterar(Avalobj);


        }


        public void Excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona a avaliation antes de excluilo");

            }

            AvaliationDAL AvalDALObj = new AvaliationDAL();
            AvalDALObj.Excluir(Codigo);
        }

        public DataTable Listagem(string Filtro)
        {
            AvaliationDAL OBL = new AvaliationDAL();
            return OBL.Listagem(Filtro);

        }

        public DataTable Listageml(string Filtro)
        {
            AvaliationDAL OBL = new AvaliationDAL();
            return OBL.Listageml(Filtro);

        }

    }
}
