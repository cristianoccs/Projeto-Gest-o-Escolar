using Regra_Bll;
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
    public partial class frmCriarUrProf : Form
    {
        public frmCriarUrProf()
        {
            InitializeComponent();
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmCriarLogin frc = new frmCriarLogin();
            this.Hide();
            frc.ShowDialog();
        }

        private void frmCriarUrProf_Load(object sender, EventArgs e)
        {
           
            ProfessorBLL obje = new ProfessorBLL();

            dataGridView1.DataSource = obje.Listagem("");


            int fila = dataGridView1.CurrentCell.RowIndex;
            txtCodMat.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dataGridView1.CurrentCell.RowIndex;
            txtCodMat.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_mat_login = Convert.ToInt32(txtCodMat.Text);
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;
            txtCodMat.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_mat_login = Convert.ToInt32(txtCodMat.Text);

            frmCriarLogin f = new frmCriarLogin();
            this.Hide();
            f.ShowDialog();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            ProfessorBLL l = new ProfessorBLL();
            dataGridView1.DataSource = l.Listagem(txtPesquisa.Text);
            try
            {

                txtCodMat.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                VarGlobal.cd_mat_login = Convert.ToInt32(txtCodMat.Text);
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
