using Scolastic.Modelos;
using Scolastic.Regra_Bll;
using Scolastic.Dados_Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scolastic
{
    public partial class frmAluno : Form
    {
        public frmAluno()
        {
            InitializeComponent();
        }
        public void Limpar()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            dateTimeNasci.Text = "";
            txtRG.Text = "";
            txtCPF.Text = "";
            cbSexo.Text = "";
            txtCidade.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";

        }
        public void AtualizaGrid()
         {
            AlunoBLL obj = new AlunoBLL();
             dataGridView1.DataSource = obj.Listagem("");


             int fila = dataGridView1.CurrentCell.RowIndex;

             txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
             txtNome.Text = dataGridView1[1, fila].Value.ToString();
             txtRG.Text = dataGridView1[2, fila].Value.ToString();
             txtCPF.Text = dataGridView1[3, fila].Value.ToString();
             cbSexo.Text = dataGridView1[4, fila].Value.ToString();
             txtCidade.Text = dataGridView1[5, fila].Value.ToString();
             txtEndereco.Text = dataGridView1[6, fila].Value.ToString();
             txtBairro.Text = dataGridView1[7, fila].Value.ToString();
             txtCEP.Text = dataGridView1[8, fila].Value.ToString();
             txtTelefone.Text = dataGridView1[9, fila].Value.ToString();
             txtEmail.Text = dataGridView1[10, fila].Value.ToString();
            dateTimeNasci.Text = dataGridView1[11, fila].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AlunoBLL l = new AlunoBLL();
            dataGridView1.DataSource = l.Listagem(txtBuscar.Text);
            try
            {
                txtCodigo.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                txtNome.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                txtRG.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCPF.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                cbSexo.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCidade.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
                txtEndereco.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                txtBairro.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCEP.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString();
                txtTelefone.Text = dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString();
                txtEmail.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString();
                dateTimeNasci.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString();
                //AtualizaGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void frmAluno_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
           // AlunoBLL l = new AlunoBLL();
            
           // comboBox1.Items.Clear();
           // comboBox1.DataSource = l.lista_aluno();
           // comboBox1.DisplayMember = "NM_ALUNO";

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPrincipal f = new frmPrincipal();
            this.Hide();
            f.ShowDialog();
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoBLL obj = new AlunoBLL();
                AlunoInformation inclu = new AlunoInformation();

                inclu._aluno = txtNome.Text;
                inclu.cpf = txtCPF.Text;
                inclu.rg = txtRG.Text;
                inclu.sexo = cbSexo.Text;
                inclu.cidade = txtCidade.Text;
                inclu.end_cid = txtEndereco.Text;
                inclu.end_bair = txtBairro.Text;
                inclu.cep = txtCEP.Text;
                inclu.telefone = txtTelefone.Text;
                inclu.email = txtEmail.Text;
                inclu.nascimento = DateTime.Parse(dateTimeNasci.Text);
       
                 
                 
                obj.Incluir(inclu);
                txtCodigo.Text = Convert.ToString(inclu.cd_aluno);
                MessageBox.Show("Aluno incluido com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro na aplicação  " + ex.Message);
            }

            AtualizaGrid();
            Limpar();
        }

        private void btLimpa_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text == "") { MessageBox.Show("tem que selecionar"); }
            else try
                {
                                       
                    AlunoInformation alt = new AlunoInformation();
                    
                    alt.cd_aluno = int.Parse(txtCodigo.Text);
                    alt._aluno = txtNome.Text;
                    alt.nascimento = DateTime.Parse(dateTimeNasci.Text); 
                     alt.rg = txtRG.Text;
                    alt.cpf = txtCPF.Text;
                    alt.sexo =  cbSexo.Text;
                    alt.cidade = txtCidade.Text;
                    alt.end_cid = txtEndereco.Text;
                    alt.end_bair = txtBairro.Text;
                    alt.cep = txtCEP.Text;
                    alt.telefone = txtTelefone.Text;
                    alt.email = txtEmail.Text;
                   // txtCodigo.Text = Convert.ToString(alt.cd_aluno);
                    //MessageBox.Show("Data " + dateTimeNasci);
                    AlunoBLL obj = new AlunoBLL();
                    obj.Altera(alt);
                     
                   
                    MessageBox.Show("Aluno ALTERADO com sucesso");


                 


                }
                catch { MessageBox.Show("Na aplicação erro na alteração"); }

            Limpar();
            AtualizaGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtNome.Text = dataGridView1[1, fila].Value.ToString();
            txtRG.Text = dataGridView1[2, fila].Value.ToString();
            txtCPF.Text = dataGridView1[3, fila].Value.ToString();
            cbSexo.Text = dataGridView1[4, fila].Value.ToString();
            txtCidade.Text = dataGridView1[5, fila].Value.ToString();
            txtEndereco.Text = dataGridView1[6, fila].Value.ToString();
            txtBairro.Text = dataGridView1[7, fila].Value.ToString();
            txtCEP.Text = dataGridView1[8, fila].Value.ToString();
            txtTelefone.Text = dataGridView1[9, fila].Value.ToString();
            txtEmail.Text = dataGridView1[10, fila].Value.ToString();
            dateTimeNasci.Text = dataGridView1[11, fila].Value.ToString();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0) { MessageBox.Show("deve selecionar o aluno PARA EXCLUIR"); }
            else try
                {
                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    AlunoBLL obj = new AlunoBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("Escluido com sucesso");



                    AtualizaGrid();
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlunoBLL l = new AlunoBLL();

            //comboBox1.Items.Clear();
           /// comboBox1.DataSource = l.lista_aluno();
            //comboBox1.DisplayMember = "NM_ALUNO";
           // comboBox1.Text = comboBox1.DisplayMember;
           // if (comboBox1.Text == comboBox1.DisplayMember)
            {

                int fila = dataGridView1.CurrentCell.RowIndex;

                txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
                txtNome.Text = dataGridView1[1, fila].Value.ToString();
                txtRG.Text = dataGridView1[2, fila].Value.ToString();
                txtCPF.Text = dataGridView1[3, fila].Value.ToString();
                cbSexo.Text = dataGridView1[4, fila].Value.ToString();
                txtCidade.Text = dataGridView1[5, fila].Value.ToString();
                txtEndereco.Text = dataGridView1[6, fila].Value.ToString();
                txtBairro.Text = dataGridView1[7, fila].Value.ToString();
                txtCEP.Text = dataGridView1[8, fila].Value.ToString();
                txtTelefone.Text = dataGridView1[9, fila].Value.ToString();
                txtEmail.Text = dataGridView1[10, fila].Value.ToString();
                dateTimeNasci.Text = dataGridView1[11, fila].Value.ToString();

            }
        }
    }
}
