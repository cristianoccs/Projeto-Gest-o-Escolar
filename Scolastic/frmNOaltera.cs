using Scolastc.Modelos;
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
    public partial class frmNOaltera : Form
    {
        public frmNOaltera()
        {
            InitializeComponent();
        }

        private void frmNOaltera_Load(object sender, EventArgs e)
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
            comboBox1.DataSource = obj.Listagem("");

            comboBox1.DisplayMember = "NM_DISCIPLINA";*/
        }
        public void limpar (){
            txtCodDisciplina.Text = "";
            txtcodigo.Text = "";
            txtCodMatricua.Text = "";
            txtNota.Text = "";
            txtNomeAluno.Text = "";
        }
        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "") { MessageBox.Show("tem que selecionar ALUNO"); }
            else try
                {

                    NotaInformation alt = new NotaInformation();
                     alt.cd_Nota = int.Parse(txtcodigo.Text);
                    alt.nota_aluno = float.Parse(txtNota.Text);
                    alt.data_aval = DateTime.Parse(dtpres.Text);
                    alt.cd_Matricula = int.Parse(txtCodMatricua.Text);
                    alt.cd_disciplina = int.Parse(txtCodDisciplina.Text);

                    NotaBLL obj = new NotaBLL();
                    obj.Alterar(alt);
                    txtcodigo.Text = Convert.ToString(alt.cd_Nota);

                    MessageBox.Show("Presesa ALTERADO com sucess");
                    
                }
                catch { MessageBox.Show("tem que Inserir a nota: "); }
            atualizaGrid();
            limpar();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text.Length == 0) { MessageBox.Show("deve selecionar o aluno PARA EXCLUIR"); }
            else try
                {
                    int codigo = Convert.ToInt32(txtcodigo.Text);


                    NotaBLL obj = new NotaBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("Escluido com sucesso");



                    
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                                   
            limpar();
            atualizaGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dataGridView1.CurrentCell.RowIndex;

            txtNomeAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtCodMatricua.Text = dataGridView1[1, fila].Value.ToString();
            txtCodDisciplina.Text = dataGridView1[2, fila].Value.ToString();
            txtcodigo.Text = dataGridView1[4, fila].Value.ToString();
        
         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotaBLL objL = new NotaBLL();
            dataGridView1.DataSource = objL.Listageml(comboBox1.Text);
        }

        public void atualizaGrid() {

            NotaBLL objL = new NotaBLL();
            dataGridView1.DataSource = objL.Listageml(comboBox1.Text);
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtNomeAluno.Text = dataGridView1[0, fila].Value.ToString();
            txtCodMatricua.Text = dataGridView1[1, fila].Value.ToString();
            txtCodDisciplina.Text = dataGridView1[2, fila].Value.ToString();
             txtcodigo.Text = dataGridView1[4, fila].Value.ToString();
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmNota frA = new frmNota();
            this.Hide();
            frA.ShowDialog();
        }
    }
    }
