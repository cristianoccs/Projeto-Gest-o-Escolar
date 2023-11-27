using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Scolastic.Modelos;
using Scolastic.Dados_Dal;


namespace Scolastic.Regra_Bll
{
    public class AlunoBLL
    {


        public void Incluir(AlunoInformation Alunoobj)
        {
            if (Alunoobj._aluno.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }


            if (Alunoobj.cpf.Equals(""))
            { throw new Exception(" o CPF é obriatorio"); }

            if (Alunoobj.rg.Equals(""))
            {
                throw new Exception("o RG é obriatorio!");
            }



            if (Alunoobj.sexo.Equals(""))
            {
                throw new Exception("o Sexo é obriatorio!");
            }


            if (Alunoobj.cidade.Equals(""))
            { throw new Exception(" o nome da cidade é obriatorio"); }

            if (Alunoobj.nascimento.Equals(""))
            { throw new Exception(" o data de nascimento é obriatorio"); }

            if (Alunoobj.rg.Equals(""))
            {
                throw new Exception("o RG é obriatorio!");
            }


            

            if (Alunoobj.end_cid.Equals(""))
            {
                throw new Exception("o endereço é obriatorio!");
            }


            if (Alunoobj.end_bair.Equals(""))
            { throw new Exception(" o Bairro é obriatorio"); }

            if (Alunoobj.cep.Equals(""))
            {
                throw new Exception("o CEP é obriatorio!");
            }

            if (Alunoobj.telefone.Equals(""))
            {
                throw new Exception("o telefone é obriatorio!");
            }

            if (Alunoobj.email.Equals(""))
            {
                throw new Exception("o Email é obriatorio!");
            }



            AlunoDAL lAlunoDALObj = new AlunoDAL();
            lAlunoDALObj.D_Incluir(Alunoobj);


        }

        public void Altera(AlunoInformation Alunoobj)
        {
            if (Alunoobj._aluno.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (Alunoobj.nascimento.Equals(""))
            { throw new Exception(" o data de nacimento é obriatorio"); }

            if (Alunoobj.rg.Equals(""))
            {
                throw new Exception("o RG é obriatorio!");
            }


            if (Alunoobj.cpf.Equals(""))
            { throw new Exception(" o CPF é obriatorio"); }

            if (Alunoobj.sexo.Equals(""))
            {
                throw new Exception("o Sexo é obriatorio!");
            }


            if (Alunoobj.cidade.Equals(""))
            { throw new Exception(" o nome da cidade é obriatorio"); }

            if (Alunoobj.end_cid.Equals(""))
            {
                throw new Exception("o endereço é obriatorio!");
            }


            if (Alunoobj.end_bair.Equals(""))
            { throw new Exception(" o Bairro é obriatorio"); }

            if (Alunoobj.cep.Equals(""))
            {
                throw new Exception("o CEP é obriatorio!");
            }

            AlunoDAL obj = new AlunoDAL();
            obj.D_Alterar(Alunoobj);

        }


        public void Excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona um Cliente antes de excluilo");

            }

            AlunoDAL Alunoobj = new AlunoDAL();
            Alunoobj.Exluir(Codigo);
        }

        public DataTable Listagem(string Filtro)
        {
            AlunoDAL OBL = new AlunoDAL();
            return OBL.Listagem(Filtro);

        }

        public DataTable lista_aluno()
        {
            AlunoDAL OBL = new AlunoDAL();
            return OBL.selec_n();

        }

    }
}
