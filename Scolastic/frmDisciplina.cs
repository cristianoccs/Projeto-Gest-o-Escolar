using System;
using Scolastic.Modelos;
using Scolastic.Regra_Bll;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace Scolastic
{
    public partial class frmDisciplina : Form
    {
        
        public frmDisciplina()
        {
            InitializeComponent();
        }

       
        private void frmDisciplina_Load(object sender, EventArgs e)
        {
            txtCodigoTurmar.Text = Convert.ToString(VarGlobal.cd_ds_tur);
            txtCodProfessor.Text = Convert.ToString(VarGlobal.cd_ds_pro);
            AtualizaGrid();
        }

       

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
             txtNome.Text= dataGridView1[1, fila].Value.ToString();
            txtCargaHoraria.Text = dataGridView1[2, fila].Value.ToString();
            txtCodProfessor.Text = dataGridView1[3, fila].Value.ToString();
            txtCodigoTurmar.Text = dataGridView1[4, fila].Value.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            frmPrincipal fp = new frmPrincipal();
            this.Hide();
            fp.ShowDialog();
        }
        

        private void btCodTurma_Click(object sender, EventArgs e)
        {
            frmcodTurma fpt = new frmcodTurma();
            this.Hide();
            fpt.ShowDialog();
            



        }

               
        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtCargaHoraria.Text = "";
           // txtCodigoTurmar.Text = "";
           // txtCodProfessor.Text = "";
        }

        private void btcodProf_Click(object sender, EventArgs e)
        {
            frmcodProf fpp = new frmcodProf();
            this.Hide();
            fpp.ShowDialog();
        }

        public void AtualizaGrid()
        {


            DisciplinaBLL bje = new DisciplinaBLL();
            dataGridView1.DataSource = bje.Listagem("");

            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtNome.Text = dataGridView1[1, fila].Value.ToString();
            txtCargaHoraria.Text = dataGridView1[2, fila].Value.ToString();
            //txtCodProfessor.Text = dataGridView1[3, fila].Value.ToString();
            //txtCodigoTurmar.Text = dataGridView1[4, fila].Value.ToString();


        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DisciplinaBLL cur = new DisciplinaBLL();
                DisciplinaInformation inc = new DisciplinaInformation();
                inc._disciplina = txtNome.Text;
                inc._horaria = txtCargaHoraria.Text;
                inc.cd_turma = Convert.ToInt32(txtCodigoTurmar.Text);
                inc.cd_professor = Convert.ToInt32(txtCodProfessor.Text);


                cur.Incluir(inc);

                //txtCodigo.Text = Convert.ToString(inc.cd_disciplina);

                MessageBox.Show("Curso incluido com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro na aplicação  " + ex.Message);
            }
            AtualizaGrid();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {

            try
            {
                DisciplinaBLL at = new DisciplinaBLL();
                DisciplinaInformation incls = new DisciplinaInformation();
                incls.cd_disciplina = int.Parse(txtCodigo.Text);
                incls._disciplina = txtNome.Text;
                incls._horaria = txtCargaHoraria.Text;
                incls.cd_turma = int.Parse(txtCodigoTurmar.Text);
                incls.cd_professor = int.Parse(txtCodProfessor.Text);


                at.Alterar(incls);

                txtCodigo.Text = Convert.ToString(incls.cd_disciplina);

                MessageBox.Show("Disciplina alterado com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro na aplicação  " + ex.Message);
            }
            AtualizaGrid();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text.Length == 0) { MessageBox.Show("deve selecionar o Curso PARA EXCLUIR"); }
            else try
                {
                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    DisciplinaBLL obj = new DisciplinaBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("Escluido com sucesso");



                    AtualizaGrid();
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DisciplinaBLL bj = new DisciplinaBLL();
            dataGridView1.DataSource = bj.Listagem(textBox1.Text);

            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtNome.Text = dataGridView1[1, fila].Value.ToString();
            txtCargaHoraria.Text = dataGridView1[2, fila].Value.ToString();
            txtCodProfessor.Text = dataGridView1[3, fila].Value.ToString();
            txtCodigoTurmar.Text = dataGridView1[4, fila].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtNome.Text = dataGridView1[1, fila].Value.ToString();
            txtCargaHoraria.Text = dataGridView1[2, fila].Value.ToString();
            txtCodProfessor.Text = dataGridView1[3, fila].Value.ToString();
            txtCodigoTurmar.Text = dataGridView1[4, fila].Value.ToString();
        }
    }
}
