using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RecoinssoFinal.Presentación.Servicios;
using RecoinssoFinal.Presentación.Clientes;
using RecoinssoFinal.Presentación.Tecnicos;
using RecoinssoFinal.Presentación.Reportes;
using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;

namespace RecoinssoFinal.Presentación
{
    public partial class VentanaPrincipal : Form
    {
        UsuariosLB usuariosLB = new UsuariosLB();
        Core core = new Core();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void BarradeTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public VentanaPrincipal()
        {
            InitializeComponent();
            customDesign();
        }

        //Todos los submenus se ponen invisibles>
        private void customDesign()
        {
            SubMenuServicios.Visible = false;
            SubMenuReportes.Visible = false;
            SubMenuTecnicos.Visible = false;
            SubPanelClientes.Visible = false;
        }

        //Todos los submenus se ponen en un if>
        private void hideSubMenu()
        {
            if (SubMenuServicios.Visible == true) { SubMenuServicios.Visible = false; }
            if (SubMenuReportes.Visible == true) { SubMenuReportes.Visible = false; }
            if (SubMenuTecnicos.Visible == true) { SubMenuTecnicos.Visible = false; }
            if (SubPanelClientes.Visible == true) { SubPanelClientes.Visible = false; }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            } else
            {
                subMenu.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres salir?", "Salir", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;   
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            showSubMenu(SubMenuServicios);
        }
        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            showSubMenu(SubPanelClientes);
        }

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            showSubMenu(SubMenuTecnicos);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(SubMenuReportes);
        }
        public void AbrirFormHija(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            RenombrarLabelPuesto();
        }

        private void RenombrarLabelPuesto()
        {
            int ID_puesto = 0; int.TryParse(lblPuesto.Text, out ID_puesto);
            if (ID_puesto <= 1)
            {
                lblPuesto.Text = "Puesto: Default";
                btnServicios.Visible = false;
                btnClientes.Visible = false;
                btnTecnicos.Visible = false;
                btnTickets.Visible = false;
                btnPagos.Visible = false;
                btnReportes.Visible = false;
                btnAlarmas.Visible = false;
                btnUsuarios.Visible = false;
                DialogResult result = MessageBox.Show("No cuenta con permisos, favor de comunicarse con el administrador del sistema.", "Mensaje del sistema", MessageBoxButtons.OK);
                switch (result)
                {
                    case DialogResult.Yes:
                        break;
                }
            }
            else if (ID_puesto == 2)
            { 
                //Todos los permisos//
                lblPuesto.Text = "Puesto: Administrador";
            }
            else if (ID_puesto == 3)
            {
                lblPuesto.Text = "Puesto: Primer Nivel";
                SubMenuServicios.Height = 40;
                btnControlServicios.Visible = false;

                SubPanelClientes.Height = 40;
                btnControlClientes.Visible = false;

                btnTecnicos.Visible = false;
                btnAlarmas.Visible = false;
                btnUsuarios.Visible = false;
            }
            else if (ID_puesto == 4)
            {
                lblPuesto.Text = "Puesto: Segundo Nivel";
                btnControlTecnicos.Visible = false;
                SubMenuTecnicos.Height = 40;
                btnUsuarios.Visible = false;
            }
            else
            {
                lblPuesto.Text = "Puesto: Clientes";
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new ClientesControl());
        }
 

        private void btnAltaServicios_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new ServiciosAlta());
        }

        private void btnControlServicios_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new ServiciosControl());
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new ClientesAlta());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new ClientesControl());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new TecnicosAlta());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new TecnicosControl());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Usuarios());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Reporte());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Soluciones());
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Pagos());
        }

   
    }
}
