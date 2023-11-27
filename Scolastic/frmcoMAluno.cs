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
    public partial class frmcoMAluno : Form
    {
        public frmcoMAluno()
        {
            InitializeComponent();
        }

        private void frmcoMAluno_Load(object sender, EventArgs e)
        {
            AlunoBLL obje = new AlunoBLL();

            dataGridView1.DataSource = obje.Listagem("");


            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodTurma.Text = dataGridView1[0, fila].Value.ToString();

            VarGlobal.NM_aluno = Convert.ToString(dataGridView1[1, fila].Value.ToString());
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_ms_aluno = Convert.ToInt32(txtCodTurma.Text);
            
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

            AlunoBLL l = new AlunoBLL();
            dataGridView1.DataSource = l.Listagem(txtPesquisa.Text);
            try
            {

                txtCodTurma.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
               VarGlobal.NM_aluno= dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                VarGlobal.cd_ms_aluno = Convert.ToInt32(txtCodTurma.Text);


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmMatricula fM = new frmMatricula();
            this.Hide();
            fM.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodTurma.Text = dataGridView1[0, fila].Value.ToString();
            VarGlobal.NM_aluno = Convert.ToString(dataGridView1[1, fila].Value.ToString());
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_ms_aluno = Convert.ToInt32(txtCodTurma.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodTurma.Text = dataGridView1[0, fila].Value.ToString();
            VarGlobal.NM_aluno = Convert.ToString(dataGridView1[1, fila].Value.ToString());
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();

            VarGlobal.cd_ms_aluno = Convert.ToInt32(txtCodTurma.Text);

            frmMatricula fM = new frmMatricula();
            this.Hide();
            fM.ShowDialog();
        }
    }
}
