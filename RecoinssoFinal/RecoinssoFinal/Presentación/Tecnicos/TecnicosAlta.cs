using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                DialogResult dialogResult = MessageBox.Show("Será enviado a Control de técnicos.", "Mensaje del sistema", MessageBoxButtons.OK);
                TecnicosControl objTecnicosControl = new TecnicosControl();
                this.Hide();
                objTecnicosControl.Show();
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            TecnicosControl tecnicosControl = new TecnicosControl();
            this.Hide();
            tecnicosControl.Show();
        }

        private tecnicosLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            tecnicosLB tecnicosLB = new tecnicosLB();
            int phone = 0; int.TryParse(txtTelefono.Text, out phone);
            tecnicosLB.nombre = txtNombre.Text;
            tecnicosLB.telefono = phone;
            tecnicosLB.correo = txtCorreo.Text;
            tecnicosLB.rfc = txtRFC.Text;
            tecnicosLB.especialidad = txtEspecialidad.Text;
            tecnicosLB.puesto = txtPuesto.Text;
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
        }
    }
}
