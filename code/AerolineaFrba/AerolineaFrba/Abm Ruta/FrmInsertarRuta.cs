﻿using System;
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
    public partial class FrmInsertarRuta : Form
    {
        public FrmInsertarRuta()
        {
            InitializeComponent();
            this.idInsertado = 0;
        }

        public int idInsertado;

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

        private void FrmInsertarRuta_Load(object sender, EventArgs e)
        {
            CargarTiposDeServicio();
            CargarCiudades(cbCiudadOrigen);
            CargarCiudades(cbCiudadDestino);
            cbCiudadOrigen.Select();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            //if (!FormularioValido()) return;

            try
            {
                var ruta = new Ruta();

                ruta.ciudadOrigen.Id = IdCiudadOrigenSeleccionada.Value;
                ruta.ciudadDestino.Id = IdCiudadDestinoSeleccionada.Value;
                ruta.tipoServicio.Id = IdTipoDeServicioSeleccionado.Value;
                ruta.precioBasePasaje = Decimal.Parse(tbPrecioBasePasaje.Text);
                ruta.precioBaseKG = Decimal.Parse(tbPrecioBaseKG.Text);
                ruta.Estado = cbActiva.Checked;

                ruta.Insertate();

                MessageBox.Show("La ruta ha sido guardada satisfactoriamente");
                this.idInsertado = ruta.Id;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
