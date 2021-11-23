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
    public partial class Reporte : Form
    {
        string connectionData = ConfigurationManager.ConnectionStrings["connectionProperties"].ConnectionString;
        SqlConnection Conexion;
        Core core = new Core();

        public SqlConnection EstablecerConexión()
        {
            this.Conexion = new SqlConnection(this.connectionData);
            return this.Conexion;
        }

        string mensajeBox = "Los campos con * son importantes y no pueden estar vacios.";
        ReportesDA reportesDA = new ReportesDA();
        ReportesLB reportesLB = new ReportesLB();
        public Reporte()
        {
            InitializeComponent();
            RefrescarGrid();
            CargarCombobox();
        }

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvReportes.DataSource = reportesDA.MostrarReportes().Tables[0];
            dgvReportes.Columns[0].Visible = false; //ID-Reporte-Problema/
            dgvReportes.Columns[1].Visible = false; //ID-Cliente/
            dgvReportes.Columns[2].HeaderText = "Folio";
            dgvReportes.Columns[3].HeaderText = "Cliente";
            dgvReportes.Columns[4].HeaderText = "Equipo";
            dgvReportes.Columns[5].HeaderText = "Detalle del equipo";
            dgvReportes.Columns[6].HeaderText = "Detalle del problema";
            dgvReportes.Columns[7].Visible = false; //Solución/             
            dgvReportes.Columns[8].Visible = false; //EstadoPago/
            dgvReportes.Columns[9].Visible = false; //EstadoTickets/
            dgvReportes.Columns[10].Visible = false; //ServiciosID/
            dgvReportes.Columns[11].HeaderText = "Servicio";
            dgvReportes.Columns[12].HeaderText = "Costo del servicio";
            dgvReportes.Columns[13].HeaderText = "Descrición del servicio";
            dgvReportes.Columns[14].HeaderText = "Duración en días";
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvReportes.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                btnAgregar.Enabled = false;
                cbxCliente.DataSource = null;
                cbxCliente.Items.Clear();
                cbxServicios.DataSource = null;
                cbxServicios.Items.Clear();
                lblID.Text = dgvReportes.Rows[indice].Cells[0].Value.ToString();
                lblIDClientes.Text = dgvReportes.Rows[indice].Cells[1].Value.ToString();
                txtFolio.Text = dgvReportes.Rows[indice].Cells[2].Value.ToString();
                txtEquipo.Text = dgvReportes.Rows[indice].Cells[4].Value.ToString();
                txtDescripcionEquipo.Text = dgvReportes.Rows[indice].Cells[5].Value.ToString();
                txtDetalle.Text = dgvReportes.Rows[indice].Cells[6].Value.ToString();
                txtPrecio.Text = dgvReportes.Rows[indice].Cells[12].Value.ToString();
                txtDescripcionServicio.Text = dgvReportes.Rows[indice].Cells[13].Value.ToString();
                txtTiempoServicio.Text = dgvReportes.Rows[indice].Cells[14].Value.ToString();
                RegistroSeleccionadoCombobox(indice);
                RegistroSeleccionadoServicioCombobox(indice);
            }
        }
        public void RegistroSeleccionadoCombobox(int indice)
        {
            int IDCliente = 0; int.TryParse(dgvReportes.Rows[indice].Cells[1].Value.ToString(), out IDCliente);
            cbxCliente.DataSource = reportesDA.MostrarClientes().Tables[0];
            cbxCliente.DisplayMember = "nombre";
            cbxCliente.ValueMember = "ID-Cliente";
            cbxCliente.SelectedValue = IDCliente;
        }

        public void RegistroSeleccionadoServicioCombobox(int indice)
        {
            int IDServicio = 0; int.TryParse(dgvReportes.Rows[indice].Cells[10].Value.ToString(), out IDServicio);
            cbxServicios.DataSource = reportesDA.MostrarServicios().Tables[0];
            cbxServicios.DisplayMember = "nombre";
            cbxServicios.ValueMember = "ID-servicios";
            cbxServicios.SelectedValue = IDServicio;
        }

        private ReportesLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int reportesID = 0; int.TryParse(lblID.Text, out reportesID);
            int clienteID = 0;
            int servicioID = 0;
            if (cbxCliente.SelectedValue != null)
            {
                int.TryParse(cbxCliente.SelectedValue.ToString(), out clienteID);
            }
            if (cbxServicios.SelectedValue != null)
            {
                int.TryParse(cbxServicios.SelectedValue.ToString(), out servicioID);
            }
            reportesLB.ID_ReporteProblema = reportesID;
            reportesLB.ID_Cliente = clienteID;
            reportesLB.servicioID = servicioID;
            reportesLB.Folio = txtFolio.Text;
            reportesLB.NombreCliente = cbxCliente.Text;
            reportesLB.Equipo = txtEquipo.Text;
            reportesLB.DetalleEquipo = txtDescripcionEquipo.Text;
            reportesLB.DetalleProblema = txtDetalle.Text;
            return reportesLB;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Cliente = cbxCliente.Text;
            string Servicio = cbxServicios.Text;
            string Folio = txtFolio.Text;
            string Equipo = txtEquipo.Text;
            string DetalleEquipo = txtDescripcionEquipo.Text;
            string DetalleProblema = txtDetalle.Text;
            if (String.IsNullOrEmpty(Cliente) || String.IsNullOrEmpty(Servicio) || String.IsNullOrEmpty(Folio) || String.IsNullOrEmpty(Equipo) || String.IsNullOrEmpty(DetalleEquipo) || String.IsNullOrEmpty(DetalleProblema))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                bool result = Cliente.Equals("Seleccione");
                if (result)
                {
                    core.messageBox("Favor de seleccionar un cliente valido.");
                }
                else
                {
                    //Se agrega el registro de usuario//
                    reportesDA.Modificar(RecuperarInformación());
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
                    reportesDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
                    RefrescarGrid();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Servicio = cbxServicios.Text;
            string Cliente = cbxCliente.Text;
            string Folio = txtFolio.Text;
            string Equipo = txtEquipo.Text;
            string DetalleEquipo = txtDescripcionEquipo.Text;
            string DetalleProblema = txtDetalle.Text;
            if (String.IsNullOrEmpty(Cliente) || String.IsNullOrEmpty(Servicio) || String.IsNullOrEmpty(Folio) || String.IsNullOrEmpty(Equipo) || String.IsNullOrEmpty(DetalleEquipo) || String.IsNullOrEmpty(DetalleProblema))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                bool result = Cliente.Equals("Seleccione");
                if (result)
                {
                    core.messageBox("Favor de seleccionar un cliente valido.");
                }
                else
                {
                    //Se agrega el registro de usuario//
                    reportesDA.Agregar(RecuperarInformación());
                    LimpiarEntradas();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        public void LimpiarEntradas()
        {
            lblID.Text = "";
            txtFolio.Text = "";
            txtEquipo.Text = "";
            txtDescripcionEquipo.Text = "";
            txtDetalle.Text = "";
            CargarComboboxServicios();
            CargarCombobox(); //Lo pone en el indice 0 al ser pocos registros//
            //Activar/desactivar botones según lo que se requiera //
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RefrescarGrid();
        }
        public void CargarCombobox()
        {
            cbxCliente.DataSource = reportesDA.MostrarClientes().Tables[0];
            cbxCliente.DisplayMember = "nombre";
            cbxCliente.ValueMember = "ID-Cliente";
        }

        public void CargarComboboxServicios()
        {
            cbxServicios.DataSource = reportesDA.MostrarServicios().Tables[0];
            cbxServicios.DisplayMember = "nombre";
            cbxServicios.ValueMember = "ID-servicios";
        }

        public void LLenarFormConClienteSeleccionado()
        {
            int IDCliente = 0;
            if (cbxCliente.SelectedValue != null)
            {
                int.TryParse(cbxCliente.SelectedValue.ToString(), out IDCliente);
            }
            string Cliente = cbxCliente.Text;
            bool result = Cliente.Equals("Seleccione");
            if (!result)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(connectionData))
                    {
                        conexion.Open();
                        using (SqlCommand commando = new SqlCommand("SELECT [ID-Cliente], equipo, detalleEquipo FROM clientes WHERE [ID-Cliente] = " + IDCliente + "", conexion))
                        {
                            SqlDataReader registro = commando.ExecuteReader();
                            if (registro.Read())
                            {
                                txtEquipo.Text = registro["equipo"].ToString();
                                txtDescripcionEquipo.Text = registro["detalleEquipo"].ToString();
                                txtFolio.Text = "Ticket" + registro["ID-Cliente"].ToString();
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

        private void cbxCliente_Click(object sender, EventArgs e)
        {
            LLenarFormConClienteSeleccionado();
        }

        private void cbxServicios_SelectedIndexChanged(object sender, EventArgs e)
        {

            int IDServicios = 0;
            if (cbxServicios.SelectedValue != null)
            {
                int.TryParse(cbxServicios.SelectedValue.ToString(), out IDServicios);
            }
            string Servicios = cbxServicios.Text;
            bool result = Servicios.Equals("Seleccione");
            if (!result)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(connectionData))
                    {
                        conexion.Open();
                        using (SqlCommand commando = new SqlCommand("SELECT * FROM servicios WHERE [ID-servicios] = " + IDServicios + "", conexion))
                        {
                            SqlDataReader registro = commando.ExecuteReader();
                            if (registro.Read())
                            {
                                txtDescripcionServicio.Text = registro["nombre"].ToString();
                                txtPrecio.Text = registro["costo"].ToString();
                                txtDescripcionServicio.Text = registro["descripcion"].ToString();
                                txtTiempoServicio.Text = registro["dias"].ToString();
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
    }
    
}
