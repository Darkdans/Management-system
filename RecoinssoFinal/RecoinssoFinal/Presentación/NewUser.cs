﻿using System;
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

namespace RecoinssoFinal.Presentación
{
    public partial class NewUser : Form
    {
        newUserDA objnewUserDA;
        Core core;
        public NewUser()
        {
            InitializeComponent();
            objnewUserDA = new newUserDA();
            core = new Core();
        }

        private newUserLB RecuperarInformación() {
            newUserLB objNewUserLB = new newUserLB();
            objNewUserLB.usuario = txtUsuario.Text;
            objNewUserLB.nombre = txtNombre.Text;
            objNewUserLB.apellidoPaterno = txtApellidoPaterno.Text;
            objNewUserLB.apellidoMaterno = txtApellidoMaterno.Text;
            objNewUserLB.password = txtContrasena.Text;
            objNewUserLB.telefono = txtTelefono.Text;
            objNewUserLB.correo = txtCorreo.Text;
            return objNewUserLB;
    }
        private void linklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string Usuario = txtUsuario.Text;
            string Nombre = txtNombre.Text;
            string ApellidoPaterno = txtApellidoPaterno.Text;
            string ApellidoMaterno = txtApellidoMaterno.Text;
            string Contraseña = txtContrasena.Text;
            string RepetirContraseña = txtRepetirContrasena.Text;
            string Telefono = txtTelefono.Text;
            string Correo = txtCorreo.Text;
            if (String.IsNullOrEmpty(Usuario) || String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(ApellidoPaterno) ||
                String.IsNullOrEmpty(ApellidoMaterno) || String.IsNullOrEmpty(Contraseña) || String.IsNullOrEmpty(Telefono) || String.IsNullOrEmpty(Correo))
            {
                core.messageBox("Los campos no pueden estar vacios.");
            }
            else
            {
                bool result = Contraseña.Equals(RepetirContraseña);
                if (result) {
                    objnewUserDA.Agregar(RecuperarInformación());
                    LimpiarEntradas();
                    core.messageBox("Sera enviado a la ventana de inicio de sesión.");
                    LoginForm loginForm = new LoginForm();
                    this.Hide();
                    loginForm.Show();
                } else
                {
                    core.messageBox("Las contraseñas no coinciden, intentalo de nuevo.");
                }
                
            }
        }

        public void LimpiarEntradas() {
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtContrasena.Text = "";
            txtRepetirContrasena.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }
    }
}
