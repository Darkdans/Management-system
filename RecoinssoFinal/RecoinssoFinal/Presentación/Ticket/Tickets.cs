using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoinssoFinal.Presentación.Ticket
{
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
            RefrescarGrid();
            CargarComboboxReporte();
        }

        string connectionData = ConfigurationManager.ConnectionStrings["connectionProperties"].ConnectionString;
        SqlConnection Conexion;
        Core core = new Core();

        public SqlConnection EstablecerConexión()
        {
            this.Conexion = new SqlConnection(this.connectionData);
            return this.Conexion;
        }

        string mensajeBox = "Los campos con * son importantes y no pueden estar vacios.";
        TicketsDA ticketsDA = new TicketsDA();
        ReportesLB reportesLB = new ReportesLB();

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvTickets.DataSource = ticketsDA.MostrarReportesEstadoPago().Tables[0];
            dgvTickets.Columns[0].Visible = false; //ID-Reporte-ID/
            dgvTickets.Columns[1].Visible = false; //ID-Cliente/
        
            //Se renombran los encabezados//
            dgvTickets.Columns[2].HeaderText = "Folio";
            dgvTickets.Columns[3].HeaderText = "Cliente";
            dgvTickets.Columns[4].HeaderText = "Equipo";
            dgvTickets.Columns[5].HeaderText = "Detalle del equipo";
            dgvTickets.Columns[6].HeaderText = "Detalle del problema";
            dgvTickets.Columns[7].HeaderText = "Solución propuesta";
            dgvTickets.Columns[8].Visible = false; //ID-EstadoPago/
            dgvTickets.Columns[9].Visible = false; //ID-EstadoTicket/
            dgvTickets.Columns[10].Visible = false; //ID-servicio/
            dgvTickets.Columns[11].Visible = false; //fecha/
            dgvTickets.Columns[12].Visible = false; //ID-Pago/
           
            dgvTickets.Columns[13].HeaderText = "Estado de pago";
            dgvTickets.Columns[14].Visible = false; //ID-EstadoTicket/
            dgvTickets.Columns[15].HeaderText = "Estado de ticket";
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvTickets.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                cbxReporte.DataSource = null;
                cbxReporte.Items.Clear();
                cbxEstadoTicket.DataSource = null;
                cbxEstadoTicket.Items.Clear();

                lblID.Text = dgvTickets.Rows[indice].Cells[0].Value.ToString();
                lblIDClientes.Text = dgvTickets.Rows[indice].Cells[1].Value.ToString();
                txtCliente.Text = dgvTickets.Rows[indice].Cells[3].Value.ToString();
                txtEquipo.Text = dgvTickets.Rows[indice].Cells[4].Value.ToString();
                txtDescripcionEquipo.Text = dgvTickets.Rows[indice].Cells[5].Value.ToString();
                txtDetalle.Text = dgvTickets.Rows[indice].Cells[6].Value.ToString(); //Detalle del problema/
                txtSolución.Text = dgvTickets.Rows[indice].Cells[7].Value.ToString();
                txtEstadoPago.Text = dgvTickets.Rows[indice].Cells[13].Value.ToString();
                RegistroSeleccionadoComboboxReportes(indice);
                RegistroSeleccionadoComboboxEstadoTicket(indice);
            }
        }

        public void RegistroSeleccionadoComboboxReportes(int indice)
        {
            int IDReporte = 0; int.TryParse(dgvTickets.Rows[indice].Cells[0].Value.ToString(), out IDReporte);
            cbxReporte.DataSource = ticketsDA.MostrarReportes().Tables[0];
            cbxReporte.DisplayMember = "folio";
            cbxReporte.ValueMember = "reportesID";
            cbxReporte.SelectedValue = IDReporte;
        }

        public void RegistroSeleccionadoComboboxEstadoTicket(int indice)
        {
            int IDEstadoTicket = 0; int.TryParse(dgvTickets.Rows[indice].Cells[14].Value.ToString(), out IDEstadoTicket);
            cbxEstadoTicket.DataSource = ticketsDA.MostrarEstadoTicket().Tables[0];
            cbxEstadoTicket.DisplayMember = "Nombre";
            cbxEstadoTicket.ValueMember = "EstadoTicketID";
            cbxEstadoTicket.SelectedValue = IDEstadoTicket;
        }

        private ReportesLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int reportesID = 0;
            int clienteID = 0;
            int EstadoTicketID = 0;
            int EstadoPagoID = 0;
            dateTimePickerInicio.Format = DateTimePickerFormat.Custom;
            dateTimePickerInicio.CustomFormat = "dd/MM/yyyy";
            DateTime theDate = this.dateTimePickerInicio.Value.Date;
            int.TryParse(lblID.Text, out reportesID);
            if (cbxReporte.SelectedValue != null)
            {
                int.TryParse(cbxReporte.SelectedValue.ToString(), out clienteID);
            }
            if (cbxEstadoTicket.SelectedValue != null)
            {
                int.TryParse(cbxEstadoTicket.SelectedValue.ToString(), out EstadoTicketID);
            }
            int.TryParse(txtEstadoPago.Text, out EstadoPagoID);
            reportesLB.estadoTicket = EstadoTicketID;
            reportesLB.ID_ReporteProblema = reportesID;
            reportesLB.ID_Cliente = clienteID;
            reportesLB.NombreCliente = cbxReporte.Text;
            reportesLB.Equipo = txtEquipo.Text;
            reportesLB.estadoPago = EstadoPagoID;
            reportesLB.DetalleEquipo = txtDescripcionEquipo.Text;
            reportesLB.DetalleProblema = txtDetalle.Text;
            reportesLB.Solucion = txtSolución.Text;
            reportesLB.fecha = theDate;
            return reportesLB;
        }

        public void LimpiarEntradas()
        {
            lblID.Text = "";
            txtEquipo.Text = "";
            txtDescripcionEquipo.Text = "";
            txtDetalle.Text = "";
            txtSolución.Text = "";
            txtEstadoPago.Text = "";
            txtCliente.Text = "";
            txtTiempoEstimado.Text = "";
            CargarComboboxReporte(); //Lo pone en el indice 0 al ser pocos registros//
            CargarComboboxEstadoTicket();
            //Activar/desactivar botones según lo que se requiera //
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RefrescarGrid();
        }
        public void CargarComboboxReporte()
        {
            cbxReporte.DataSource = ticketsDA.MostrarReportes().Tables[0];
            cbxReporte.DisplayMember = "folio";
            cbxReporte.ValueMember = "reportesID";
        }

        public void CargarComboboxEstadoTicket()
        {
            cbxEstadoTicket.DataSource = ticketsDA.MostrarEstadoTicket().Tables[0];
            cbxEstadoTicket.DisplayMember = "Nombre";
            cbxEstadoTicket.ValueMember = "EstadoTicketID";
        }

        public void LLenarFormConReporteSeleccionado()
        {
            int IDReporte = 0;
            if (cbxReporte.SelectedValue != null)
            {
                int.TryParse(cbxReporte.SelectedValue.ToString(), out IDReporte);
            }
            string Reporte = cbxReporte.Text;
            bool result = Reporte.Equals("Seleccione");
            if (!result)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(connectionData))
                    {
                        conexion.Open();
                        using (SqlCommand commando = new SqlCommand("SELECT dias, estadoTicket, nombreCliente, equipo, detalleEquipo, detalleProblema, solucion, estadoTicket.Nombre, TicketsPagos.Estado FROM reportes LEFT JOIN TicketsPagos ON reportes.estadoPago = TicketsPagos.ID_Pagos JOIN Servicios ON Reportes.servicioID = Servicios.[ID-servicios] JOIN estadoTicket ON Reportes.estadoTicket = estadoTicket.EstadoTicketID WHERE [reportesID] = " + IDReporte, conexion))
                        {
                            SqlDataReader registro = commando.ExecuteReader();
                            if (registro.Read())
                            {
                                txtCliente.Text = registro["nombreCliente"].ToString();
                                txtEquipo.Text = registro["equipo"].ToString();
                                txtDescripcionEquipo.Text = registro["detalleEquipo"].ToString();
                                txtDetalle.Text = registro["detalleProblema"].ToString();
                                txtSolución.Text = registro["solucion"].ToString();
                                txtEstadoPago.Text = registro["Estado"].ToString();
                                txtTiempoEstimado.Text = registro["dias"].ToString();

                                cbxEstadoTicket.DataSource = ticketsDA.MostrarEstadoTicket().Tables[0];
                                cbxEstadoTicket.DisplayMember = "Nombre";
                                cbxEstadoTicket.ValueMember = "EstadoTicketID";
                                cbxEstadoTicket.SelectedValue = registro["estadoTicket"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }
            }

        }

        private void cbxReportes_Click(object sender, EventArgs e)
        {
            LLenarFormConReporteSeleccionado();
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string EstadoTicket = cbxEstadoTicket.Text;
            string Reporte = cbxReporte.Text;
            string Equipo = txtEquipo.Text;
            string Cliente = txtCliente.Text;
            string DetalleEquipo = txtDescripcionEquipo.Text;
            string DetalleProblema = txtDetalle.Text;
            string Solucion = txtSolución.Text;
            if (String.IsNullOrEmpty(EstadoTicket) || String.IsNullOrEmpty(Solucion) || String.IsNullOrEmpty(Reporte) || String.IsNullOrEmpty(Equipo) || String.IsNullOrEmpty(Cliente) || String.IsNullOrEmpty(DetalleEquipo) || String.IsNullOrEmpty(DetalleProblema))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                bool result = EstadoTicket.Equals("Seleccione");
                if (result)
                {
                    core.messageBox("Favor de seleccionar un estado de ticket valido.");
                }
                else
                {
                    //Se agrega el registro de usuario//
                    ticketsDA.Modificar(RecuperarInformación());
                    LimpiarEntradas();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Mensaje = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (Mensaje)
            {
                case DialogResult.Yes:
                    ticketsDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
                    RefrescarGrid();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        private void cbxFolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarFormConReporteSeleccionado();
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void cbxEstadoTicket_Click(object sender, EventArgs e)
        {
            CargarComboboxEstadoTicket();
        }

    }
}