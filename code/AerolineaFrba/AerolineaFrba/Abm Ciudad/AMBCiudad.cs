using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Logica;
using Configuracion;


namespace AerolineaFrba.Abm_Ciudad
{
    public partial class AbmCiudad : Form
    {
        public AbmCiudad()
        {
            InitializeComponent();
        }

        private void AbmCiudad_Load(object sender, EventArgs e)
        {
            DGVCiudad.DataSource = Ciudad.cargarDGVCiudad();
            DGVCiudad.Columns["Id"].Visible = false;
        }

        private void btnAltaCiudad_Click(object sender, EventArgs e)
        {
            try
            {
                Ciudad.insertarCiudad(txtAltaCiudad.Text.Trim());
                DGVCiudad.DataSource = Ciudad.cargarDGVCiudad();
                MessageBox.Show("Ciudad agregada satisfactoriamente");
                txtAltaCiudad.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAltaCiudad.Text = string.Empty;
            }
        }

        private void btnEliminarCiudad_Click(object sender, EventArgs e)
        {
            if (DGVCiudad.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }

            Ciudad.eliminarCiudad(Convert.ToInt32(DGVCiudad.CurrentRow.Cells[0].Value));

            DGVCiudad.DataSource = Ciudad.cargarDGVCiudad();
            MessageBox.Show("Ciudad eliminada satisfactoriamente");
        }

    }
}