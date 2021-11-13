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
    public partial class ClientesDetalle : Form
    {
        clientesLB clientesLB = new clientesLB();
        ClientesDA clientesDA = new ClientesDA();

        public ClientesDetalle()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            ClientesControl clientesControl = new ClientesControl();
            this.Hide();
            clientesControl.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            clientesDA.Modificar(RecuperarInformación());
            DialogResult result = MessageBox.Show("Será enviado a Control de clientes.", "Mensaje del sistema", MessageBoxButtons.OK);
            switch (result) {
                case DialogResult.OK:
                    ClientesControl clientesControl = new ClientesControl();
                    this.Hide();
                    clientesControl.Show();
                    return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    clientesDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
                    DialogResult dialogResult = MessageBox.Show("Será enviado a Control de clientes.", "Mensaje del sistema", MessageBoxButtons.OK);
                    ClientesControl clientesControl = new ClientesControl();
                    this.Hide();
                    clientesControl.Show();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private clientesLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int ID = 0; int.TryParse(lblID.Text, out ID);
            clientesLB.ID = ID;
            clientesLB.nombre = txtNombre.Text;
            int Telefono = 0; int.TryParse(txtTelefono.Text, out Telefono);
            clientesLB.telefono = Telefono;
            clientesLB.correo = txtCorreo.Text;
            clientesLB.rfc = txtRFC.Text;
            return clientesLB;
        }

        public void LimpiarEntradas() {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtRFC.Text = "";
        }
    }
}
