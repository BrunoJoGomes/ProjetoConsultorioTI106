using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
                pesquisaCodigo(txtDescricao.Text);
            }
            else if (rdbNome.Checked)
            {
                //ltbItemsPesquisados.Items.Clear();
                ltbItemsPesquisados.Items.Add(txtDescricao.Text);
                pesquisaNome(txtDescricao.Text);
            }
            //else
            //{
            //    MessageBox.Show("Favor selecinar um item!");
            //    txtDescricao.Focus();
            //}

        }

        public void pesquisaCodigo(string codigo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbPaciente where codPac = "+codigo+";";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();
            
            ltbItemsPesquisados.Items.Clear();

            ltbItemsPesquisados.Items.Add(DR.GetString(1));

            Conexao.fecharConexao();
        }

        public void pesquisaNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbPaciente where nome like '%"+nome+"%';";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            ltbItemsPesquisados.Items.Clear();

            DR = comm.ExecuteReader();
            
            while (DR.Read())
            {
                ltbItemsPesquisados.Items.Add(DR.GetString(1));
            }

            Conexao.fecharConexao();
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
            //int indice = ltbItemsPesquisados.SelectedIndex;
            string valor = ltbItemsPesquisados.SelectedItem.ToString();

            //MessageBox.Show($"O índice selecionado foi: {indice} \n Valor selecionado foi: {valor}");

            
            frmPacientes abrir = new frmPacientes(valor);
            abrir.Show();
            this.Hide();

        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }
    }
}
