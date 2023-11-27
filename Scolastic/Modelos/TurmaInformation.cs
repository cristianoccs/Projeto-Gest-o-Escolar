using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Modelos
{
    public class TurmaInformation
    {
        private int pk_cd_turma;

        public int cd_turma
        {
            get { return pk_cd_turma; }
            set { pk_cd_turma = value; }
        }

        private string nm_turma;

        public string NMturma
        {
            get { return nm_turma; }
            set { nm_turma = value; }
        }

        private string periodo_turma;

        public string periodo
        {
            get { return periodo_turma; }
            set { periodo_turma = value; }
        }

        private string ANO_TURMA;

        public string ANOTURMA
        {
            get { return ANO_TURMA; }
            set { ANO_TURMA = value; }
        }


        private int fk_cd_curso;

        public int cd_curso
        {
            get { return fk_cd_curso; }
            set { fk_cd_curso = value; }
        }


    }
}
