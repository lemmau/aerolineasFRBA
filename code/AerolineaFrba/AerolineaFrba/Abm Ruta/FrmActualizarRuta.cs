using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FrmActualizarRuta : Form
    {
        public FrmActualizarRuta()
        {
            InitializeComponent();
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
        private void FrmActualizarRuta_Load(object sender, EventArgs e)
        {

        }
    }
}
