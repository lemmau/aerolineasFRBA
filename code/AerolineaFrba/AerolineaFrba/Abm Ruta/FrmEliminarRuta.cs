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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FrmEliminarRuta : Form
    {
        Ruta _ruta = null;
        Int32 idRutaBaja;

        public FrmEliminarRuta(Int32 idRuta)
        {
            InitializeComponent();
            idRutaBaja = idRuta;
            _ruta = Ruta.Get(idRuta);
        }

        private void CargarTiposDeServicio()
        {
            cbTipoDeServicio.DisplayMember = "Value";
            cbTipoDeServicio.ValueMember = "Key";
            cbTipoDeServicio.Items.Clear();
            foreach (var tipo in Logica.TipoServicio.Get())
                cbTipoDeServicio.Items.Add(new KeyValuePair<Int32, String>(tipo.Id, tipo.Nombre));
        }

        private void CargarCiudades(ComboBox cbCiudad)
        {
            cbCiudad.DisplayMember = "Value";
            cbCiudad.ValueMember = "Key";
            cbCiudad.Items.Clear();
            foreach (var tipo in Logica.Ciudad.Get())
                cbCiudad.Items.Add(new KeyValuePair<Int32, String>(tipo.Id, tipo.Nombre));
        }

        private void CargarRuta()
        {
            tbPrecioBasePasaje.Text = _ruta.precioBasePasaje.ToString();
            tbPrecioBaseKG.Text = _ruta.precioBaseKG.ToString();
            cbCiudadOrigen.SelectedText = _ruta.ciudadOrigen.Nombre;
            cbCiudadDestino.SelectedText = _ruta.ciudadDestino.Nombre;
            cbTipoDeServicio.SelectedText = _ruta.tipoServicio.Nombre;
            cbActiva.Checked = _ruta.Estado;
        }

        private void FrmEliminarRuta_Load(object sender, EventArgs e)
        {
            CargarTiposDeServicio();
            CargarCiudades(cbCiudadOrigen);
            CargarCiudades(cbCiudadDestino);
            CargarRuta();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            DataTable dtVuelosProgramados;
            DataTable dtItemsACancelar;
            Int32 idVueloProgramado;
            DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
            Int32 idCompra;
            String tipoItem;
            Int32 idPasajeEncomienda;
            String motivoDevolucion;

            Int32 resultado = Ruta.ChequearVuelosProgramados(idRutaBaja, fechaActual);

            //La ruta tiene vuelos programados
            if (resultado == 1)
            {
                try
                {
                    dtVuelosProgramados = Ruta.BajaRutaYBuscaVuelosProgramados(idRutaBaja, fechaActual);

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

                            Logica.Devolucion.CancelarPasajeEncomienda(idCompra, tipoItem, idPasajeEncomienda, fechaActual, motivoDevolucion);
                        }

                        dtItemsACancelar.Dispose();
                    }

                    dtVuelosProgramados.Dispose();

                    MessageBox.Show("La Ruta se ha eliminado satisfactoriamente y sus vuelos programados junto con sus pasajes/encomiendas fueron cancelados");

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            //La ruta NO tiene vuelos programados
            if (resultado == 2)
            {
                try
                {
                    _ruta.Eliminate();
                    MessageBox.Show("La Ruta se ha eliminado satisfactoriamente");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CargarCliente()
        {
            cbCiudadOrigen.SelectedText = _ruta.ciudadOrigen.Nombre;
            cbCiudadDestino.SelectedText = _ruta.ciudadDestino.Nombre;
            cbTipoDeServicio.SelectedText = _ruta.tipoServicio.Nombre;
            tbPrecioBasePasaje.Text = _ruta.precioBasePasaje.ToString();
            tbPrecioBaseKG.Text = _ruta.precioBaseKG.ToString();
        }
    }
}
