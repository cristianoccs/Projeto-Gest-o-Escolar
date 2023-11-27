﻿using Scolastic.Regra_Bll;
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
    public partial class frmTurCurso : Form
    {
        public frmTurCurso()
        {
            InitializeComponent();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CursoBLL l = new CursoBLL();
            dataGridView1.DataSource = l.Listagem(txtPesquisa.Text);
            try
            {

                txtCodCurso.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                //dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                //dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                VarGlobal.cd_tur_curso = Convert.ToInt32(txtCodCurso.Text);


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void frmMCurso_Load(object sender, EventArgs e)
        {
            CursoBLL obje = new CursoBLL();

            dataGridView1.DataSource = obje.Listagem("");


            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodCurso.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            //dataGridView1[3, fila].Value.ToString();
            //dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_tur_curso = Convert.ToInt32(txtCodCurso.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmTurma fM = new frmTurma();
            this.Hide();
            fM.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodCurso.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            //dataGridView1[3, fila].Value.ToString();
            //dataGridView1[4, fila].Value.ToString();
            VarGlobal.cd_tur_curso = Convert.ToInt32(txtCodCurso.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

              txtCodCurso.Text = dataGridView1[0, fila].Value.ToString();
            dataGridView1[1, fila].Value.ToString();
            dataGridView1[2, fila].Value.ToString();
            //dataGridView1[3, fila].Value.ToString();
            //dataGridView1[4, fila].Value.ToString();

            VarGlobal.cd_tur_curso = Convert.ToInt32(txtCodCurso.Text);

            frmTurma fmTur = new frmTurma();
            this.Hide();
            fmTur.ShowDialog();
        }
    }
}
