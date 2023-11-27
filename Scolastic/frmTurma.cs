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

namespace Scolastic
{
    public partial class frmTurma : Form
    {
        public frmTurma()
        {
            InitializeComponent();
        }

        public void AtualizaGrid() {
            TurmaBLL obje = new TurmaBLL();
            dataGridView1.DataSource = obje.Listagem("");


            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtNome.Text = dataGridView1[1, fila].Value.ToString();
            cbPeriodo.Text = dataGridView1[2, fila].Value.ToString();
            txtAnoturma.Text = dataGridView1[3, fila].Value.ToString();
           // txtCodigoCurso.Text = dataGridView1[4, fila].Value.ToString();
           
            
        }
    

        private void frmTurma_Load(object sender, EventArgs e)
        {



            txtCodigoCurso.Text = Convert.ToString (VarGlobal.cd_tur_curso);
            AtualizaGrid();


         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           


            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtNome.Text = dataGridView1[1, fila].Value.ToString();
            cbPeriodo.Text = dataGridView1[2, fila].Value.ToString();
            txtAnoturma.Text = dataGridView1[3, fila].Value.ToString();
            txtCodigoCurso.Text = dataGridView1[5, fila].Value.ToString();
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            TurmaBLL l = new TurmaBLL();
            dataGridView1.DataSource = l.Listagem(txtBuscar.Text);
            try
            {
                txtCodigo.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                txtNome.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                cbPeriodo.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                txtAnoturma.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCodigoCurso.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                TurmaBLL cur = new TurmaBLL();
                TurmaInformation inc = new TurmaInformation();
                inc.NMturma = txtNome.Text;
                inc.periodo = cbPeriodo.Text;
                inc.ANOTURMA = txtAnoturma.Text;
                inc.cd_curso = int.Parse(txtCodigoCurso.Text);


                cur.Incluir(inc);

                txtCodigo.Text = Convert.ToString(inc.cd_turma);

                MessageBox.Show("Curso incluido com sucesso");

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

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "") { MessageBox.Show("tem que selecionar"); }
           else try
            {
                TurmaBLL TUR = new TurmaBLL();
                TurmaInformation alt = new TurmaInformation();
                 alt.cd_turma = int.Parse(txtCodigo.Text);
                alt.NMturma = txtNome.Text;
                alt.periodo = cbPeriodo.Text;
                alt.ANOTURMA = txtAnoturma.Text;
                alt.cd_curso = Convert.ToInt32(txtCodigoCurso.Text);


                TUR.Alterar(alt);

                txtCodigo.Text = Convert.ToString(alt.cd_turma);

                MessageBox.Show("alterad com sucesso");

             }
             catch (Exception ex)
             {
                MessageBox.Show("erro na aplicação  " + ex.Message);
             }

            AtualizaGrid();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0) { MessageBox.Show("deve selecionar a turma PARA EXCLUIR"); }
            else try
                {
                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    TurmaBLL obj = new TurmaBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("Escluido com sucesso");



                    
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
            AtualizaGrid();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtAnoturma.Text = "";
            txtCodigo.Text = "";
            txtCodigoCurso.Text = "";
            txtNome.Text = "";
            cbPeriodo.Text = "";
            
        }

        private void btCodCurso_Click(object sender, EventArgs e)
        {
            frmTurCurso fmcur = new frmTurCurso();
            this.Hide();
            fmcur.ShowDialog();
                 
            
        }

       
    }
    
}
