using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Modelos
{
    public class CursoInformation
    {
        private int pk_cd_curso;

        public int cd_curso
        {
            get { return pk_cd_curso; }
            set { pk_cd_curso = value; }
        }

        private string nm_curso;

        public string _curso
        {
            get { return nm_curso; }
            set { nm_curso = value; }
        }

        private string duracao_curso_total;

        public string duracao_curso
        {
            get { return duracao_curso_total; }
            set { duracao_curso_total = value; }
        }


    }
}
