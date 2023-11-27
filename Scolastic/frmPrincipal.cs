using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scolastic.Modelos;
using Scolastic.Regra_Bll;
using System.Windows.Forms;

namespace Scolastic
{
    public partial class frmPrincipal : Form
    {

        LogiInformation objM = new LogiInformation();
        LogiBLL objBll = new LogiBLL();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = frmLogin.usuario_nome;

            if (frmLogin.id_tipo == "ALUNO")
            {
                pictureBox1.Enabled = false;
                pictureBox3.Enabled = true;
                pictureBox2.Enabled = false;
                pictureBox4.Enabled = false;
                pictureBox5.Enabled = false;
                panel3.Enabled = false;

            }
            else if (frmLogin.id_tipo == "PROFESSOR")
            {

                pictureBox1.Enabled = false;
                pictureBox3.Enabled = true;
                pictureBox2.Enabled = false;
                pictureBox4.Enabled = true;
                pictureBox5.Enabled = false;
                panel3.Enabled = false;

            }
            else if (frmLogin.id_tipo == "SECRETARIA")
            {

                pictureBox1.Enabled = false;
                pictureBox3.Enabled = true;
                pictureBox2.Enabled = true;
                pictureBox4.Enabled = true;
                pictureBox5.Enabled = true;
                panel3.Enabled = false;

            }
            Hora.Start();

        }

        private void CADASTROS_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("H: m:s");
            lblData.Text = DateTime.Now.ToString("D");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmCriarLogin f = new frmCriarLogin();
            this.Hide();
            f.ShowDialog();

        }

        private void Mecad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cURSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurso frmCurso = new frmCurso();
            this.Hide();
            frmCurso.ShowDialog();
        }

        private void aLUNOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAluno fr = new frmAluno();
            this.Hide();
            fr.ShowDialog();
        }

        private void pROFESSORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfessor fp = new frmProfessor();
            this.Hide();
            fp.ShowDialog();
        }

        private void tURMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTurma ftu = new frmTurma();
            this.Hide();
            ftu.ShowDialog();
        }

        private void dISCIPLINAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDisciplina fdis= new frmDisciplina();
            this.Hide();
            fdis.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmMatricula fM = new frmMatricula();
            this.Hide();
            fM.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           frmAvaliation fA = new frmAvaliation();
            this.Hide();
            fA.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(VarGlobal.tipo_login == "ALUNO") {
                frmConsulta frcons = new frmConsulta();
                this.Hide();
                frcons.ShowDialog();
            }
           else if (VarGlobal.tipo_login == "PROFESSOR" || VarGlobal.tipo_login == "SECRETARIA" || VarGlobal.tipo_login == "COORDENADOR"){
                frmConsutlaAcomp fm = new frmConsutlaAcomp();
                this.Hide();
                fm.ShowDialog(); }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frmLogin frlog = new frmLogin();
            this.Hide();
            frlog.ShowDialog();
        }
    }
}
