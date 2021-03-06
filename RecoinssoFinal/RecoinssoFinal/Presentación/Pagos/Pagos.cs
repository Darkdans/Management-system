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

namespace RecoinssoFinal.Presentación.Reportes
{
    public partial class Pagos : Form
    {
        public Pagos()
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
        PagosDA pagosDA = new PagosDA();
        ReportesLB reportesLB = new ReportesLB();

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvPagos.DataSource = pagosDA.MostrarReportesEstadoPago().Tables[0];
            dgvPagos.Columns[0].Visible = false; //ID-Reporte-ID/
            dgvPagos.Columns[1].Visible = false; //ID-Cliente/
            dgvPagos.Columns[8].Visible = false; //ID-EstadoPago/
            dgvPagos.Columns[9].Visible = false; //ID-Pagos/
            dgvPagos.Columns[10].Visible = false; //ID-Pagos/
            dgvPagos.Columns[11].Visible = false; //ID-Pagos/
            dgvPagos.Columns[12].Visible = false; //ID-Pagos/
            //Se renombran los encabezados//
            dgvPagos.Columns[2].HeaderText = "Folio";
            dgvPagos.Columns[3].HeaderText = "Cliente";
            dgvPagos.Columns[4].HeaderText = "Equipo";
            dgvPagos.Columns[5].HeaderText = "Detalle del equipo";
            dgvPagos.Columns[6].HeaderText = "Detalle del problema";
            dgvPagos.Columns[7].HeaderText = "Solución propuesta";
            dgvPagos.Columns[13].HeaderText = "Estado de pago";
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvPagos.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                cbxReporte.DataSource = null;
                cbxReporte.Items.Clear();
                cbxEstadoPago.DataSource = null;
                cbxEstadoPago.Items.Clear();

                lblID.Text = dgvPagos.Rows[indice].Cells[0].Value.ToString();
                lblIDClientes.Text = dgvPagos.Rows[indice].Cells[1].Value.ToString();
                txtCliente.Text = dgvPagos.Rows[indice].Cells[3].Value.ToString();
                txtEquipo.Text = dgvPagos.Rows[indice].Cells[4].Value.ToString();
                txtDescripcionEquipo.Text = dgvPagos.Rows[indice].Cells[5].Value.ToString();
                txtDetalle.Text = dgvPagos.Rows[indice].Cells[6].Value.ToString();
                txtSolución.Text = dgvPagos.Rows[indice].Cells[7].Value.ToString();
                RegistroSeleccionadoComboboxReportes(indice);
                RegistroSeleccionadoComboboxEstadoPagos(indice);
            }
        }

        public void RegistroSeleccionadoComboboxReportes(int indice)
        {
            int IDReporte = 0; int.TryParse(dgvPagos.Rows[indice].Cells[0].Value.ToString(), out IDReporte);
            cbxReporte.DataSource = pagosDA.MostrarReportes().Tables[0];
            cbxReporte.DisplayMember = "folio";
            cbxReporte.ValueMember = "reportesID";
            cbxReporte.SelectedValue = IDReporte;
        }

        public void RegistroSeleccionadoComboboxEstadoPagos(int indice)
        {
            int IDEstadoPago = 0; int.TryParse(dgvPagos.Rows[indice].Cells[8].Value.ToString(), out IDEstadoPago);
            cbxEstadoPago.DataSource = pagosDA.MostrarEstadoPago().Tables[0];
            cbxEstadoPago.DisplayMember = "Estado";
            cbxEstadoPago.ValueMember = "ID_Pagos";
            cbxEstadoPago.SelectedValue = IDEstadoPago;
        }

        private ReportesLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int reportesID = 0;
            int clienteID = 0;
            int EstadoPagoID = 0;
            int.TryParse(lblID.Text, out reportesID);
            if (cbxReporte.SelectedValue != null)
            {
                int.TryParse(cbxReporte.SelectedValue.ToString(), out clienteID);
            }
            if (cbxEstadoPago.SelectedValue != null)
            {
                int.TryParse(cbxEstadoPago.SelectedValue.ToString(), out EstadoPagoID);
            }
            reportesLB.estadoPago = EstadoPagoID;
            reportesLB.ID_ReporteProblema = reportesID;
            reportesLB.ID_Cliente = clienteID;
            reportesLB.NombreCliente = cbxReporte.Text;
            reportesLB.Equipo = txtEquipo.Text;
            reportesLB.DetalleEquipo = txtDescripcionEquipo.Text;
            reportesLB.DetalleProblema = txtDetalle.Text;
            reportesLB.Solucion = txtSolución.Text;
            return reportesLB;
        }

        public void LimpiarEntradas()
        {
            lblID.Text = "";
            txtEquipo.Text = "";
            txtDescripcionEquipo.Text = "";
            txtDetalle.Text = "";
            txtSolución.Text = "";
            CargarComboboxReporte(); //Lo pone en el indice 0 al ser pocos registros//
            CargarComboboxEstadoPago();
            //Activar/desactivar botones según lo que se requiera //
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RefrescarGrid();
        }
        public void CargarComboboxReporte()
        {
            cbxReporte.DataSource = pagosDA.MostrarReportes().Tables[0];
            cbxReporte.DisplayMember = "folio";
            cbxReporte.ValueMember = "reportesID";
        }

        public void CargarComboboxEstadoPago()
        {
            cbxEstadoPago.DataSource = pagosDA.MostrarEstadoPago().Tables[0];
            cbxEstadoPago.DisplayMember = "Estado";
            cbxEstadoPago.ValueMember = "ID_Pagos";
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
                        using (SqlCommand commando = new SqlCommand("SELECT solucion, folio, nombreCliente, equipo, detalleEquipo, detalleProblema, estadoPago  FROM reportes WHERE [reportesID] = " + IDReporte, conexion))
                        {
                            SqlDataReader registro = commando.ExecuteReader();
                            if (registro.Read())
                            {
                                txtCliente.Text = registro["nombreCliente"].ToString();
                                txtEquipo.Text = registro["equipo"].ToString();
                                txtDescripcionEquipo.Text = registro["detalleEquipo"].ToString();
                                txtDetalle.Text = registro["detalleProblema"].ToString();
                                txtSolución.Text = registro["solucion"].ToString();
                                string Pago = registro["estadoPago"].ToString();
                                if (!String.IsNullOrEmpty(Pago))
                                {
                                    cbxEstadoPago.DataSource = pagosDA.MostrarEstadoPago().Tables[0];
                                    cbxEstadoPago.DisplayMember = "Estado";
                                    cbxEstadoPago.ValueMember = "ID_Pagos";
                                    cbxEstadoPago.SelectedValue = registro["estadoPago"].ToString();
                                }
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
            string EstadoPago = cbxEstadoPago.Text;
            string Reporte = cbxReporte.Text;
            string Equipo = txtEquipo.Text;
            string Cliente = txtCliente.Text;
            string DetalleEquipo = txtDescripcionEquipo.Text;
            string DetalleProblema = txtDetalle.Text;
            string Solucion = txtSolución.Text;
            if (String.IsNullOrEmpty(EstadoPago) || String.IsNullOrEmpty(Solucion) || String.IsNullOrEmpty(Reporte) || String.IsNullOrEmpty(Equipo) || String.IsNullOrEmpty(Cliente) || String.IsNullOrEmpty(DetalleEquipo) || String.IsNullOrEmpty(DetalleProblema))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                bool result = EstadoPago.Equals("Seleccione");
                if (result)
                {
                    core.messageBox("Favor de seleccionar un estado de pago valido.");
                }
                else
                {
                    //Se agrega el registro de usuario//
                    pagosDA.Modificar(RecuperarInformación());
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
                    pagosDA.Eliminar(RecuperarInformación());
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

        private void cbxEstadoPago_Click(object sender, EventArgs e)
        {
            CargarComboboxEstadoPago();
        }

    }
}