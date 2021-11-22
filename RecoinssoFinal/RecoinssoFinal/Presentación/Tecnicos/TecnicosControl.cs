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

namespace RecoinssoFinal.Presentación.Tecnicos
{
    public partial class TecnicosControl : Form
    {
        TecnicoDA objTecnicosDA = new TecnicoDA();
      
        private byte[] imagenByte;

        public TecnicosControl()
        {
            InitializeComponent();
            RefrescarGrid();
        }

           public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvTecnicos.DataSource = objTecnicosDA.MostrarTecnicos().Tables[0];
            dgvTecnicos.Columns[0].Visible = false; //ID//
            dgvTecnicos.Columns[7].Visible = false; //FOTO
            //Se renombran los encabezados//
            dgvTecnicos.Columns[1].HeaderText = "Nombre";
            dgvTecnicos.Columns[2].HeaderText = "Teléfono";
            dgvTecnicos.Columns[3].HeaderText = "Correo";
            dgvTecnicos.Columns[4].HeaderText = "RFC";
            dgvTecnicos.Columns[5].HeaderText = "Especialidad";
            dgvTecnicos.Columns[6].HeaderText = "Puesto";
        }
        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvTecnicos.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                lblID.Text = dgvTecnicos.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvTecnicos.Rows[indice].Cells[1].Value.ToString();
                txtTelefono.Text = dgvTecnicos.Rows[indice].Cells[2].Value.ToString();
                txtCorreo.Text = dgvTecnicos.Rows[indice].Cells[3].Value.ToString();
                txtRFC.Text = dgvTecnicos.Rows[indice].Cells[4].Value.ToString();
                txtEspecialidad.Text = dgvTecnicos.Rows[indice].Cells[5].Value.ToString();
                txtPuesto.Text = dgvTecnicos.Rows[indice].Cells[6].Value.ToString();
                PictureFoto.Image = null;
                DataGridViewImageCell Ima = dgvTecnicos.Rows[indice].Cells[7] as DataGridViewImageCell;
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

     

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    objTecnicosDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
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
                    objTecnicosDA.Modificar(RecuperarInformación());
                    LimpiarEntradas();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private TecnicosLB RecuperarInformación()
        {
            TecnicosLB tecnicosLB = new TecnicosLB();
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int ID = 0; int.TryParse(lblID.Text, out ID);
            tecnicosLB.ID = ID;
            tecnicosLB.nombre = txtNombre.Text;
            tecnicosLB.telefono = txtTelefono.Text;
            tecnicosLB.correo = txtCorreo.Text;
            tecnicosLB.rfc = txtRFC.Text;
            tecnicosLB.especialidad = txtEspecialidad.Text;
            tecnicosLB.puesto = txtPuesto.Text;
            tecnicosLB.Foto = imagenByte;
            return tecnicosLB;
        }

        public void LimpiarEntradas()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtRFC.Text = "";
            txtEspecialidad.Text = "";
            txtPuesto.Text = "";
            PictureFoto.Image = null;
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
