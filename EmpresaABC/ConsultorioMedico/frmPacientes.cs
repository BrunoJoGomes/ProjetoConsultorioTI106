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
using System.Globalization;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

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
            txtNum.Enabled = false;
            txtComplemento.Enabled = false;

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
            txtComplemento.Enabled = true;
            txtNum.Enabled = true;
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
            txtComplemento.Clear();
            txtNum.Clear();
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

       //string nome = "";
        //bool flag = false;


        //criando construtor com parametros
        public frmPacientes(string nome)
        {
            InitializeComponent();
            desabilitarCampos();
            carregarComboBox();
            //txtNome.Text = nome;
            pesquisarCampo(nome);
            habilitarCampos();
            //flag = true;
            ativarUpdate();
            
        }

        public void ativarUpdate()
        {
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        public void pesquisarCampo(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbpaciente where nome = '"+nome+"';";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtNome.Text = nome;
            txtCodigo.Text = Convert.ToString(DR.GetInt32(0));
            txtEmail.Text = DR.GetString(2);
            mkdTelefone.Text = DR.GetString(3);
            mkdCpf.Text = DR.GetString(4);
            txtEndereco.Text = DR.GetString(5);
            txtNum.Text = DR.GetString(6);
            mkdCep.Text = DR.GetString(7);
            txtComplemento.Text = DR.GetString(8);
            txtBairro.Text = DR.GetString(9);
            txtCidade.Text = DR.GetString(10);
            cbbEstado.Text = DR.GetString(11);

            Conexao.fecharConexao();
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
            btnNovo.Enabled = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisar pesquisar = new frmPesquisar();
            pesquisar.ShowDialog();
            this.Hide();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //executando o metodo verificarCampo
            verificarCampo();
            //Executar o metodo de cadastrar pacientes
            cadastrarPaciente();

        }

        public void cadastrarPaciente()
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbPaciente(nome,email,telefone,cpf,endereco,numero,cep,complemento,bairro,cidade,siglaEstado) " +
                "values(@nome,@email,@telefone,@cpf,@endereco,@numero,@cep,@complemento,@bairro,@cidade,@siglaEstado);";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.Add("@nome",MySqlDbType.VarChar,100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar,100).Value = txtEmail.Text;
            comm.Parameters.Add("@telefone", MySqlDbType.VarChar,14).Value = mkdTelefone.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar,14).Value = mkdCpf.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar,100).Value = txtEndereco.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar,10).Value = txtNum.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar,8).Value = mkdCep.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar,50).Value = txtComplemento.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar,50).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar,50).Value = txtCidade.Text;
            comm.Parameters.Add("@siglaEstado", MySqlDbType.VarChar,2).Value = cbbEstado.Text;

            comm.Connection = Conexao.obterConexao();

            int i = comm.ExecuteNonQuery();

            MessageBox.Show("Paciente cadastrado com sucesso!" + i);

            Conexao.fecharConexao();
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
                   //MessageBox.Show("Cadastrado com sucesso!",
                    //"Mensagem do sistema",
                    //MessageBoxButtons.OK,
                    //MessageBoxIcon.Information,
                    //MessageBoxDefaultButton.Button1);
                    //desabilitarCampos();
                    //limparCampos();
                
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            txtNome.Focus();
        }

        public void buscaCEP(string cep)
        {
            WSCorreios.AtendeClienteClient ws = new WSCorreios.AtendeClienteClient();

            try
            {
                WSCorreios.enderecoERP end = ws.consultaCEP(cep);

                txtEndereco.Text = end.end;
                txtBairro.Text = end.bairro;
                txtCidade.Text = end.cidade;
                cbbEstado.Text = end.uf;
            }
            catch(Exception)
            {
                MessageBox.Show("Insira CEP válido",
                    "Mensagem do Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                mkdCep.Clear();
                mkdCep.Focus();
            }
        }

        public static bool validaEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s+\.[^@\s]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool validaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".","");
            
            valor = valor.Replace("-","");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                    valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 00)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }

        private void mkdCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                buscaCEP(mkdCep.Text);
            }
        }

        private void mkdCpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool valida = validaCPF(mkdCpf.Text);

                if(valida == true)
                {
                    mkdCep.Focus();
                }
                else
                {
                    MessageBox.Show("Insira CPF válido",
                        "Mensagem do Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    mkdCpf.Clear();
                    mkdCpf.Focus();
                }
            }
        }

        public void alterarPaciente(int codPac)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbPaciente set nome = @nome,email = @email,telefone = @telefone,cpf = @cpf," +
                "endereco = @endereco,numero = @numero,cep = @cep,complemento= @complemento,bairro = @bairro,cidade = @cidade," +
                "siglaEstado = @siglaEstado where codpac ="+codPac+";";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@telefone", MySqlDbType.VarChar, 14).Value = mkdTelefone.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mkdCpf.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNum.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 8).Value = mkdCep.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 50).Value = txtComplemento.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
            comm.Parameters.Add("@siglaEstado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;

            int res = comm.ExecuteNonQuery();
            MessageBox.Show("Registro alterado com sucesso."+res);
            Conexao.fecharConexao();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alterarPaciente(Convert.ToInt32(txtCodigo.Text));
        }

        public void excluirPaciente(int codPac)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbPaciente where codPac = "+codPac+";";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();
            comm.Parameters.Add("@codPac", MySqlDbType.VarChar, 100).Value = codPac;


            DialogResult vresp = MessageBox.Show("Deseja realizar a exclusão?", "Mensagem do Sistema", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if(vresp == DialogResult.Yes)
            {
                int res = comm.ExecuteNonQuery();
                MessageBox.Show("Registro excluído com sucesso" + res);
            }
            else
            {

            }

            Conexao.fecharConexao();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codPac = Convert.ToInt32(txtCodigo.Text);
            excluirPaciente(codPac);
            limparCampos();
            txtCodigo.Text = "";
            desabilitarCampos();
         
        }
    }
}
