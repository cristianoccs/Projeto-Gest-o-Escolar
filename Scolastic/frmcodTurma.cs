using Scolastic.Regra_Bll;
using Scolastic.Modelos;
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
    
    public partial class frmcodTurma : Form
    {
        
        public frmcodTurma()
        {
            InitializeComponent();
        }

       
        
        private void frmcodTurma_Load(object sender, EventArgs e)
        {
            
            TurmaBLL obje = new TurmaBLL();

            dataGridView1.DataSource = obje.Listagem("");


            int fila = dataGridView1.CurrentCell.RowIndex;

             txtCodTurma.Text = dataGridView1[0, fila].Value.ToString();
             dataGridView1[1, fila].Value.ToString();
             dataGridView1[2, fila].Value.ToString();
             dataGridView1[3, fila].Value.ToString();
             dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_ds_tur = Convert.ToInt32(txtCodTurma.Text); 

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            TurmaBLL l = new TurmaBLL();
            dataGridView1.DataSource = l.Listagem(txtPesquisa.Text);
            try
            {
                
                txtCodTurma.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                 dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                 dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                 dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                 dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                VarGlobal.cd_ds_tur= Convert.ToInt32(txtCodTurma.Text);
                

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
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodTurma.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_ds_tur = Convert.ToInt32(txtCodTurma.Text);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //TurmaBLL obje = new TurmaBLL();
            //dataGridView1.DataSource = obje.Listagem("");
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodTurma.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            dataGridView1[3, fila].Value.ToString();
            dataGridView1[4, fila].Value.ToString();
           
           VarGlobal.cd_ds_tur= Convert.ToInt32(txtCodTurma.Text);

            frmDisciplina f = new frmDisciplina();
            this.Hide();
            f.ShowDialog();
        }
    }
    
}
