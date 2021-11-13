using RecoinssoFinal.DataAccess;
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
    public partial class TecnicosControl : Form
    {
        TecnicoDA objTecnicosDA;
        TecnicosDetalle objTecnicosDetalle = new TecnicosDetalle();
        public TecnicosControl()
        {
            InitializeComponent();
            objTecnicosDA = new TecnicoDA();
            RefrescarGrid();
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
            dgvTecnicos.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnDetalle.Enabled = true;
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            int indice = dgvTecnicos.CurrentRow.Index;
            if (indice >= 0)
            {
                objTecnicosDetalle.lblID.Text = dgvTecnicos.Rows[indice].Cells[0].Value.ToString();
                objTecnicosDetalle.txtNombre.Text = dgvTecnicos.Rows[indice].Cells[1].Value.ToString();
                objTecnicosDetalle.txtTelefono.Text = dgvTecnicos.Rows[indice].Cells[2].Value.ToString();
                objTecnicosDetalle.txtCorreo.Text = dgvTecnicos.Rows[indice].Cells[3].Value.ToString();
                objTecnicosDetalle.txtRFC.Text = dgvTecnicos.Rows[indice].Cells[4].Value.ToString();
                objTecnicosDetalle.txtEspecialidad.Text = dgvTecnicos.Rows[indice].Cells[5].Value.ToString();
                objTecnicosDetalle.txtPuesto.Text = dgvTecnicos.Rows[indice].Cells[6].Value.ToString();
            }
            this.Hide();
            objTecnicosDetalle.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TecnicosAlta objTecnicosAlta = new TecnicosAlta();
            this.Hide();
            objTecnicosAlta.Show();
        }
        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvTecnicos.DataSource = objTecnicosDA.MostrarTecnicos().Tables[0];
            dgvTecnicos.Columns[0].Visible = false;
            //Se renombran los encabezados//
            dgvTecnicos.Columns[1].HeaderText = "Nombre";
            dgvTecnicos.Columns[2].HeaderText = "Teléfono";
            dgvTecnicos.Columns[3].HeaderText = "Correo";
            dgvTecnicos.Columns[4].HeaderText = "RFC";
            dgvTecnicos.Columns[5].HeaderText = "Especialidad";
            dgvTecnicos.Columns[6].HeaderText = "Puesto";
        }
    }
}
