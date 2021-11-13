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

namespace RecoinssoFinal.Presentación.Clientes
{
    public partial class ClientesAlta : Form
    {
        string mensajeBox = "Los campos no pueden estar vacios.";
        Logica.Core core = new Core();
        ClientesDA objClientesDa = new ClientesDA();
        public ClientesAlta()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            ClientesControl clientesControl = new ClientesControl();
            this.Hide();
            clientesControl.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Telefono = txtTelefono.Text;
            string Correo = txtCorreo.Text;
            string RFC = txtRFC.Text;
            if (String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Telefono) || String.IsNullOrEmpty(Correo) || String.IsNullOrEmpty(RFC))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                objClientesDa.Agregar(RecuperarInformación());
                LimpiarEntradas();
                DialogResult dialogResult = MessageBox.Show("Será enviado a Control de clientes.", "Mensaje del sistema", MessageBoxButtons.OK);
                ClientesControl clientesControl = new ClientesControl();
                this.Hide();
                clientesControl.Show();
            }
        }

        private clientesLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            clientesLB clientesLB = new clientesLB();
            int phone = 0; int.TryParse(txtTelefono.Text, out phone);
            clientesLB.nombre = txtNombre.Text;
            clientesLB.telefono = phone;
            clientesLB.correo = txtCorreo.Text;
            clientesLB.rfc = txtRFC.Text;
            return clientesLB;
        }

        public void LimpiarEntradas()
        {
            txtTelefono.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtRFC.Text = "";
        }
    }
}
