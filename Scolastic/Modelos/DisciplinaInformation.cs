using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Modelos
{
    public class DisciplinaInformation
    {
        private int pk_cd_disciplina;

        public int cd_disciplina
        {
            get { return pk_cd_disciplina; }
            set { pk_cd_disciplina = value; }
        }

        private string nm_disciplina;

        public string _disciplina
        {
            get { return nm_disciplina; }
            set { nm_disciplina = value; }
        }

        private string carga_horaria;

        public string _horaria
        {
            get { return carga_horaria; }
            set { carga_horaria = value; }
        }

        private int fk_cd_professor;

        public int cd_professor
        {
            get { return fk_cd_professor; }
            set { fk_cd_professor = value; }
        }


        private int fk_cd_turma;

        public int cd_turma
        {
            get { return fk_cd_turma; }
            set { fk_cd_turma = value; }
        }
    }
}
