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
        Aeronave aeronaveAReemplazar;
        Int32 idPosibleReemplazo;

        public DecisionEliminar(Aeronave aeronave, DateTime fechaActual, DateTime fechaReincorporacion, Int32 tipoBaja)
        {
            InitializeComponent();
            aeronaveAReemplazar = aeronave;
            idAeronaveLocal = aeronaveAReemplazar.Id;
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
            DataTable dtVuelosProgramados;
            DataTable dtPosiblesReemplazos;
            DataTable dtItemsATransferir;
            Int32 idVueloProgramado;
            Int32 idViaje;
            String tipoItem;
            Int32 control = 1;
            Int32 idPasajeEncomienda;

            try
            {
                dtPosiblesReemplazos = Aeronave.BuscaPosiblesReemplazos(aeronaveAReemplazar.Id, /*aeronaveAReemplazar.tipoServicio.Id, */aeronaveAReemplazar.modelo, aeronaveAReemplazar.fabricante);

                foreach (DataRow row in dtPosiblesReemplazos.Rows)
                {
                    control = 1;
                    idPosibleReemplazo = Int32.Parse(row["id"].ToString());
                    dtVuelosProgramados = Aeronave.BuscaVuelosProgramados(idAeronaveLocal, fechaActualLocal, fechaReincorporacionLocal, tipoBajaLocal);

                    foreach (DataRow row2 in dtVuelosProgramados.Rows)
                    {
                        idViaje = Int32.Parse(row2["id"].ToString());
                        control = Aeronave.PuedeSatisfacerVuelo(idAeronaveLocal, idPosibleReemplazo, idViaje);
                        
                        //Si la aeronave no pudo cumplir con algun vuelo programado 
                        if (control == -1)
                        {
                            break;
                        }
                    }
                    
                    dtVuelosProgramados.Dispose();
                    //La aeronave puede cumplir con todos los vuelos programados
                    if (control == 1)
                    {
                        break;
                    }
                }

                dtPosiblesReemplazos.Dispose();
                //Ninguna aeronave pudo cumplir con todos los vuelos programados
                if (control == -1)
                {
                    MessageBox.Show("No hay ninguna aeronave disponible para el reemplazo. Cancele los vuelos programados o bien ingrese una nueva aeronave");
                }
                //Hay una aeronave que cumple, generamos todos los tramites para el reemplazo
                else
                {

                    dtVuelosProgramados = Aeronave.BajaAeronaveYBuscaVuelosProgramados(idAeronaveLocal, fechaActualLocal, fechaReincorporacionLocal, tipoBajaLocal);

                    foreach (DataRow row in dtVuelosProgramados.Rows)
                    {
                        idVueloProgramado = Int32.Parse(row["id"].ToString());
                        
                        dtItemsATransferir = Aeronave.TransferirVueloProgramadoYBuscaItemsATransferir(idAeronaveLocal, idPosibleReemplazo, idVueloProgramado);

                        foreach (DataRow row2 in dtItemsATransferir.Rows)
                        {
                            idPasajeEncomienda = Int32.Parse(row2["idPasajeEncomienda"].ToString());
                            tipoItem = row2["tipoItem"].ToString();

                            Logica.Aeronave.TransferirPasajeEncomienda(idPasajeEncomienda, tipoItem, idPosibleReemplazo);
                        }

                        dtItemsATransferir.Dispose();
                    }

                    dtVuelosProgramados.Dispose();                  
                    
                    MessageBox.Show("La aeronave se dio de baja y sus vuelos programados se reasignaron a otra aeronave");
                }
                
                //Pasarle todos los viajes de idAeronaveLocal a idPosibleReemplazo

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        
    }
}
