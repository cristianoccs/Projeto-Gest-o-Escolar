using Scolastc.Modelos;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scolastic
{
    public partial class frmAValtera : Form
    {
        public frmAValtera()
        {
            InitializeComponent();
        }
        public void limpar()
        {
            txtM_nmAluno.Text = "";
            txtCodDisciplina.Text = "";
            txtCodMatricua.Text = "";
            txtCodigo.Text = "";
        }

        public void atualizaGrid() {
            AvaliationBLL objL = new AvaliationBLL();
            dataGridView1.DataSource = objL.Listageml(comboBox1.Text);
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtM_nmAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtCodMatricua.Text = dataGridView1[1, fila].Value.ToString();
            txtCodDisciplina.Text = dataGridView1[2, fila].Value.ToString();
            txtCodigo.Text = dataGridView1[5, fila].Value.ToString();
        }
        private void frmAValtera_Load(object sender, EventArgs e)
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

            /*DisciplinaBLL obj = new DisciplinaBLL();
            comboBox1.DataSource = obj.Listagem("");*/

            comboBox1.DisplayMember = "NM_DISCIPLINA";
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            frmAvaliation fr = new frmAvaliation();
            this.Hide();
            fr.ShowDialog();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtM_nmAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtCodMatricua.Text = dataGridView1[1, fila].Value.ToString();
            txtCodDisciplina.Text = dataGridView1[2, fila].Value.ToString();
            txtCodigo.Text = dataGridView1[5, fila].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AvaliationBLL objL = new AvaliationBLL();
            dataGridView1.DataSource = objL.Listageml(comboBox1.Text);
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (txtM_nmAluno.Text == "") { MessageBox.Show("tem que selecionar o aluno"); }
            else try
                {
                    AvaliationBLL cur = new AvaliationBLL();
                    AvaliationInformation inc = new AvaliationInformation();
                    inc.cd_avaliation = Convert.ToInt32(txtCodigo.Text);
                    inc.data_aval = DateTime.Parse(dtpres.Text);
                    inc.frequencia = char.Parse(cbPresenca.Text);
                    inc.cd_Matricula = int.Parse(txtCodMatricua.Text);
                    inc.cd_disciplina = int.Parse(txtCodDisciplina.Text);


                    cur.Alterar(inc);

                    txtCodigo.Text = Convert.ToString(inc.cd_avaliation);

                    MessageBox.Show(" incluido com sucesso");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("tem que Inserir a presença:  " + ex.Message);
                }
            limpar();
            atualizaGrid();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            

            int codigo = Convert.ToInt32(txtCodigo.Text);


            AvaliationBLL obj = new AvaliationBLL();
            obj.Excluir(codigo);
            MessageBox.Show("Escluido com sucesso");

            limpar();
            atualizaGrid();
        }

        
    }
    
}
