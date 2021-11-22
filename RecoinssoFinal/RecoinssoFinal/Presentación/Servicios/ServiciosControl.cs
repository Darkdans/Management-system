using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;
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

namespace RecoinssoFinal.Presentación.Servicios
{
    public partial class ServiciosControl : Form
    {
        ServiciosLB serviciosLB = new ServiciosLB();
        ServiciosDA objServiciosDA = new ServiciosDA();
        private byte[] imagenByte;

        public ServiciosControl()
        {
            InitializeComponent();
            RefrescarGrid();
        }

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvServicios.DataSource = objServiciosDA.MostrarServicios().Tables[0];
            dgvServicios.Columns[0].Visible = false; //ID/
            dgvServicios.Columns[4].Visible = false; //FECHA/
            dgvServicios.Columns[5].Visible = false; //FOTO/
            //Se renombran los encabezados//
            dgvServicios.Columns[1].HeaderText = "Nombre";
            dgvServicios.Columns[2].HeaderText = "Costo";
            dgvServicios.Columns[3].HeaderText = "Descripción";
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvServicios.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                PictureFoto.Image = null;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                lblID.Text = dgvServicios.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvServicios.Rows[indice].Cells[1].Value.ToString();
                txtCosto.Text = dgvServicios.Rows[indice].Cells[2].Value.ToString();
                txtDescripcion.Text = dgvServicios.Rows[indice].Cells[3].Value.ToString();
                DataGridViewImageCell Ima = dgvServicios.Rows[indice].Cells[5] as DataGridViewImageCell;
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
            }
        }
        public void LimpiarEntradas()
        {
            //Se limpian los campos del formulario//
            txtNombre.Text = "";
            txtCosto.Text = "";
            txtDescripcion.Text = "";
            PictureFoto.Image = null;

            //Activar/desactivar botones según lo que se requiera //
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RefrescarGrid();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    objServiciosDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
                    RefrescarGrid();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres modificar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    objServiciosDA.Modificar(RecuperarInformación());
                    LimpiarEntradas();
                    RefrescarGrid();
                    break;
                case DialogResult.No:
                    return;
            }
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

        private ServiciosLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int ID = 0; int.TryParse(lblID.Text, out ID);
            serviciosLB.ID = ID;
            serviciosLB.nombre = txtNombre.Text;
            serviciosLB.costo = txtCosto.Text;
            serviciosLB.descripcion = txtDescripcion.Text;
            serviciosLB.Foto = imagenByte;
            return serviciosLB;
        }
    }
}
