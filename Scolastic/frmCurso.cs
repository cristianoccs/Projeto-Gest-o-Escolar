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
    public partial class frmCurso : Form
    {
        public frmCurso()
        {
            InitializeComponent();
        }
        public void AtualizaGrid()
        {
            CursoBLL obj = new CursoBLL();
            dataGridView1.DataSource = obj.Listagem("");


            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtCurso.Text = dataGridView1[1, fila].Value.ToString();
            txtTempo.Text = dataGridView1[2, fila].Value.ToString();
            
        }
        public void Limpar()
        {
            txtCurso.Text = "";
            txtCodigo.Text = "";
            txtTempo.Text = "";


        }
        private void btInculuir_Click(object sender, EventArgs e)
        {
            try
            {
                CursoBLL cur = new CursoBLL();
            CursoInformation inc = new CursoInformation();
            inc._curso = txtCurso.Text;
            inc.duracao_curso = txtTempo.Text;
           

            cur.Incluir(inc);

            txtCodigo.Text = Convert.ToString(inc.cd_curso);

                MessageBox.Show("Curso incluido com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro na aplicação  " + ex.Message);
            }
            AtualizaGrid();
        }

        private void Curso_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "") { MessageBox.Show("tem que selecionar"); }
            else try
                {

                    CursoInformation alt = new CursoInformation();

                    alt.cd_curso = int.Parse(txtCodigo.Text);
                    alt._curso = txtCurso.Text;
                    alt.duracao_curso= txtTempo.Text;
                  
                     
                    CursoBLL obj = new CursoBLL();
                    obj.Alterar(alt);
                    txtCodigo.Text = Convert.ToString(alt.cd_curso);

                    MessageBox.Show("curso ALTERADO com sucesso");

                }
                catch { MessageBox.Show("Na aplicação erro na alteração"); }

            Limpar();
            AtualizaGrid();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text.Length == 0) { MessageBox.Show("deve selecionar o Curso PARA EXCLUIR"); }
            else try
                {
                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    CursoBLL obj = new CursoBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("Escluido com sucesso");



                    AtualizaGrid();
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            Limpar();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CursoBLL l = new CursoBLL();
            dataGridView1.DataSource = l.Listagem(txtBuscar.Text);
            try
            {
                txtCodigo.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCurso.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                txtTempo.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
               
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void picsair_Click(object sender, EventArgs e)
        {
            frmPrincipal f = new frmPrincipal();
            this.Hide();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtCurso.Text = dataGridView1[1, fila].Value.ToString();
            txtTempo.Text = dataGridView1[2, fila].Value.ToString();
        }
    }
    
}
