using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Scolastic.Modelos
{
    public class AlunoInformation
    {
        private int pk_cd_aluno;

        public int cd_aluno
        {
            get { return pk_cd_aluno; }
            set { pk_cd_aluno = value; }
        }

        private string nm_aluno;

        public string _aluno
        {
            get { return nm_aluno; }
            set { nm_aluno = value; }
        }

        private DateTime dt_nascimento;

        public DateTime nascimento
        {
            get { return dt_nascimento; }
            set { dt_nascimento = value; }
        }

        private string rg_aluno;

        public string rg
        {
            get { return rg_aluno; }
            set { rg_aluno = value; }
        }


        private string cpf_aluno;

        public string cpf
        {
            get { return cpf_aluno; }
            set { cpf_aluno = value; }
        }


        private string sexo_aluno;

        public string sexo
        {
            get { return sexo_aluno; }
            set { sexo_aluno = value; }
        }

        private string nm_cidade;

        public string cidade
        {
            get { return nm_cidade; }
            set { nm_cidade = value; }
        }


        private string end_cidade;

        public string end_cid
        {
            get { return end_cidade; }
            set { end_cidade = value; }
        }

        private string end_bairro;

        public string end_bair
        {
            get { return end_bairro; }
            set { end_bairro = value; }
        }

        private string cep_cidade;

        public string cep
        {
            get { return cep_cidade; }
            set { cep_cidade = value; }
        }

        private string nr_telefone;

        public string telefone
        {
            get { return nr_telefone; }
            set { nr_telefone = value; }
        }

        private string ds_email;

        public string email
        {
            get { return ds_email; }
            set { ds_email = value; }
        }
    }
}
