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
    public partial class ServiciosAlta : Form
    {
        string mensajeBox = "Los campos no pueden estar vacios.";
        Core core = new Core();
        ServiciosDA objServiciosDA = new ServiciosDA();
        private byte[] imagenByte;

        public ServiciosAlta()
        {
            InitializeComponent();
        }
   
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Dias = txtDias.Text;
            string Precio = txtCosto.Text;
            string Descripcion = txtDescripcion.Text;
            if (String.IsNullOrEmpty(Dias) || String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Precio) || String.IsNullOrEmpty(Descripcion))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                if (PictureFoto.Image == null)
                {
                    core.messageBox("Favor de ingresar una imagen.");
                } else
                {
                    objServiciosDA.Agregar(RecuperarInformación());
                    LimpiarEntradas();
                }
               
            }
        }

        private ServiciosLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            ServiciosLB serviciosLB = new ServiciosLB();
            serviciosLB.nombre = txtNombre.Text;
            serviciosLB.costo = txtCosto.Text;
            serviciosLB.descripcion = txtDescripcion.Text;
            int dias = 0; int.TryParse(txtDias.Text, out dias);
            serviciosLB.dias = dias;
            serviciosLB.Foto = imagenByte;
            return serviciosLB;
        }

        public void LimpiarEntradas()
        {
            txtNombre.Text = "";
            txtCosto.Text = "";
            txtDescripcion.Text = "";
            txtDias.Text = "";
            PictureFoto.Image = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
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