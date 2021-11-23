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
    public partial class Soluciones : Form
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
        SolucionesDA solucionDA = new SolucionesDA();
        ReportesLB reportesLB = new ReportesLB();
        public Soluciones()
        {
            InitializeComponent();
            RefrescarGrid();
            CargarCombobox();
        }

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvSoluciones.DataSource = solucionDA.MostrarReportes().Tables[0];
            dgvSoluciones.Columns[0].Visible = false; //ID-Reporte-ID/
            dgvSoluciones.Columns[1].Visible = false; //ID-Cliente/
            dgvSoluciones.Columns[8].Visible = false; //EstadoPago/
            dgvSoluciones.Columns[9].Visible = false; //EstadoTicket/
            dgvSoluciones.Columns[10].Visible = false; //servicioID/
            dgvSoluciones.Columns[11].Visible = false; //fecha/
            //Se renombran los encabezados//
            dgvSoluciones.Columns[2].HeaderText = "Folio";
            dgvSoluciones.Columns[3].HeaderText = "Cliente";
            dgvSoluciones.Columns[4].HeaderText = "Equipo";
            dgvSoluciones.Columns[5].HeaderText = "Detalle del equipo";
            dgvSoluciones.Columns[6].HeaderText = "Detalle del problema";
            dgvSoluciones.Columns[7].HeaderText = "Solución propuesta";
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvSoluciones.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                cbxReporte.DataSource = null;
                cbxReporte.Items.Clear();

                lblID.Text = dgvSoluciones.Rows[indice].Cells[0].Value.ToString();
                lblIDClientes.Text = dgvSoluciones.Rows[indice].Cells[1].Value.ToString();
                txtCliente.Text = dgvSoluciones.Rows[indice].Cells[3].Value.ToString();
                txtEquipo.Text = dgvSoluciones.Rows[indice].Cells[4].Value.ToString();
                txtDescripcionEquipo.Text = dgvSoluciones.Rows[indice].Cells[5].Value.ToString();
                txtDetalle.Text = dgvSoluciones.Rows[indice].Cells[6].Value.ToString();
                txtSolución.Text = dgvSoluciones.Rows[indice].Cells[7].Value.ToString();
                RegistroSeleccionadoCombobox(indice);
            }
        }

        public void RegistroSeleccionadoCombobox(int indice)
        {
            int IDReporte = 0; int.TryParse(dgvSoluciones.Rows[indice].Cells[0].Value.ToString(), out IDReporte);
            cbxReporte.DataSource = solucionDA.MostrarReportes().Tables[0];
            cbxReporte.DisplayMember = "folio";
            cbxReporte.ValueMember = "reportesID";
            cbxReporte.SelectedValue = IDReporte;
        }

        private ReportesLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int reportesID = 0; int.TryParse(lblID.Text, out reportesID);
            int clienteID = 0;
            if (cbxReporte.SelectedValue != null)
            {
                int.TryParse(cbxReporte.SelectedValue.ToString(), out clienteID);
            }
            reportesLB.ID_ReporteProblema = reportesID;
            reportesLB.ID_Cliente = clienteID;
            reportesLB.NombreCliente = cbxReporte.Text;
            reportesLB.Equipo = txtEquipo.Text;
            reportesLB.DetalleEquipo = txtDescripcionEquipo.Text;
            reportesLB.DetalleProblema = txtDetalle.Text;
            reportesLB.Solucion = txtSolución.Text;
            return reportesLB;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Mensaje = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (Mensaje)
            {
                case DialogResult.Yes:
                    solucionDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
                    RefrescarGrid();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            string Reporte = cbxReporte.Text;
            string Equipo = txtEquipo.Text;
            string Cliente = txtCliente.Text;
            string DetalleEquipo = txtDescripcionEquipo.Text;
            string DetalleProblema = txtDetalle.Text;
            string Solucion = txtSolución.Text;
            if (String.IsNullOrEmpty(Solucion) || String.IsNullOrEmpty(Reporte) || String.IsNullOrEmpty(Equipo) || String.IsNullOrEmpty(Cliente) || String.IsNullOrEmpty(DetalleEquipo) || String.IsNullOrEmpty(DetalleProblema))
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
                    solucionDA.Modificar(RecuperarInformación());
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
            txtEquipo.Text = "";
            txtDescripcionEquipo.Text = "";
            txtDetalle.Text = "";
            txtSolución.Text = "";
            CargarCombobox(); //Lo pone en el indice 0 al ser pocos registros//
            //Activar/desactivar botones según lo que se requiera //
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RefrescarGrid();
        }
        public void CargarCombobox()
        {
            cbxReporte.DataSource = solucionDA.MostrarReportes().Tables[0];
            cbxReporte.DisplayMember = "folio";
            cbxReporte.ValueMember = "reportesID";
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
                        using (SqlCommand commando = new SqlCommand("SELECT solucion, folio, nombreCliente, equipo, detalleEquipo, detalleProblema  FROM reportes WHERE [reportesID] = " + IDReporte, conexion))
                        {
                            SqlDataReader registro = commando.ExecuteReader();
                            if (registro.Read())
                            {
                                txtCliente.Text = registro["nombreCliente"].ToString();
                                txtEquipo.Text = registro["equipo"].ToString();
                                txtDescripcionEquipo.Text = registro["detalleEquipo"].ToString();
                                txtDetalle.Text =  registro["detalleProblema"].ToString();
                                txtSolución.Text = registro["solucion"].ToString();
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
    }
}