
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
    public class ProfessorBLL
    {
        
        public void Incluir(ProfessorInformation profeObj)
        {
            if (profeObj._professor.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (profeObj.nascimento.Equals(""))
            { throw new Exception(" o data de nascimento é obriatorio"); }

            if (profeObj.rg.Equals(""))
            {
                throw new Exception("o RG é obriatorio!");
            }


            if (profeObj.cpf.Equals(""))
            { throw new Exception(" o CPF é obriatorio"); }

            if (profeObj.sexo.Equals(""))
            {
                throw new Exception("o Sexo é obriatorio!");
            }


            if (profeObj.cidade.Equals(""))
            { throw new Exception(" o nome da cidade é obriatorio"); }

            if (profeObj.end_cid.Equals(""))
            {
                throw new Exception("o endereço é obriatorio!");
            }


            if (profeObj.end_bair.Equals(""))
            { throw new Exception(" o Bairro é obriatorio"); }

            if (profeObj.cep.Equals(""))
            {
                throw new Exception("o CEP é obriatorio!");
            }

            if (profeObj.email.Equals(""))
            {
                throw new Exception("o EMAIL é obriatorio!");
            }
            if (profeObj.t_academico.Equals(""))
            {
                throw new Exception("o CEP é obriatorio!");
            }

            ProfessorDAL profDAL = new ProfessorDAL();
            profDAL.Incluir(profeObj);

        }

        public void Alterar(ProfessorInformation proffObj)
        {
            if (proffObj._professor.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (proffObj.nascimento.Equals(""))
            { throw new Exception(" o data de nascimento é obriatorio"); }

            if (proffObj.rg.Equals(""))
            {
                throw new Exception("o RG é obriatorio!");
            }


            if (proffObj.cpf.Equals(""))
            { throw new Exception(" o CPF é obriatorio"); }

            if (proffObj.sexo.Equals(""))
            {
                throw new Exception("o Sexo é obriatorio!");
            }


            if (proffObj.cidade.Equals(""))
            { throw new Exception(" o nome da cidade é obriatorio"); }

            if (proffObj.end_cid.Equals(""))
            {
                throw new Exception("o endereço é obriatorio!");
            }


            if (proffObj.end_bair.Equals(""))
            { throw new Exception(" o Bairro é obriatorio"); }

            if (proffObj.cep.Equals(""))
            {
                throw new Exception("o CEP é obriatorio!");
            }

            ProfessorDAL proffDAL = new ProfessorDAL();
            proffDAL.Alterar(proffObj);

        }


        public void Excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona um Cliente antes de excluilo");

            }

            ProfessorDAL proffDAL = new ProfessorDAL();
            proffDAL.Excluir(Codigo);
        }

        public DataTable Listagem(string Filtro)
        {
            ProfessorDAL proffDAL = new ProfessorDAL();
            return proffDAL.Listagem(Filtro);

        }

    }
}
