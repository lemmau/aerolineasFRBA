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
    public partial class FrmActualizarRuta : Form
    {
        Ruta _ruta = null;
        public FrmActualizarRuta(Int32 idRuta)
        {
            InitializeComponent();
            _ruta = Ruta.Get(idRuta);
        }

        private Int32? IdCiudadOrigenSeleccionada
        {
            get
            {
                if (cbCiudadOrigen.SelectedItem == null)
                    return null;

                return (Int32?)((KeyValuePair<Int32, String>)cbCiudadOrigen.SelectedItem).Key;
            }
        }

        private Int32? IdCiudadDestinoSeleccionada
        {
            get
            {
                if (cbCiudadDestino.SelectedItem == null)
                    return null;

                return (Int32?)((KeyValuePair<Int32, String>)cbCiudadDestino.SelectedItem).Key;
            }
        }

        private Int32? IdTipoDeServicioSeleccionado
        {
            get
            {
                if (cbTipoDeServicio.SelectedItem == null)
                    return null;

                return (Int32?)((KeyValuePair<Int32, String>)cbTipoDeServicio.SelectedItem).Key;
            }
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
            cbActiva.Checked = _ruta.Estado;

            foreach (KeyValuePair<Int32, String> item in cbCiudadOrigen.Items)
            {
                if (String.Compare(item.Value, _ruta.ciudadOrigen.Nombre) == 0)
                {
                    cbCiudadOrigen.SelectedItem = item;
                    break;
                }
            }

            foreach (KeyValuePair<Int32, String> item in cbCiudadDestino.Items)
            {
                if (String.Compare(item.Value, _ruta.ciudadDestino.Nombre) == 0)
                {
                    cbCiudadDestino.SelectedItem = item;
                    break;
                }
            }

            foreach (KeyValuePair<Int32, String> item in cbTipoDeServicio.Items)
            {
                if (item.Key == _ruta.tipoServicio.Id)
                {
                    cbTipoDeServicio.SelectedItem = item;
                    break;
                }
            }

        }

        private void FrmActualizarRuta_Load(object sender, EventArgs e)
        {
            CargarCiudades(cbCiudadOrigen);
            CargarCiudades(cbCiudadDestino);
            CargarTiposDeServicio();
            CargarRuta();
            cbCiudadOrigen.Select();
        }

        private bool FormularioValido()
        {
            Boolean valido = true;
            decimal numeroDecimal;

            if (String.IsNullOrEmpty(cbCiudadOrigen.Text))
            {
                valido = false;
                MessageBox.Show("Debe seleccionar una 'Ciudad Origen'.");
            }

            if (String.IsNullOrEmpty(cbCiudadDestino.Text))
            {
                valido = false;
                MessageBox.Show("Debe seleccionar una 'Ciudad Destino' .");
            }

            if (String.IsNullOrEmpty(cbTipoDeServicio.Text))
            {
                valido = false;
                MessageBox.Show("Debe seleccionar un 'Tipo de Servicio'.");
            }

            if (String.IsNullOrEmpty(tbPrecioBasePasaje.Text))
            {
                valido = false;
                MessageBox.Show("El campo 'Precio Base Pasaje' no puede estar vacio.");
            }
            else if (!Decimal.TryParse(tbPrecioBasePasaje.Text, out numeroDecimal))
            {
                valido = false;
                MessageBox.Show("El campo 'Precio Base Pasaje' debe contener un numero valido.");
            }

            if (String.IsNullOrEmpty(tbPrecioBaseKG.Text))
            {
                valido = false;
                MessageBox.Show("El campo 'Precio Base KG' no puede estar vacio.");
            }
            else if (!Decimal.TryParse(tbPrecioBaseKG.Text, out numeroDecimal))
            {
                valido = false;
                MessageBox.Show("El campo 'Precio Base KG' debe contener un numero valido.");
            }

            return valido;
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            if (!FormularioValido()) return;

            try
            {
                _ruta.ciudadOrigen.Id = IdCiudadOrigenSeleccionada.Value;
                _ruta.ciudadDestino.Id = IdCiudadDestinoSeleccionada.Value;
                _ruta.tipoServicio.Id = IdTipoDeServicioSeleccionado.Value;
                _ruta.precioBasePasaje = Decimal.Parse(tbPrecioBasePasaje.Text);
                _ruta.precioBaseKG = Decimal.Parse(tbPrecioBaseKG.Text);

                _ruta.Estado = cbActiva.Checked;

                _ruta.Actualizate();

                MessageBox.Show("La ruta se ha actualizado exitosamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
