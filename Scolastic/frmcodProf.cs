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
    public partial class frmcodProf : Form
    {
        public frmcodProf()
        {
            InitializeComponent();
        }

        private void frmcodProf_Load(object sender, EventArgs e)
        {
            ProfessorBLL obje = new ProfessorBLL();

            dataGridView1.DataSource = obje.Listagem("");


            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodProf.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_ds_pro = Convert.ToInt32(txtCodProf.Text);

            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodProf.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();

            VarGlobal.cd_ds_pro = Convert.ToInt32(txtCodProf.Text);

            frmDisciplina f = new frmDisciplina();
            this.Hide();
            f.ShowDialog();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            ProfessorBLL l = new ProfessorBLL();
            dataGridView1.DataSource = l.Listagem(txtPesquisa.Text);
            try
            {

                txtCodProf.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                VarGlobal.cd_ds_pro = Convert.ToInt32(txtCodProf.Text);
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmDisciplina f = new frmDisciplina();
            this.Hide();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

