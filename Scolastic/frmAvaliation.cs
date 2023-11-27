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
    public partial class frmAvaliation : Form
    {
        public frmAvaliation()
        {
            InitializeComponent();
        }
        string var;
        private void txtCodDisciplina_TextChanged(object sender, EventArgs e)
        {

        }
        public void atualizaGrid() {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtM_nmAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtCodMatricua.Text = dataGridView1[1, fila].Value.ToString();
            txtCodDisciplina.Text = dataGridView1[2, fila].Value.ToString();
           // txtcodigo.Text = dataGridView1[5, fila].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

           txtM_nmAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtCodMatricua.Text = dataGridView1[1, fila].Value.ToString();
           txtCodDisciplina.Text = dataGridView1[2, fila].Value.ToString();
           // txtcodigo.Text = dataGridView1[5, fila].Value.ToString();


                           
                              


        }

        public void limpar()
        {
            txtcodigo.Text = "";
            txtCodDisciplina.Text = "";
            txtCodMatricua.Text = "";
        }

        private void frmAvaliation_Load(object sender, EventArgs e)
        {
            

            if (VarGlobal.tipo_login == "PROFESSOR") {

                DisciplinaBLL obj = new DisciplinaBLL();
                comboBox1.DataSource = obj.Listageml("",Convert.ToInt32(VarGlobal.cd_mat_login));

                
                comboBox1.DisplayMember = "NM_DISCIPLINA";

            } else if (VarGlobal.tipo_login == "SECRETARIA"|| VarGlobal.tipo_login == "COORDENADOR") {


                DisciplinaBLL obj = new DisciplinaBLL();
                comboBox1.DataSource = obj.Listagem("");

                comboBox1.DisplayMember = "NM_DISCIPLINA"; }
           //int fila = dataGridView1.CurrentCell.RowIndex;

           // txtcodigo.Text = dataGridView1[0, fila].Value.ToString();
           // txtCodMatricua.Text = dataGridView1[1, fila].Value.ToString();
            //comboBox1.Text = dataGridView1[4, fila].Value.ToString();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPrincipal f = new frmPrincipal();
            this.Hide();
            f.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



            AvaliationBLL objee = new AvaliationBLL();
            dataGridView1.DataSource = objee.Listagem(comboBox1.Text);

            

        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
             if (txtM_nmAluno.Text == "") { MessageBox.Show("tem que selecionar o aluno"); }
             else try
            {
                AvaliationBLL cur = new AvaliationBLL();
                AvaliationInformation inc = new AvaliationInformation();
                //in = Convert.ToString(txtNota.Text);
                inc.data_aval =  DateTime.Parse(dtpres.Text);
                inc.frequencia = char.Parse(cbPresenca.Text);
                inc.cd_Matricula = int.Parse(txtCodMatricua.Text);
                inc.cd_disciplina = int.Parse(txtCodDisciplina.Text);


                cur.Incluir(inc);

                txtcodigo.Text = Convert.ToString(inc.cd_avaliation);

                MessageBox.Show(" incluido com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show(" tem que selecionar A PRESENÇA:  " +  ex.Message);
            }
            limpar();
            atualizaGrid();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            frmAValtera alt = new frmAValtera();
            this.Hide();
            alt.ShowDialog();

           
        }

        private void btNota_Click(object sender, EventArgs e)
        {
            frmNota frN = new frmNota();
            this.Hide();
            frN.ShowDialog();

        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtcodigo.Text = "";
            txtM_nmAluno.Text = "";
            txtCodDisciplina.Text = "";
            txtCodMatricua.Text = "";

        }
    }
}
