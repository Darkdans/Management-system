using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        ClientesDA objClientesDA = new ClientesDA();
        private byte[] imagenByte;

        public ClientesControl()
        {
            InitializeComponent();
            RefrescarGrid();
        }

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvClientes.DataSource = objClientesDA.MostrarClientes().Tables[0];
            dgvClientes.Columns[0].Visible = false; //ID
            dgvClientes.Columns[5].Visible = false; //FOTO
            //Se renombran los encabezados//
            dgvClientes.Columns[1].HeaderText = "Nombre";
            dgvClientes.Columns[2].HeaderText = "Teléfono";
            dgvClientes.Columns[3].HeaderText = "Correo";
            dgvClientes.Columns[4].HeaderText = "Equipo";
            dgvClientes.Columns[6].HeaderText = "Dirección";
            dgvClientes.Columns[7].HeaderText = "Descripción del equipo";
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvClientes.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                labelID.Text = dgvClientes.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvClientes.Rows[indice].Cells[1].Value.ToString();
                txtTelefono.Text = dgvClientes.Rows[indice].Cells[2].Value.ToString();
                txtCorreo.Text = dgvClientes.Rows[indice].Cells[3].Value.ToString();
                txtEquipo.Text = dgvClientes.Rows[indice].Cells[4].Value.ToString();
                PictureFoto.Image = null;
                DataGridViewImageCell Ima = dgvClientes.Rows[indice].Cells[5] as DataGridViewImageCell;
                try
                {
                    Byte[] ImaByt = (Byte[])Ima.Value;
                    MemoryStream Mry = new MemoryStream(ImaByt);
                    PictureFoto.Image = Image.FromStream(Mry);
                    PictureFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Cannot convert a Null to a Byte.");
                }
                txtDomicilio.Text = dgvClientes.Rows[indice].Cells[6].Value.ToString();
                txtDescripcionEquipo.Text = dgvClientes.Rows[indice].Cells[7].Value.ToString();
            }
        }
        private ClientesLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            ClientesLB clientesLB = new ClientesLB();
            int ID = 0; int.TryParse(labelID.Text, out ID);
            clientesLB.ID = ID;
            clientesLB.nombre = txtNombre.Text;
            clientesLB.telefono = txtTelefono.Text; ;
            clientesLB.correo = txtCorreo.Text;
            clientesLB.equipo = txtEquipo.Text;
            clientesLB.direccion = txtDomicilio.Text;
            clientesLB.Foto = imagenByte;
            clientesLB.detalleEquipo = txtDescripcionEquipo.Text;
            return clientesLB;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres modificar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    objClientesDA.Modificar(RecuperarInformación());
                    LimpiarEntradas();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    objClientesDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        public void LimpiarEntradas()
        {
            txtTelefono.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtEquipo.Text = "";
            txtDomicilio.Text = "";
            PictureFoto.Image = null;
            txtDescripcionEquipo.Text = "";
            //Activar/desactivar botones según lo que se requiera //
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RefrescarGrid();
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Title = "Seleccionar imagen";

            if (selectorImagen.ShowDialog() == DialogResult.OK)
            {
                PictureFoto.Image = Image.FromStream(selectorImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();
                PictureFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
                imagenByte = memoria.ToArray();
            }
        }
    }
}
