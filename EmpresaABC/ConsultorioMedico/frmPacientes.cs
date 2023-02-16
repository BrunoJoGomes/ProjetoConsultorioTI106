using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//importando p janela do projeto a biblioteca dos correios
using Correios.Net;

namespace ConsultorioMedico
{
    public partial class frmPacientes : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public void desabilitarCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            mkdCpf.Enabled = false;
            mkdTelefone.Enabled = false;
            cbbEstado.Enabled = false;
            mkdCep.Enabled = false;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;

        }

        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            mkdCpf.Enabled = true;
            mkdTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            mkdCep.Enabled = true;
            btnLimpar.Enabled = true;
            btnCadastrar.Enabled = true;
            txtNome.Focus();
        }

        public void limparCampos()
        {
            txtNome.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            mkdCpf.Clear();
            mkdTelefone.Clear();
            cbbEstado.Text = "";
            mkdCep.Clear();
        }

        //metodo para carregar combobox
        public void carregarComboBox()
        {
            cbbEstado.Items.Add("");
            cbbEstado.Items.Add("SP");
            cbbEstado.Items.Add("RJ");
            cbbEstado.Items.Add("BH");
            cbbEstado.Items.Add("BA");
            cbbEstado.Items.Add("RN");
        }

        //Construtor da classe
        public frmPacientes()
        {
            InitializeComponent();
            desabilitarCampos();
            carregarComboBox();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal menu = new frmMenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisar pesquisar = new frmPesquisar();
            pesquisar.ShowDialog();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //executando o metodo verificarCampo
            verificarCampo();
        }

        //criando metodo para verificar campos vazios
        public void verificarCampo()
        {
            /* if (txtNome.Text == "")
            {
                MessageBox.Show("Favor inserir valores");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Favor inserir valores");
            } */

            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("") 
               || mkdCpf.Text.Equals("   .   .   -") || mkdTelefone.Text.Equals("(  )     -")
               || mkdCep.Text.Equals("     -") || txtEndereco.Text.Equals("") 
               || txtCidade.Text.Equals("") || txtBairro.Text.Equals("") 
               || cbbEstado.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                txtNome.Focus();
            }
            else
            {
                MessageBox.Show("Cadastrado com sucesso!",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                desabilitarCampos();
                limparCampos();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            txtNome.Focus();
        }

        //Instanciando a classe correios.net
        //Address endereco = new Address();
        private void btnCarregaEndereco_Click(object sender, EventArgs e)
        {
            Address add;
            add = SearchZip.GetAddress(mkdCep.Text, 1000);

            txtEndereco.Text = add.Street;
            txtBairro.Text = add.District;
            txtCidade.Text = add.City;
            cbbEstado.Text = add.State;
        }

    }
}
