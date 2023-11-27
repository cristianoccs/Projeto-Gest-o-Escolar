using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scolastic.Modelos;
using Scolastic.Regra_Bll;

namespace Scolastic
{
    public partial class frmLogin : Form
    {
        LogiBLL logiuse = new LogiBLL();
        LogiInformation logisen = new LogiInformation();
        public static string usuario_nome;
        public static string id_tipo;
        public static string usuari_geral;
        public static String usuario_codigo;

        frmPrincipal fr = new frmPrincipal();

        public frmLogin()
        {
            InitializeComponent();
        }
        public void limpar()
        {
            TxtSenha.Text = "";
            TxtUser.Text = "";
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            logisen.logim = TxtUser.Text;
            logisen.senha = TxtSenha.Text;
            dt = logiuse.Logar(logisen);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bem vido " + dt.Rows[0][1].ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                id_tipo = dt.Rows[0][0].ToString();
                usuario_nome = dt.Rows[0][1].ToString();
                VarGlobal.cd_mat_login =Convert.ToInt32(dt.Rows[0][4].ToString());
                // usuari_geral = dt.Rows[0][2].ToString();
               // MessageBox.Show("valor cod matric"+ VarGlobal.cd_mat_login);
                VarGlobal.tipo_login = id_tipo;
                //Console.WriteLine(usuario_nome, id_tipo, usuari_geral);
                //usuario_codigo = dt.Rows[0][3].ToString();
                this.Hide();
                fr.ShowDialog();
                limpar();
            }
            else { MessageBox.Show("Usuario ou Senha erra", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
