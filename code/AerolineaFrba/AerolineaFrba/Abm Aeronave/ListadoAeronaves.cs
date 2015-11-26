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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ListadoAeronaves : Form
    {
        public ListadoAeronaves()
        {
            InitializeComponent();

            /*cbFabricante.Items.Clear();
            cbTipoDeServicio.Items.Clear();
            
            cbFabricante.SelectedIndex = -1;
            cbTipoDeServicio.SelectedIndex = -1;
            
            dgvAeronaves.AutoGenerateColumns = false;*/
        }

        private String Matricula
        {
            get
            {
                return tbMatricula.Text;
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

        private String FabricanteSeleccionado
        {
            get
            {
                if (cbFabricante.SelectedItem == null)
                    return null;

                return cbFabricante.GetItemText(cbFabricante.SelectedItem);
            }
        }

        /* CARGO EL DGV */

        private void CargarAeronaves()
        {
            dgvAeronaves.Rows.Clear();

            //como el textbox filtro tiene un maximo de 255 no valido rango.
            foreach (Aeronave aeronave in Aeronave.Get(Matricula.Trim(), IdTipoDeServicioSeleccionado, FabricanteSeleccionado))
                AgregarAeronave(aeronave);
        }

        private void AgregarAeronave(Aeronave aeronave)
        {
            Int32 index = dgvAeronaves.Rows.Add();
            dgvAeronaves.Rows[index].Cells["IdDGV"].Value = aeronave.Id;
            dgvAeronaves.Rows[index].Cells["fabricanteDGV"].Value = aeronave.fabricante;
            dgvAeronaves.Rows[index].Cells["modeloDGV"].Value = aeronave.modelo;
            dgvAeronaves.Rows[index].Cells["matriculaDGV"].Value = aeronave.matricula;
            dgvAeronaves.Rows[index].Cells["tipoServicioDGV"].Value = aeronave.tipoServicio.Nombre;
            dgvAeronaves.Rows[index].Cells["nButacasDGV"].Value = aeronave.cantButacas;
            dgvAeronaves.Rows[index].Cells["kgDgv"].Value = aeronave.espacioKG;

            /*if (aeronave.idBaja == 2)
            {
                dgvAeronaves.Rows[index].Cells["fueraServicioDGV"].Value = false;
                dgvAeronaves.Rows[index].Cells["fechaReinicioDGV"].Value = null;//aeronave.fechaReinicio;
                dgvAeronaves.Rows[index].Cells["finVidaUtilDGV"].Value = true;
            }
            else
            {
                dgvAeronaves.Rows[index].Cells["fueraServicioDGV"].Value = true;
                dgvAeronaves.Rows[index].Cells["fechaReinicioDGV"].Value = null; //aeronave.fechaReinicio;
                dgvAeronaves.Rows[index].Cells["finVidaUtilDGV"].Value = false;
            }*/
        }

        /* CARGO EL CB.FABRICANTE */

        private void CargarFabricante()
        {
            cbFabricante.Items.Clear();
            cbFabricante.DataSource = Aeronave.cargarCBFabricantes();
            cbFabricante.DisplayMember = "fabricante"; //Nombre del campo del data table que queres mostrar
            //cbFabricante.ValueMember = "";// Nombre del campo clave (id) del datatable para saber que selecciono
        }

        /* CARGO EL CB.TIPOSERVICIO */

        private void CargarTiposDeServicio()
        {
            cbTipoDeServicio.DisplayMember = "Value";
            cbTipoDeServicio.ValueMember = "Key";
            cbTipoDeServicio.Items.Clear();
            foreach (var tipo in Logica.TipoServicio.Get())
                cbTipoDeServicio.Items.Add(new KeyValuePair<Int32, String>(tipo.Id, tipo.Nombre));
        }

        private void ListadoAeronaves_Load(object sender, EventArgs e)
        {
            CargarAeronaves();
            CargarFabricante();
            CargarTiposDeServicio();
            cbFabricante.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                CargarAeronaves();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbMatricula.Text = String.Empty;
            cbFabricante.SelectedIndex = -1;
            cbTipoDeServicio.SelectedIndex = -1;
            CargarAeronaves();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            var aeronave = new FormInsertarAeronave();
            aeronave.Show();
        }

        public Aeronave AeronaveSeleccionada
        {
            get
            {
                if (dgvAeronaves.SelectedRows.Count == 0)
                    return null;

                int idAeronave = Int32.Parse(dgvAeronaves.SelectedRows[0].Cells["IdDGV"].Value.ToString());
                return Aeronave.GetById(idAeronave);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (AeronaveSeleccionada == null)
            {
                MessageBox.Show("Seleccione una aeronave del listado.");
                return;
            }

            var aeronave = new FormActualizarAeronave(AeronaveSeleccionada);
            aeronave.Show();
        }

        public Int32? IdSeleccionado
        {
            get
            {
                if (dgvAeronaves.SelectedRows.Count == 0)
                    return null;

                return Int32.Parse(dgvAeronaves.SelectedRows[0].Cells["IdDGV"].Value.ToString());
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (AeronaveSeleccionada == null)
            {
                MessageBox.Show("Seleccione una aeronave del listado.");
                return;
            }

            var aeronave = new FormEliminarAeronave(AeronaveSeleccionada.Id);
            aeronave.Show();
        }

    }
}