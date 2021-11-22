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
    public partial class TecnicosAlta : Form
    {
        string mensajeBox = "Los campos no pueden estar vacios.";
        Core core = new Core();
        TecnicoDA objTecnicoDA = new TecnicoDA();
        private byte[] imagenByte;
        public TecnicosAlta()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Telefono = txtTelefono.Text;
            string Correo = txtCorreo.Text;
            string RFC = txtRFC.Text;
            string Especialidad = txtEspecialidad.Text;
            string Puesto = txtPuesto.Text;
            if (String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Telefono) || String.IsNullOrEmpty(Correo) || String.IsNullOrEmpty(RFC) || String.IsNullOrEmpty(Puesto) || String.IsNullOrEmpty(Especialidad))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                objTecnicoDA.Agregar(RecuperarInformación());
                LimpiarEntradas();
            }

        }

        private TecnicosLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            TecnicosLB tecnicosLB = new TecnicosLB();
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
            txtTelefono.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtRFC.Text = "";
            txtEspecialidad.Text = "";
            txtPuesto.Text = "";
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
