using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Modelos
{
    public class LogiInformation
    {

        private int pk_cd_login;

        public int id_login
        {
            get { return pk_cd_login; }
            set { pk_cd_login = value; }
        }

        private string Nome;

        public string logim
        {
            get { return Nome; }
            set { Nome = value; }
        }

        private string s_senha;

        public string senha
        {
            get { return s_senha; }
            set { s_senha = value; }
        }



        private string idtipo;

        public string id_tipo
        {
            get { return idtipo; }
            set { idtipo = value; }
        }

        private int nuMatric;

        public int Num_matric
        {
            get { return nuMatric; }
            set { nuMatric = value; }
        }

    }
}
