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
using Regra_Bll;

namespace Scolastic
{
    public partial class frmCriarLogin : Form
    {
        LogiBLL clslogin = new LogiBLL();
        LogiInformation cllogin = new LogiInformation();
        
       
        
        public frmCriarLogin()
        {
            InitializeComponent();
        }

        public void Limpa() {
            txtUser.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            txtCodMatric.Text = "";
        }
        public void AtualizaGrid()
        {
            LogiBLL obj = new LogiBLL();
            dataGridView1.DataSource = obj.Lista_login("");


            int fila = dataGridView1.CurrentCell.RowIndex;

            txt_codigo.Text = dataGridView1[0, fila].Value.ToString();
            txtUser.Text = dataGridView1[1, fila].Value.ToString();
            textBox3.Text = dataGridView1[2, fila].Value.ToString();
            comboBox1.Text = dataGridView1[3, fila].Value.ToString();
           // txtCodMatric.Text = dataGridView1[4, fila].Value.ToString();
          //  mat =Convert.ToInt32(dataGridView1[4, fila].Value.ToString());
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pic_SAIR_CRIAR_LOGIN_Click(object sender, EventArgs e)
        {
            frmPrincipal f = new frmPrincipal();
            this.Hide();
            f.ShowDialog();
        }

        private void frmCriarLogin_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clslogin.Lista_login(txtLista.Text);
            comboBox1.DataSource = cllogin.id_tipo;

            txtCodMatric.Text = Convert.ToString(VarGlobal.cd_mat_login);
            
            //LogiInformation ms = new LogiInformation();

            // MatriculaBLL M = new MatriculaBLL();
            // cblogin.DataSource = M.Listagem("");
            //ms.id_tipo
            // textBox1.Text= cblogin.SelectedValue.ToString();
            //cblogin.ValueMember = "PK_CD_MATRICULA";
            // cblogin.DisplayMember = "NOME ALUNO";

        }



        private void txtLista_TextChanged(object sender, EventArgs e)
        {
            /* cllogin.logim = txtLista.Text;
             DataTable dt = new DataTable();
             dt = clslogin.buscar_login(cllogin);
             dataGridView1.DataSource= dt;*/
            LogiBLL l = new LogiBLL();
            dataGridView1.DataSource = l.Lista_login(txtLista.Text);

            int fila = dataGridView1.CurrentCell.RowIndex;

            txt_codigo.Text = dataGridView1[0, fila].Value.ToString();
            txtUser.Text = dataGridView1[1, fila].Value.ToString();
            textBox3.Text = dataGridView1[2, fila].Value.ToString();
            comboBox1.Text = dataGridView1[3, fila].Value.ToString();
           // txtCodMatric.Text = dataGridView1[4, fila].Value.ToString();
            //  mat = Convert.ToInt32(dataGridView1[4, fila].Value.ToString());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txt_codigo.Text = dataGridView1[0, fila].Value.ToString();
            txtUser.Text = dataGridView1[1, fila].Value.ToString();
            textBox3.Text = dataGridView1[2, fila].Value.ToString();
            comboBox1.Text = dataGridView1[3, fila].Value.ToString();
           // txtCodMatric.Text = dataGridView1[4, fila].Value.ToString();

        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            cllogin.logim = txtUser.Text;
            cllogin.senha = textBox3.Text;
            cllogin.id_tipo = Convert.ToString(comboBox1.Text);
            cllogin.Num_matric = Convert.ToInt32(txtCodMatric.Text);
            

            clslogin.incluir_login(cllogin);

            txt_codigo.Text = Convert.ToString(cllogin.id_login);
            

            AtualizaGrid();
            Limpa();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {


            if (txt_codigo.Text == "") { MessageBox.Show("tem que selecionar"); }
            else try
                {
                    LogiInformation logobj = new LogiInformation();
                    logobj.id_login = int.Parse(txt_codigo.Text);
                    logobj.logim = txtUser.Text;
                    logobj.senha = textBox3.Text;
                    logobj.id_tipo = Convert.ToString(comboBox1.Text);
                    txt_codigo.Text = Convert.ToString(cllogin.id_login);


                    LogiBLL obj = new LogiBLL();
                    obj.alterar_login(logobj);

                    
                }
                catch { MessageBox.Show("Na aplicação erro"); }
            Limpa();

            AtualizaGrid();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text.Length == 0) { MessageBox.Show("deve selecionar o curso PARA EXCLUIR"); }
            else try
                {
                    int codigo = Convert.ToInt32(txt_codigo.Text);
                    LogiBLL obj = new LogiBLL();
                    obj.excluir(codigo);
                    MessageBox.Show("Escluido com sucesso");


                    Limpa();

                    AtualizaGrid();
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            Limpa();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCriaUsAluno frus = new frmCriaUsAluno();
            this.Hide();
            frus.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCriarUrProf frus = new frmCriarUrProf();
            this.Hide();
            frus.ShowDialog();
        }

        /* private void cblogin_SelectedIndexChanged(object sender, EventArgs e)
         {
             LogiBLL obj = new LogiBLL();
            dataGridView1.DataSource =  obj.Lista_login(cblogin.Text);
             //textBox1.Text = Convert.ToString(cblogin.ValueMember = "PK_CD_MATRICULA");
            // cblogin.DisplayMember = "NM_ALUNOM";
         }*/
    }
}

