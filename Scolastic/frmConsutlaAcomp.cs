using Scolastic.Regra_Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scolastic
{
    public partial class frmConsutlaAcomp : Form
    {
        public frmConsutlaAcomp()
        {
            InitializeComponent();
        }
        float nota, resultado;
        string preseca, falta;
        int qtpreseca, qtfalta;
        private void frmConsutlaAcomp_Load(object sender, EventArgs e)
        {   
            
            DisciplinaBLL obj = new DisciplinaBLL();
            cbDisciplina.DataSource = obj.Listagem("");

            cbDisciplina.DisplayMember = "NM_DISCIPLINA";

         

        }

    

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPrincipal fMC = new frmPrincipal();
            this.Hide();
            fMC.ShowDialog();
        }

        private void cbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AvaliationBLL obje = new AvaliationBLL();
            NotaBLL objn = new NotaBLL();
            dataGridView1.DataSource = obje.Listageml(cbDisciplina.Text);
            dataGridView2.DataSource = objn.Listageml(cbDisciplina.Text);
            

            int qlinhas = dataGridView2.RowCount;

             foreach (DataGridViewRow dr in dataGridView2.Rows)
             {

                 try
                 {
                     nota = float.Parse(dr.Cells[5].Value.ToString());

                     if (nota > 0.0)
                     {
                        
                         resultado = resultado + nota;




                     }




                 }

                 catch (Exception ex) { }
                 



             }

            
            resultado = resultado / qlinhas;
            txtMedGeral.Text = Convert.ToString(resultado);
          //  MessageBox.Show("resulta" + resultado + "L" + qlinhas + "nota" + nota);
            resultado = 0;
            nota = 0;
            
            
           

            foreach (DataGridViewRow dg in dataGridView1.Rows)
            {

                try
                {
                    preseca = Convert.ToString(dg.Cells[3].Value);

                    if (preseca == "P")
                    {

                        qtpreseca = qtpreseca + 1;

                    }

                    else { qtfalta = qtfalta + 1; }

                }

                catch (Exception ex) { }



            }

            txtPres.Text = Convert.ToString(qtpreseca);
            txtFalta.Text = Convert.ToString(qtfalta);
            qtfalta = 0;
            qtpreseca = 0;
        

    }
    }
}
