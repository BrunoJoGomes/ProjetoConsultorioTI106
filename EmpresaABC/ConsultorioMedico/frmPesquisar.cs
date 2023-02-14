using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioMedico
{
    public partial class frmPesquisar : Form 
    {
        public frmPesquisar() //metodo contrutor vai carregar todos os componentes da janela
        {
            InitializeComponent();
            txtDescricao.Enabled = false;
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;
        }

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDescricao.Enabled = false;
            rdbNome.Checked = false;
            rdbCodigo.Checked = false;
            txtDescricao.Clear();
            ltbItemsPesquisados.Items.Clear();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbCodigo.Checked)
            {
                ltbItemsPesquisados.Items.Clear();
                ltbItemsPesquisados.Items.Add(txtDescricao.Text);
            }
            if (rdbNome.Checked)
            {
                //ltbItemsPesquisados.Items.Clear();
                ltbItemsPesquisados.Items.Add(txtDescricao.Text);
            }

        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            //Pegando o indice selecionado
            //int i = ltbItemsPesquisados.SelectedIndex;
            //MessageBox.Show("O índice selecionado foi: " + i);

            //Pegando o valor selecionado 
            //string valor = ltbItemsPesquisados.SelectedItem.ToString();
            //MessageBox.Show("O valor selecionado foi: " + valor);
        }

        private void ltbItemsPesquisados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ltbItemsPesquisados.SelectedIndex;
            string valor = ltbItemsPesquisados.SelectedItem.ToString();

            MessageBox.Show($"O índice selecionado foi: {indice} \n Valor selecionado foi: {valor}");
        }
    }
}
