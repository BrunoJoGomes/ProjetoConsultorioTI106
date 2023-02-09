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

namespace ConsultorioMedico
{
    public partial class frmMenuPrincipal : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmLogin voltar = new frmLogin();
            voltar.Show();
            this.Hide();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            frmConsulta consulta = new frmConsulta();
            consulta.Show();
            this.Hide();
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            frmMedicos medicos = new frmMedicos();
            medicos.Show();
            this.Hide();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            frmPacientes pacientes = new frmPacientes();
            pacientes.Show();
            this.Hide();
        }

        private void btnExames_Click(object sender, EventArgs e)
        {
            frmExames exames = new frmExames();
            exames.Show();
            this.Hide();
        }

        private void btnConvenios_Click(object sender, EventArgs e)
        {
            frmConsulta consulta = new frmConsulta();
            consulta.Show();
            this.Hide();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            frmAgenda agenda = new frmAgenda();
            agenda.Show();
            this.Hide();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }
    }
}
