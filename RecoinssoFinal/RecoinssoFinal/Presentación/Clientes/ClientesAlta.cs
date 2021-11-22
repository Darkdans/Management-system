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
    public partial class ClientesAlta : Form
    {
        string mensajeBox = "Los campos no pueden estar vacios.";
        Logica.Core core = new Core();
        ClientesDA objClientesDA = new ClientesDA();
        private byte[] imagenByte;

        public ClientesAlta()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Telefono = txtTelefono.Text;
            string Correo = txtCorreo.Text;
            string Domicilio = txtDomicilio.Text;
            string Equipo =  txtEquipo.Text;
            if (String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Telefono) || String.IsNullOrEmpty(Correo) || String.IsNullOrEmpty(Domicilio) || String.IsNullOrEmpty(Equipo))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                objClientesDA.Agregar(RecuperarInformación());
                LimpiarEntradas();
            }
        }

        private ClientesLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            ClientesLB clientesLB = new ClientesLB();
            clientesLB.nombre = txtNombre.Text;
            clientesLB.telefono = txtTelefono.Text;
            clientesLB.correo = txtCorreo.Text;
            clientesLB.equipo = txtEquipo.Text;
            clientesLB.direccion = txtDomicilio.Text;
            clientesLB.Foto = imagenByte;
            return clientesLB;
        }

        public void LimpiarEntradas()
        {
            txtTelefono.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtEquipo.Text = "";
            txtDomicilio.Text = ""; 
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
