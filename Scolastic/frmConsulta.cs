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

namespace Scolastic
{
    public partial class frmConsulta : Form
    {
        float nota,resultado;
        string preseca, falta;
        int qtpreseca, qtfalta;

        private void cbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {

            // AvaliationBLL objl = new AvaliationBLL();
            // NotaBLL objn = new NotaBLL();
            // dataGridView1.DataSource = objl.Listageml(cbDisciplina.Text);
            // dataGridView2.DataSource = objn.Listageml(cbDisciplina.Text);

            ConsultaBLL obje = new ConsultaBLL();
            dataGridView1.DataSource = obje.filtroAvaliation(VarGlobal.cd_mat_login, cbDisciplina.Text);
            dataGridView2.DataSource = obje.filtroNota(VarGlobal.cd_mat_login, cbDisciplina.Text);

            int qlinhas = dataGridView2.RowCount;



            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {

                try
                {
                    nota = float.Parse(dr.Cells[2].Value.ToString());

                    if (nota > 0.0)
                    {

                        resultado = resultado + nota;

                    }



                }

                catch (Exception ex) { }



            }

            resultado = resultado / qlinhas;
            txtMedGeral.Text = Convert.ToString(resultado);
           // MessageBox.Show("resulta" + resultado +"linha" + "L" + qlinhas);
            resultado = 0;
            nota = 0;

            foreach (DataGridViewRow dg in dataGridView1.Rows)
            {

                try
                {
                    preseca = Convert.ToString(dg.Cells[2].Value);

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

        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            

            ConsultaBLL obje = new ConsultaBLL();
            dataGridView1.DataSource = obje.filtroAvaliation(VarGlobal.cd_mat_login,cbDisciplina.Text);
            dataGridView2.DataSource = obje.filtroNota(VarGlobal.cd_mat_login,cbDisciplina.Text);

            DisciplinaBLL obj = new DisciplinaBLL();
            cbDisciplina.DataSource = obj.Listagem("");

            cbDisciplina.DisplayMember = "NM_DISCIPLINA";


          /*  int qlinhas = dataGridView2.RowCount;



            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {

                try
                {
                    nota = float.Parse(dr.Cells[2].Value.ToString());

                    if (nota > 0.0)
                    {

                        resultado = resultado + nota / qlinhas; break;

                    }



                }

                catch (Exception ex) { }

            
            
            }

            txtMedGeral.Text = Convert.ToString(resultado);
            MessageBox.Show("resulta" + resultado + qlinhas);


            foreach (DataGridViewRow dg in dataGridView1.Rows)
            {

                try
                {
                    preseca = Convert.ToString(dg.Cells[2].Value);

                    if (preseca=="P")
                    {

                        qtpreseca = qtpreseca + 1;

                    }

                    else { qtfalta = qtfalta + 1;}

                }

                catch (Exception ex) { }



            }

            txtPres.Text = Convert.ToString(qtpreseca);
            txtFalta.Text = Convert.ToString(qtfalta);*/

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPrincipal fMC = new frmPrincipal();
            this.Hide();
            fMC.ShowDialog();
            
        }

        
        
    }
}
