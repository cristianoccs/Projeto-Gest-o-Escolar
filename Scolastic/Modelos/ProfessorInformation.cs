using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Modelos
{
    public class ProfessorInformation
    {
        private int pk_cd_professor;

        public int cd_professor
        {
            get { return pk_cd_professor; }
            set { pk_cd_professor = value; }
        }

        private string nm_professor;

        public string _professor
        {
            get { return nm_professor; }
            set { nm_professor = value; }
        }

        private DateTime dt_nascimento;

        public DateTime nascimento
        {
            get { return dt_nascimento; }
            set { dt_nascimento = value; }
        }

        private string rg_professor;

        public String rg
        {
            get { return rg_professor; }
            set { rg_professor = value; }
        }


        private string cpf_professor;

        public string cpf
        {
            get { return cpf_professor; }
            set { cpf_professor = value; }
        }


        private string sexo_professor;

        public string sexo
        {
            get { return sexo_professor; }
            set { sexo_professor = value; }
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


        private string tl_academico;

        public string t_academico
        {
            get { return tl_academico; }
            set { tl_academico = value; }
        }

        private string ds_email;

        public string email
        {
            get { return ds_email; }
            set { ds_email = value; }
        }
    }
}
