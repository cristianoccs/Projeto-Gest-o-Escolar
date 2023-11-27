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
    public partial class frmProfessor : Form
    {
        public frmProfessor()
        {
            InitializeComponent();
        }

        public void AtualizaGrid()
        {
            ProfessorBLL obj = new ProfessorBLL();
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
            txtTitulo.Text = dataGridView1[11, fila].Value.ToString();
            dateTimeNasci.Text = dataGridView1[12, fila].Value.ToString();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ProfessorBLL l = new ProfessorBLL();
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
                txtTitulo.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString();
                txtEmail.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString();
                dateTimeNasci.Text = dataGridView1[12, dataGridView1.CurrentRow.Index].Value.ToString();
                //AtualizaGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                ProfessorBLL obj = new ProfessorBLL();
                ProfessorInformation incp = new ProfessorInformation();

                incp._professor = txtNome.Text;
                incp.cpf = txtCPF.Text;
                incp.rg = txtRG.Text;
                incp.sexo = cbSexo.Text;
                incp.cidade = txtCidade.Text;
                incp.end_cid = txtEndereco.Text;
                incp.end_bair = txtBairro.Text;
                incp.cep = txtCEP.Text;
                incp.telefone = txtTelefone.Text;
                incp.t_academico = txtTitulo.Text;
                incp.email = txtEmail.Text;
                incp.nascimento = DateTime.Parse(dateTimeNasci.Text);



                obj.Incluir(incp);
                txtCodigo.Text = Convert.ToString(incp.cd_professor);
                MessageBox.Show("Aluno incluido com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro na aplicação  " + ex.Message);
            }
            AtualizaGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPrincipal f = new frmPrincipal();
            this.Hide();
            f.ShowDialog();
        }

        private void frmProfessor_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
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
                ProfessorBLL obj = new ProfessorBLL();
                ProfessorInformation incp = new ProfessorInformation();

                incp.cd_professor = int.Parse(txtCodigo.Text);
                incp._professor = txtNome.Text;
                incp.cpf = txtCPF.Text;
                incp.rg = txtRG.Text;
                incp.sexo = cbSexo.Text;
                incp.cidade = txtCidade.Text;
                incp.end_cid = txtEndereco.Text;
                incp.end_bair = txtBairro.Text;
                incp.cep = txtCEP.Text;
                incp.telefone = txtTelefone.Text;
                incp.t_academico = txtTitulo.Text;
                incp.email = txtEmail.Text;
                incp.nascimento = DateTime.Parse(dateTimeNasci.Text);



                obj.Alterar(incp);
                txtCodigo.Text = Convert.ToString(incp.cd_professor);
                MessageBox.Show("Professor atualizado com sucesso");

            }
           catch (Exception ex)
            {
                MessageBox.Show("erro na aplicação  " + ex.Message);
            }
            AtualizaGrid();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0) { MessageBox.Show("deve selecionar o aluno PARA EXCLUIR"); }
            else try
                {
                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    ProfessorBLL obj = new ProfessorBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("Escluido com sucesso");



                   
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            txtTitulo.Text = dataGridView1[11, fila].Value.ToString();
            dateTimeNasci.Text = dataGridView1[12, fila].Value.ToString();
        }
    }
    
}
