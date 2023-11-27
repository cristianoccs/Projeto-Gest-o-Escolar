using Scolastc.Modelos;
using Scolastic.Dados_Dal;
using Scolastic.Modelos;
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
    public partial class frmNota : Form
    {
        public frmNota()
        {
            InitializeComponent();
        }

        private void frmNota_Load(object sender, EventArgs e)
        {
            if (VarGlobal.tipo_login == "PROFESSOR")
            {

                DisciplinaBLL obj = new DisciplinaBLL();
                comboBox1.DataSource = obj.Listageml("", Convert.ToInt32(VarGlobal.cd_mat_login));

                comboBox1.DisplayMember = "NM_DISCIPLINA";

            }
            else if (VarGlobal.tipo_login == "SECRETARIA" || VarGlobal.tipo_login == "COORDENADOR")
            {


                DisciplinaBLL obj = new DisciplinaBLL();
                comboBox1.DataSource = obj.Listagem("");

                comboBox1.DisplayMember = "NM_DISCIPLINA";
            }

            /* DisciplinaBLL obj = new DisciplinaBLL();
             comboBox1.DataSource = obj.Listagem("");

             comboBox1.DisplayMember = "NM_DISCIPLINA";*/

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtcodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtCodMatricua.Text = dataGridView1[1, fila].Value.ToString();
            txtCodDisciplina.Text = dataGridView1[2, fila].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotaBLL objE = new NotaBLL();
            dataGridView1.DataSource = objE.Listagem(Convert.ToString(comboBox1.Text));
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "") { MessageBox.Show("tem que selecionar o aluno"); }
             try
            {
                NotaBLL cur = new NotaBLL();
                NotaInformation inc = new NotaInformation();
                inc.nota_aluno= float.Parse(txtNota.Text);
                inc.data_aval = DateTime.Parse(dtpres.Text);
                inc.cd_Matricula = int.Parse(txtCodMatricua.Text);
                inc.cd_disciplina = int.Parse(txtCodDisciplina.Text);


                cur.Incluir(inc);

                txtcodigo.Text = Convert.ToString(inc.cd_Nota);

                MessageBox.Show("Curso incluido com sucesso");

            }
            catch (Exception ex)
             {
                MessageBox.Show("tem que selecionar o aluno para incluir NOTA " + ex.Message);
             }

        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            frmNOaltera frN = new frmNOaltera();
            this.Hide();
            frN.ShowDialog();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmAvaliation frA = new frmAvaliation();
            this.Hide();
            frA.ShowDialog();

        }

       
        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtCodDisciplina.Text = "";
            txtcodigo.Text = "";
            txtCodMatricua.Text = "";
            txtNota.Text = "";
        }
    }
}
