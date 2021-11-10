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
        conexionDA conexion = new conexionDA();
        Core core = new Core();
        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e) {
            string Usuario = txtUser.Text;
            string Password = txtPassword.Text;
            if (String.IsNullOrEmpty(Usuario) || String.IsNullOrEmpty(Password) ) {
                core.messageBox("Los campos no pueden estar vacios, intentalo de nuevo.");
            } else {
                conexion.logins(recuperarInformación());
            }
        }

        //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
        private loginLB recuperarInformación()
        {
            loginLB objloginLB = new loginLB();
            objloginLB.usuario = txtUser.Text;
            objloginLB.password = txtPassword.Text;
            return objloginLB;
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            NewUser newUserForm = new NewUser();
            this.Hide();
            newUserForm.Show();
            
        }
    }
}
