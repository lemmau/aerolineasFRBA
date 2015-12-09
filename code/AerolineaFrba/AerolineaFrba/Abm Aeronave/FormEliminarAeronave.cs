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
        DateTime fechaActual;
        Int32 idAeronaveLocal = -1;

        public FormEliminarAeronave(Int32 idAeronave)
        {
            InitializeComponent();
            _aeronave = Aeronave.GetById(idAeronave);
            idAeronaveLocal = idAeronave;

            fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
            fechaActual.AddHours(00);
            fechaActual = fechaActual.AddMinutes(00);
            fechaActual = fechaActual.AddSeconds(00);
            fechaReincorporacion.Value = fechaActual;
        }
        
        private void rbFinVidaUtil_CheckedChanged(object sender, EventArgs e)
        {
            fechaReincorporacion.Enabled = false;
        }

        private void rbFueraServicio_CheckedChanged(object sender, EventArgs e)
        {
            fechaReincorporacion.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //  SI ES BAJA POR VIDA UTIL
            if (rbFinVidaUtil.Checked == true)
            {

                //Chequea si la aeronave tiene vuelos programados
                Int32 resultado = _aeronave.ChequeateVuelosProgramados(fechaActual, fechaReincorporacion.Value, 2);

                //La aeronave tiene vuelos programados
                if (resultado == 1)
                {
                    //MessageBox.Show("Hay vuelos programados"/*, "Aviso", MessageBoxButtons.YesNo*/);
                    DecisionEliminar decision = new DecisionEliminar(_aeronave, fechaActual, fechaReincorporacion.Value, 2);
                    decision.Show();
                }

                //La aeronave NO tiene vuelos programados
                if (resultado == 2)
                {
                    //MessageBox.Show("No hay vuelos programados");
                    try
                    {
                        _aeronave.BajateVidaUtil(fechaActual);
                        MessageBox.Show("La aeronave ha cumplido su vida util");
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
            //  SI ES BAJA POR FUERA DE SERVICIO
            if (rbFueraServicio.Checked == true)
            {

                //Chequea si la aeronave tiene vuelos programados
                Int32 resultado = _aeronave.ChequeateVuelosProgramados(fechaActual, fechaReincorporacion.Value, 1);

                //La aeronave tiene vuelos programados
                if (resultado == 3)
                {
                    //MessageBox.Show("Hay vuelos programados antes de que la aeronave se reincorpore");
                    DecisionEliminar decision = new DecisionEliminar(_aeronave, fechaActual, fechaReincorporacion.Value, 1);
                    decision.Show();
                }

                //La aeronave NO tiene vuelos programados
                if (resultado == 4)
                {
                    //MessageBox.Show("No hay vuelos programados en el periodo de fuera de servicio");
                    try
                    {
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
            Close();
        }

        private void FormEliminarAeronave_Load(object sender, EventArgs e)
        {

        }


    }
}
