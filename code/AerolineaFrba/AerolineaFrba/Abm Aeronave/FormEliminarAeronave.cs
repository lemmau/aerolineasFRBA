using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using System.Configuration;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormEliminarAeronave : Form
    {

        Aeronave _aeronave = null;

        public FormEliminarAeronave(Int32 idAeronave)
        {
            InitializeComponent();
            _aeronave = Aeronave.GetById(idAeronave);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fechaReincorporacion.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fechaReincorporacion.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //  SI ES BAJA POR VIDA UTIL
            if (rbFinVidaUtil.Checked == true)
            {
                try
                {
                    DateTime fechaActual;
                    fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
                    _aeronave.BajateVidaUtil(fechaActual);
                    MessageBox.Show("La aeronave ha cumplido su vida util");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //  SI ES BAJA POR FUERA DE SERVICIO
            if (rbFueraServicio.Checked == true)
            {
                try
                {
                    DateTime fechaActual;
                    fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);

                    _aeronave.BajateFueraDeServicio(fechaActual, fechaReincorporacion.Value);

                    MessageBox.Show("La aeronave ha quedado fuera de servicio");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
