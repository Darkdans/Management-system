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
    public partial class ClientesControl : Form
    {
        ClientesDA objClientesDA;
        ClientesDetalle clientesDetalle = new ClientesDetalle();

        public ClientesControl()
        {
            InitializeComponent();
            objClientesDA = new ClientesDA();
            RefrescarGrid();
        }

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvClientes.DataSource = objClientesDA.MostrarClientes().Tables[0];
            dgvClientes.Columns[0].Visible = false;
            //Se renombran los encabezados//
            dgvClientes.Columns[1].HeaderText = "Nombre";
            dgvClientes.Columns[2].HeaderText = "Teléfono";
            dgvClientes.Columns[3].HeaderText = "Correo";
            dgvClientes.Columns[4].HeaderText = "RFC";
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            int indice = dgvClientes.CurrentRow.Index;
            if (indice >= 0) {
                clientesDetalle.lblID.Text = dgvClientes.Rows[indice].Cells[0].Value.ToString();
                clientesDetalle.txtNombre.Text = dgvClientes.Rows[indice].Cells[1].Value.ToString();
                clientesDetalle.txtTelefono.Text = dgvClientes.Rows[indice].Cells[2].Value.ToString();
                clientesDetalle.txtCorreo.Text = dgvClientes.Rows[indice].Cells[3].Value.ToString();
                clientesDetalle.txtRFC.Text = dgvClientes.Rows[indice].Cells[4].Value.ToString();
            }
            this.Hide();
            clientesDetalle.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ClientesAlta clientesAlta = new ClientesAlta();
            this.Hide();
            clientesAlta.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            mainMenu mainMenu = new mainMenu();
            this.Hide();
            mainMenu.Show();
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvClientes.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnDetalle.Enabled = true;
            }
        }


    }
}
