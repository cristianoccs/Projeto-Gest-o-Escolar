using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class MatriculaInformation
    {

        private int pk_cd_matricula;

        public int cd_matricula
        {
            get { return pk_cd_matricula; }
            set { pk_cd_matricula = value; }
        }

        private int fk_cd_aluno;

        public int cd_aluno
        {
            get { return fk_cd_aluno; }
            set { fk_cd_aluno = value; }
        }

        private int fk_cd_turma;

        public int cd_turma
        {
            get { return fk_cd_turma; }
            set { fk_cd_turma = value; }
        }

        private int fk_cd_curso;

        public int cd_curso
        {
            get { return fk_cd_curso; }
            set { fk_cd_curso = value; }
        }
        private string NMAluno;
        public string NM_aluno
        {
            get { return NMAluno; }
            set { NMAluno = value; }
        }

    }
}
