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
    public partial class DecisionEliminar : Form
    {
        Int32 idAeronaveLocal;
        DateTime fechaActualLocal;
        DateTime fechaReincorporacionLocal;
        Int32 tipoBajaLocal;

        public DecisionEliminar(Int32 idAeronave, DateTime fechaActual, DateTime fechaReincorporacion, Int32 tipoBaja)
        {
            InitializeComponent();
            idAeronaveLocal = idAeronave;
            fechaActualLocal = fechaActual;
            fechaReincorporacionLocal = fechaReincorporacion;
            tipoBajaLocal = tipoBaja;
        }

        private void btnCancelarBaja_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelarVuelos_Click(object sender, EventArgs e)
        {
            DataTable dtVuelosProgramados;
            DataTable dtItemsACancelar;
            Int32 idVueloProgramado;
            Int32 idCompra;
            String tipoItem;
            Int32 idPasajeEncomienda;
            String motivoDevolucion;

            try
            {
                dtVuelosProgramados = Aeronave.BajaAeronaveYBuscaVuelosProgramados(idAeronaveLocal, fechaActualLocal, fechaReincorporacionLocal, tipoBajaLocal);

                foreach (DataRow row in dtVuelosProgramados.Rows)
                {
                    idVueloProgramado = Int32.Parse(row["id"].ToString());
                    dtItemsACancelar = Aeronave.CancelarVueloProgramadoYBuscaItemsACancear(idVueloProgramado);

                    foreach (DataRow row2 in dtItemsACancelar.Rows)
                    {
                        idCompra = Int32.Parse(row2["idCompra"].ToString());
                        tipoItem = row2["tipoItem"].ToString();
                        idPasajeEncomienda = Int32.Parse(row2["idPasajeEncomienda"].ToString());
                        motivoDevolucion = row2["motivoDevolucion"].ToString();

                        Logica.Devolucion.CancelarPasajeEncomienda(idCompra, tipoItem, idPasajeEncomienda, fechaActualLocal, motivoDevolucion);
                    }

                    dtItemsACancelar.Dispose();
                }

                dtVuelosProgramados.Dispose();

                //Baja por vida util
                if (tipoBajaLocal == 2)
                {
                    MessageBox.Show("La aeronave ha cumplido su vida util y se cancelaron los vuelos programados");
                }
                //Baja por fuera de servicio
                if (tipoBajaLocal == 1)
                {
                    MessageBox.Show("La aeronave quedo fuera de servicio y se cancelaron los vuelos programados hasta su reincorporación");
                }
                    
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnReemplazarAeronave_Click(object sender, EventArgs e)
        {

        }



        
    }
}
