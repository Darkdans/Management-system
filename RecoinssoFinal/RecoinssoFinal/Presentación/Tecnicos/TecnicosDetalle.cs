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
    public partial class TecnicosDetalle : Form
    {
        tecnicosLB tecnicosLB = new tecnicosLB();
        TecnicoDA tecnicoDA = new TecnicoDA();
        public TecnicosDetalle()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            TecnicosControl tecnicosControl = new TecnicosControl();
            this.Hide();
            tecnicosControl.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tecnicoDA.Modificar(RecuperarInformación());
            DialogResult result = MessageBox.Show("Será enviado a Control de técnicos.", "Mensaje del sistema", MessageBoxButtons.OK);
            switch (result)
            {
                case DialogResult.OK:
                    TecnicosControl tecnicoControl = new TecnicosControl();
                    this.Hide();
                    tecnicoControl.Show();
                    return;
            }
        }
        private tecnicosLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int ID = 0; int.TryParse(lblID.Text, out ID);
            tecnicosLB.ID = ID;
            tecnicosLB.nombre = txtNombre.Text;
            int Telefono = 0; int.TryParse(txtTelefono.Text, out Telefono);
            tecnicosLB.telefono = Telefono;
            tecnicosLB.correo = txtCorreo.Text;
            tecnicosLB.rfc = txtRFC.Text;
            tecnicosLB.especialidad = txtEspecialidad.Text;
            tecnicosLB.puesto = txtPuesto.Text;
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
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    tecnicoDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
                    DialogResult dialogResult = MessageBox.Show("Será enviado a Control de técnicos.", "Mensaje del sistema", MessageBoxButtons.OK);
                    TecnicosControl tecnicosControl = new TecnicosControl();
                    this.Hide();
                    tecnicosControl.Show();
                    break;
                case DialogResult.No:
                    return;
            }
        }
    }
}
