using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scolastc.Modelos
{
    public class NotaInformation
    {
        private int pk_cd_Nota;

        public int cd_Nota
        {
            get { return pk_cd_Nota; }
            set { pk_cd_Nota = value; }
        }

         private float nota;

          public float nota_aluno
          {
              get { return nota; }
             set { nota = value; }
          }

        private DateTime dat;

        public DateTime data_aval
        {
            get { return dat; }
            set { dat = value; }
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

        
    }
}
