using Modelos;
using Regra_Bll;
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
    public partial class frmMatricula : Form
    {
        public frmMatricula()
        {
            InitializeComponent();
        }
        public void AtualizaGrid()
        {
            MatriculaBLL obj = new MatriculaBLL();
            dataGridView1.DataSource = obj.Listagem("");


            int fila = dataGridView1.CurrentCell.RowIndex;

            txtMatricual.Text = dataGridView1[2,fila].Value.ToString();
            //txtAluno.Text = dataGridView1[1, fila].Value.ToString();
            //txtTurma.Text = dataGridView1[2, fila].Value.ToString();
            //txtCurso.Text = dataGridView1[3, fila].Value.ToString();
        }
        public void limpar() {
            txtMatricual.Text = "";
            txtAluno.Text = "";
            txtTurma.Text = "";
            txtCurso.Text = "";
        }
        private void frmMatricula_Load(object sender, EventArgs e)
        {
            txtTurma.Text = Convert.ToString(VarGlobal.cd_ds_tur);
            txtAluno.Text = Convert.ToString(VarGlobal.cd_ms_aluno);
            txtCurso.Text = Convert.ToString(VarGlobal.cd_ms_curso);
            txtNM_Aluno.Text = VarGlobal.NM_aluno;
            AtualizaGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtMatricual.Text = dataGridView1[2, fila].Value.ToString();
            txtAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtTurma.Text = dataGridView1[3, fila].Value.ToString();
            txtCurso.Text = dataGridView1[4, fila].Value.ToString();
            txtNM_Aluno.Text = dataGridView1[1, fila].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPrincipal f = new frmPrincipal();
            this.Hide();
            f.ShowDialog();
        }

        private void btCodTurma_Click(object sender, EventArgs e)
        {
            frmcoMTurma fmcTur = new frmcoMTurma();
            this.Hide();
            fmcTur.ShowDialog();
        }

       

        private void btCodAluno_Click(object sender, EventArgs e)
        {
            frmcoMAluno fmcAl = new frmcoMAluno();
            this.Hide();
            fmcAl.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtMatricual.Text = dataGridView1[2, fila].Value.ToString();
            txtAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtTurma.Text = dataGridView1[3, fila].Value.ToString();
            txtCurso.Text = dataGridView1[4, fila].Value.ToString();
            txtNM_Aluno.Text = dataGridView1[1, fila].Value.ToString();
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                MatriculaBLL cur = new MatriculaBLL();
                MatriculaInformation inc = new MatriculaInformation();
                
                inc.cd_aluno = Convert.ToInt32(txtAluno.Text);
                inc.cd_turma = Convert.ToInt32(txtTurma.Text);
                inc.cd_curso = Convert.ToInt32(txtCurso.Text);
                inc.NM_aluno = txtNM_Aluno.Text;


                cur.Incluir(inc);

                //txtCodigo.Text = Convert.ToString(inc.cd_disciplina);

                MessageBox.Show("Curso incluido com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro na aplicação  " + ex.Message);
            }
            AtualizaGrid();
            limpar();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {

            try
            {
                MatriculaBLL at = new MatriculaBLL();
                MatriculaInformation incls = new MatriculaInformation();
                incls.cd_matricula = int.Parse(txtMatricual.Text);
                incls.cd_aluno = Convert.ToInt32(txtAluno.Text);
                incls.cd_turma = Convert.ToInt32(txtTurma.Text);
                incls.cd_curso = Convert.ToInt32(txtCurso.Text);
                incls.NM_aluno = txtNM_Aluno.Text;


                at.Alterar(incls);

                txtMatricual.Text = Convert.ToString(incls.cd_matricula);

                MessageBox.Show("Disciplina alterado com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro na aplicação  " + ex.Message);
            }
            limpar();
            AtualizaGrid();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (txtMatricual.Text.Length == 0) { MessageBox.Show("deve selecionar a Matricula PARA EXCLUIR"); }
            else try
                {
                    int codigo = Convert.ToInt32(txtMatricual.Text);
                    MatriculaBLL obj = new MatriculaBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("Escluido com sucesso");


                    limpar();
                    AtualizaGrid();
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtMatricual.Text = "";
            txtAluno.Text = "";
            txtTurma.Text = "";
            txtCurso.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MatriculaBLL objes = new MatriculaBLL();
            dataGridView1.DataSource = objes.Listagem(textBox1.Text);


            int fila = dataGridView1.CurrentCell.RowIndex;

            
            txtMatricual.Text = dataGridView1[2, fila].Value.ToString();
            txtAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtTurma.Text = dataGridView1[3, fila].Value.ToString();
            txtCurso.Text = dataGridView1[4, fila].Value.ToString();
            txtNM_Aluno.Text = dataGridView1[1, fila].Value.ToString();
        }
    }
}
