using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;
using RecoinssoFinal.Presentación;

namespace RecoinssoFinal
{
    public partial class LoginForm : Form
    {
        LoginLB objloginLB = new LoginLB();
        ConexionDA conexion = new ConexionDA();
        MainMenu mainMenu = new MainMenu();
        Core core = new Core();
        public LoginForm()
        {
            InitializeComponent();
        }

        //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
        private LoginLB recuperarInformación()
        {
            objloginLB.usuario = txtUser.Text;
            objloginLB.password = txtPassword.Text;
            return objloginLB;
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            Presentación.Registrarse newUserForm = new Presentación.Registrarse();
            this.Hide();
            newUserForm.Show();
        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            string Usuario = txtUser.Text;
            string Password = txtPassword.Text;
            if (String.IsNullOrEmpty(Usuario) || String.IsNullOrEmpty(Password))
            {
                core.messageBox("Los campos no pueden estar vacios, intentalo de nuevo.");
            }
            else
            {
                conexion.logins(recuperarInformación());
            }
        }
    }
}
