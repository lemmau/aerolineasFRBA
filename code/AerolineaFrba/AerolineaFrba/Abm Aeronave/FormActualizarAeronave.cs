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
    public partial class FormActualizarAeronave : Form
    {
        private Aeronave aeronaveActualizada = null;

        public FormActualizarAeronave(Aeronave aeronaveSeleccionada)
        {
            InitializeComponent();
            this.idInsertado = 0;

            aeronaveActualizada = aeronaveSeleccionada;

            lbFechaActual.Text = ConfigurationManager.AppSettings["FechaDelSistema"];
            tbFabricante.Text = aeronaveSeleccionada.fabricante;
            tbModelo.Text = aeronaveSeleccionada.modelo;
            tbMatricula.Text = aeronaveSeleccionada.matricula;
            tbKG.Text = aeronaveSeleccionada.espacioKG.ToString();
            tbButacasPasillo.Text = aeronaveSeleccionada.cantButacasPasillo.ToString();
            tbButacasVentanilla.Text = aeronaveSeleccionada.cantButacasVentanilla.ToString();
            CargarTiposDeServicio();
            cbTipoDeServicio.SelectedValue = aeronaveSeleccionada.tipoServicio;//aca, quiero que se muestre por defecto en el menu, la opcion que traigo elegida del dgv, pero no sale
        }

        public int idInsertado;

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 cantPasillo = 0;
                Int32 cantVentanilla = 0;
                int mensaje;

                mensaje = Aeronave.validarIngresos(tbFabricante.Text, tbModelo.Text, tbMatricula.Text, tbButacasPasillo.Text, tbButacasVentanilla.Text, tbKG.Text, IdTipoDeServicioSeleccionado);

                if (mensaje == 1)
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    if (mensaje == 2)
                    {
                        MessageBox.Show("El valor de KG y butacas debe ser numérico");
                    }
                    else
                    {
                        cantPasillo = Int32.Parse(tbButacasPasillo.Text);
                        cantVentanilla = Int32.Parse(tbButacasVentanilla.Text);

                        var aeronave = new Aeronave();

                        aeronave.fechaAlta = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
                        aeronave.Id = aeronaveActualizada.Id;
                        aeronave.fabricante = tbFabricante.Text;
                        aeronave.modelo = tbModelo.Text;
                        aeronave.matricula = tbMatricula.Text;
                        aeronave.espacioKG = Int32.Parse(tbKG.Text);
                        aeronave.cantButacasVentanilla = cantVentanilla;
                        aeronave.cantButacasPasillo = cantPasillo;
                        aeronave.tipoServicio = new TipoServicio();
                        aeronave.tipoServicio.Id = IdTipoDeServicioSeleccionado.Value;

                        aeronave.Actualizate(aeronaveActualizada.matricula);

                        MessageBox.Show("La aeronave se ha modificado satisfactoriamente");
                        this.idInsertado = aeronave.Id;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormActualizarAeronave_Load(object sender, EventArgs e)
        {

        }


    }
}

/*
Int32 cantPasillo = 0;
                Int32 cantVentanilla = 0;

                cantPasillo = Int32.Parse(tbButacasPasillo.Text);
                cantVentanilla = Int32.Parse(tbButacasVentanilla.Text);

                var aeronave = new Aeronave();

                aeronave.fechaAlta = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
                aeronave.Id = aeronaveActualizada.Id;
                aeronave.fabricante = tbFabricante.Text;
                aeronave.modelo = tbModelo.Text;
                aeronave.matricula = tbMatricula.Text;
                aeronave.espacioKG = Int32.Parse(tbKG.Text);
                aeronave.cantButacas = cantPasillo + cantVentanilla;
                aeronave.tipoServicio = new TipoServicio();
                aeronave.tipoServicio.Id = IdTipoDeServicioSeleccionado.Value;

                aeronave.Actualizate(cantPasillo, cantVentanilla);

                MessageBox.Show("La aeronave se ha modificado satisfactoriamente");
                this.idInsertado = aeronave.Id;
                DialogResult = DialogResult.OK;
                Close();
*/