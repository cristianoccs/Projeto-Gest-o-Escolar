using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastic.Modelos
{
    public class AvaliationInformation
    {
        private int pk_cd_avaliation;

        public int cd_avaliation
        {
            get { return pk_cd_avaliation; }
            set { pk_cd_avaliation = value; }
        }

       // private string nota;

      //  public string nota_aluno
      //  {
      //      get { return nota; }
      //      set { nota = value; }
      //  }

        private DateTime dat;

        public DateTime data_aval
        {
            get { return dat; }
            set { dat = value; }
        }

        private Char presenca;

        public Char frequencia
        {
            get { return presenca; }
            set { presenca = value; }
        }

        private int fk_cd_matricula;

        public int cd_Matricula
        {
            get { return fk_cd_matricula; }
            set { fk_cd_matricula = value; }
        }

        private int fk_cd_disciplina;

        public int cd_disciplina
        {
            get { return fk_cd_disciplina; }
            set { fk_cd_disciplina = value; }
        }

      //  private int fk_cd_professor;

      //  public int cd_professor
      //  {
      //      get { return fk_cd_professor; }
       //     set { fk_cd_professor = value; }
       // }

    }
}
