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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FrmEliminarRuta : Form
    {
        Ruta _ruta = null;

        public FrmEliminarRuta(Int32 idRuta)
        {
            InitializeComponent();
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
