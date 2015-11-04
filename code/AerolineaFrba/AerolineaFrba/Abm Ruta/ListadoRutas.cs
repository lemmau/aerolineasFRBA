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
    public partial class ListadoRutas : Form
    {
        public ListadoRutas()
        {
            InitializeComponent();

            cbCiudadOrigen.Items.Clear();
            cbCiudadDestino.Items.Clear();
            cbTipoDeServicio.Items.Clear();

            cbCiudadOrigen.SelectedIndex = -1;
            cbCiudadDestino.SelectedIndex = -1;
            cbTipoDeServicio.SelectedIndex = -1;

            dgvRutas.AutoGenerateColumns = false;

            //cbTipoDeServicio.DataSource = new BindingSource(Logica.TipoServicio.Get(), null);
            //cbTipoDeServicio.ValueMember = "Id";
            //cbTipoDeServicio.DisplayMember = "Nombre";

            //cbCiudadOrigen.DataSource = new BindingSource(Logica.Ciudad.cargarDGVCiudad(), null);
            //cbCiudadOrigen.ValueMember = "Id";
            //cbCiudadOrigen.DisplayMember = "Nombre";

            //cbCiudadDestino.DataSource = new BindingSource(Logica.Ciudad.cargarDGVCiudad(), null);
            //cbCiudadDestino.ValueMember = "Id";
            //cbCiudadDestino.DisplayMember = "Nombre";
        }

        private String CodRuta
        {
            get
            {
                return tbCodRuta.Text;
            }
        }

        private Int32? IdTipoDeServicio
        {
            get
            {
                if (cbTipoDeServicio.SelectedItem == null)
                    return null;

                return (Int32?)((KeyValuePair<Int32, String>)cbTipoDeServicio.SelectedItem).Key;
            }
        }

        private Int32? IdCiudadOrigen
        {
            get
            {
                if (cbCiudadOrigen.SelectedItem == null)
                    return null;

                return (Int32?)((KeyValuePair<Int32, String>)cbCiudadOrigen.SelectedItem).Key;
            }
        }

        private Int32? IdCiudadDestino
        {
            get
            {
                if (cbCiudadDestino.SelectedItem == null)
                    return null;

                return (Int32?)((KeyValuePair<Int32, String>)cbCiudadDestino.SelectedItem).Key;
            }
        }

        public Int32? IdSeleccionado
        {
            get
            {
                if (dgvRutas.SelectedRows.Count == 0)
                    return null;


                return Int32.Parse(dgvRutas.SelectedRows[0].Cells["Id"].Value.ToString());
            }
        }

        //Int32? = nullable. si no hay una fila seleccionado devuelvo null y listo.
        public Ruta RutaSeleccionada
        {
            get
            {
                if (dgvRutas.SelectedRows.Count == 0)
                    return null;

                int idRuta = Int32.Parse(dgvRutas.SelectedRows[0].Cells["Id"].Value.ToString());
                return Ruta.GetById(idRuta);
            }
        }

        //private void AgregarRuta(Ruta ruta)
        //{
        //    Int32 index = dgvRutas.Rows.Add();
        //    dgvRutas.Rows[index].Cells["Id"].Value = ruta.Id;
        //    dgvRutas.Rows[index].Cells["codRuta"].Value = ruta.codRuta;
        //    dgvRutas.Rows[index].Cells["precioBaseKG"].Value = ruta.precioBaseKG;
        //    dgvRutas.Rows[index].Cells["precioBasePasaje"].Value = ruta.precioBasePasaje;
        //    dgvRutas.Rows[index].Cells["ciudadOrigen"].Value = ruta.ciudadOrigen;
        //    dgvRutas.Rows[index].Cells["ciudadDestino"].Value = ruta.ciudadDestino;
  
        //    if (ruta.Estado)
        //        dgvRutas.Rows[index].Cells["Activo"].Value = "SI";
        //    else
        //        dgvRutas.Rows[index].Cells["Activo"].Value = "NO";
        //}

        //private void CargarRutas()
        //{
        //    dgvRutas.Rows.Clear();

        //    //como el textbox filtro tiene un maximo de 255 no valido rango.
        //    foreach (Ruta ruta in Ruta.Get(cbCiudadOrigen.Text))
        //        AgregarRuta(ruta);
        //}

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

        private void ListadoRutas_Load(object sender, EventArgs e)
        {
            CargarTiposDeServicio();
            CargarCiudades(cbCiudadOrigen);
            CargarCiudades(cbCiudadDestino);
            //CargarRutas();
            cbCiudadOrigen.Select();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbCodRuta.Text = String.Empty;
            cbCiudadOrigen.SelectedIndex = -1;
            cbCiudadDestino.SelectedIndex = -1;
            cbTipoDeServicio.SelectedIndex = -1;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            var frm = new FrmInsertarRuta();
            frm.ShowDialog();
            //CargarRutas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // actualizar STATUS en DB y poner "ACTIVO" EN "NO"
            if (IdSeleccionado.HasValue)
            {
                var frm = new FrmEliminarRuta(IdSeleccionado.Value);
                frm.ShowDialog();
                btnBuscar_Click_1(sender, e);
            } else
            {
                MessageBox.Show("Seleccione una ruta del listado.");
                return;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                dgvRutas.DataSource = Ruta.Get(CodRuta, IdCiudadOrigen, IdCiudadDestino, IdTipoDeServicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbCiudadOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
