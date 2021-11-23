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

namespace RecoinssoFinal.Presentación.Alarmas
{
    public partial class InfoAlarmas : Form
    {
        ReportesDA reportesDA = new ReportesDA();
        public InfoAlarmas()
        {
            InitializeComponent();
            RefrescarGrid();
        }

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvAlarmas.DataSource = reportesDA.MostrarAlarmas().Tables[0];
            dgvAlarmas.Columns[0].Visible = false; //ID-Reporte-Problema/
            dgvAlarmas.Columns[1].Visible = false; //ID-Cliente/
            dgvAlarmas.Columns[2].HeaderText = "Folio";
            dgvAlarmas.Columns[3].HeaderText = "Cliente";
            dgvAlarmas.Columns[4].HeaderText = "Equipo";
            dgvAlarmas.Columns[5].HeaderText = "Detalle del equipo";
            dgvAlarmas.Columns[6].HeaderText = "Detalle del problema";
            dgvAlarmas.Columns[7].Visible = false; //Solución/             
            dgvAlarmas.Columns[8].Visible = false; //EstadoPago/
            dgvAlarmas.Columns[9].Visible = false; //EstadoTickets/
            dgvAlarmas.Columns[10].Visible = false; //ServiciosID/
            dgvAlarmas.Columns[11].Visible = false;
        }

            private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
