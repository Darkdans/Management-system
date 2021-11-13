using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Presentación;
using RecoinssoFinal.Presentación.Clientes;
using RecoinssoFinal.Presentación.Tecnicos;

namespace RecoinssoFinal.Presentación
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
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

        //Clientes// 
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ClientesControl clientesControlForm = new ClientesControl();
            this.Hide();
            clientesControlForm.Show();
        }

        //Técnicos// 
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TecnicosControl tecnicosControlForm = new TecnicosControl();
            this.Hide();
            tecnicosControlForm.Show();
        }
    }
}
