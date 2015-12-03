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

namespace AerolineaFrba.DevolucionPasajeEncomienda
{
    public partial class DevolucionPasajeEncomienda : Form
    {
        public DevolucionPasajeEncomienda()
        {
            InitializeComponent();
        }

        private void CargarItemsCompra()
        {
            try
            {
                Int32 idCompraNum = -1;
                Int32 idPasajeNum = -1;
                Int32 idEncomiendaNum = -1;
                int mensaje;
                DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);

                mensaje = Logica.Devolucion.validarIngresos(tbCompra.Text.Trim(), tbPasaje.Text.Trim(), tbEncomienda.Text.Trim());

                if (mensaje == 1)
                {
                    MessageBox.Show("Debe de ingresar algun valor de búsqueda");
                }
                else
                {
                    if (mensaje == 2)
                    {
                        MessageBox.Show("Los filtros de búsqueda deben ser numéricos");
                    }
                    else
                    {
                        dgvDevolucion.Rows.Clear();

                        if (!(tbCompra.Text.Trim() == ""))
                        {
                            idCompraNum = Int32.Parse(tbCompra.Text);
                        }
                        if (!(tbPasaje.Text.Trim() == ""))
                        {
                            idPasajeNum = Int32.Parse(tbPasaje.Text);
                        }
                        if (!(tbEncomienda.Text.Trim() == ""))
                        {
                            idEncomiendaNum = Int32.Parse(tbEncomienda.Text);
                        }

                        foreach (Logica.Devolucion item in Logica.Devolucion.Get(idCompraNum, idPasajeNum, idEncomiendaNum, fechaActual))
                            AgregarItem(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AgregarItem(Logica.Devolucion item)
        {
            Int32 index = dgvDevolucion.Rows.Add();
            dgvDevolucion.Rows[index].Cells["nroCompraDGV"].Value = item.idCompra;
            dgvDevolucion.Rows[index].Cells["tipoDGV"].Value = item.tipo;
            dgvDevolucion.Rows[index].Cells["codigoDGV"].Value = item.idPasajeEncomienda;
            dgvDevolucion.Rows[index].Cells["fechaDGV"].Value = item.fechaCompra;
            dgvDevolucion.Rows[index].Cells["nombreDGV"].Value = item.nombreCompleto;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
        }

        private void LimpiarObjetos()
        {
            tbCompra.Text = String.Empty;
            tbPasaje.Text = String.Empty;
            tbEncomienda.Text = String.Empty;
            dgvDevolucion.Rows.Clear();
            motivoDevolucion.Clear();
            motivoDevolucion.Enabled = false;
            dgvDevolucion.Columns["cancelarDGV"].ReadOnly = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarItemsCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvDevolucion.Columns["cancelarDGV"].ReadOnly = false;
            motivoDevolucion.Clear();
            motivoDevolucion.Enabled = false;
        }

        private void btnConfirmarSeleccion_Click(object sender, EventArgs e)
        {
            bool existe = false;

            motivoDevolucion.Clear();

            foreach (DataGridViewRow item in dgvDevolucion.Rows)
            {
                if (item.Cells["cancelarDGV"].Value != null)
                {
                    if ((Boolean)item.Cells["cancelarDGV"].Value == true)
                    {
                        existe = true;
                    }
                }
            }

            if (existe == false)
                MessageBox.Show("Debe seleccionar el/los items a cancelar");
            else
            {
                MessageBox.Show("Ingrese un motivo de cancelación");
                motivoDevolucion.Enabled = true;
                //una vez que confirmo seleccion, impide que modifique la misma
                dgvDevolucion.Columns["cancelarDGV"].ReadOnly = true;
            }
        }

        private void btnConfirmarDevolucion_Click(object sender, EventArgs e)
        {
            Int32 idCompra;
            Int32 idPasajeEncomienda;
            String tipo;
            DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
            String motivo = motivoDevolucion.Text.Trim(); ;
            bool existe = false;

            if (motivo == "")
            {
                MessageBox.Show("Ingrese un motivo de cancelación");
            }
            else
            {
                foreach (DataGridViewRow item in dgvDevolucion.Rows)
                {
                    if (item.Cells["cancelarDGV"].Value != null)
                    {
                        if ((Boolean)item.Cells["cancelarDGV"].Value == true)
                        {
                            idCompra = Int32.Parse(item.Cells["nroCompraDGV"].Value.ToString());
                            tipo = item.Cells["tipoDGV"].Value.ToString();
                            idPasajeEncomienda = Int32.Parse(item.Cells["codigoDGV"].Value.ToString());

                            Logica.Devolucion.CancelarPasajeEncomienda(idCompra, tipo.Trim(), idPasajeEncomienda, fechaActual, motivo);
                            existe = true;
                        }
                    }
                }

                if (existe == true)
                {
                    MessageBox.Show("La devolución se ha registrado correctamente");
                    // Una vez que cancelo un item, limpio el DGV para no permitir volver a seleccionar un item ya devuelto
                    LimpiarObjetos();
                }
            }
        }

    }
}
