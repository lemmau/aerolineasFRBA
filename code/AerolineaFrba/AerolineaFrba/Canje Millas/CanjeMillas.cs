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

namespace AerolineaFrba.Canje_Millas
{
    public partial class CanjeMillas : Form
    {
        Int32 dniNum = 0;
        Int32 id;
        String nombre;
        Int32 acumuladas;
        DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);

        public CanjeMillas()
        {
            InitializeComponent();
        }

        private void CargarDGVCanjes()
        {
            using (var datadatosClie = Canje.GetDatosClieByDNI(dniNum))
            {
                id = Int32.Parse(datadatosClie.Rows[0][datadatosClie.Columns["Id"].Ordinal].ToString());
                nombre = datadatosClie.Rows[0][datadatosClie.Columns["nombre"].Ordinal].ToString();
            }

            acumuladas = Canje.GetMillasAcumuladas(id, fechaActual);
            lbMillasAcumuladas.Visible = true;
            lbMillasAcumuladas.Text = acumuladas.ToString();

            lbNombre.Visible = true;
            lbNombre.Text = nombre;

            dgvCanjes.Rows.Clear();

            foreach (Canje canje in Canje.Get(acumuladas))
                AgregarCanje(canje);
        }

        private void AgregarCanje(Canje canje)
        {
            Int32 index = dgvCanjes.Rows.Add();
            dgvCanjes.Rows[index].Cells["idDGV"].Value = canje.id;
            dgvCanjes.Rows[index].Cells["productoDGV"].Value = canje.producto;
            dgvCanjes.Rows[index].Cells["millasNecesariasDGV"].Value = canje.millasNecesarias;

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!FormularioValido()) return;
            try
            {
                dniNum = Int32.Parse(tbDNI.Text);
                CargarDGVCanjes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool FormularioValido()
        {
            Boolean valido = true;
            Int32 numeroEntero;

            if (!String.IsNullOrEmpty(tbDNI.Text)
                && !Int32.TryParse(tbDNI.Text, out numeroEntero))
            {
                valido = false;
                MessageBox.Show("El número de DNI debe ser numérico y sin puntos.");
            }

            if (String.IsNullOrEmpty(tbDNI.Text))
            {
                valido = false;
                MessageBox.Show("Indique DNI de búsqueda (sin puntos).");
            }

            return valido;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Int32 idProducto;
            Int32 cantidad;

            if (tbDNI.Text.Trim() == "")
                MessageBox.Show("No ha realizado ninguna transacción");
            else
            {
                idProducto = Convert.ToInt32(dgvCanjes.CurrentRow.Cells[0].Value);
                cantidad = Int32.Parse(nudCantidad.Value.ToString());
                acumuladas = Int32.Parse(lbMillasAcumuladas.Text.Trim());

                try
                {
                    Canje.ConfirmarCanje(idProducto, cantidad, Int32.Parse(tbDNI.Text), acumuladas, fechaActual);
                    MessageBox.Show("Canje efectuado de forma exitosa");
                    LimpiarCanjes();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LimpiarCanjes()
        {
            tbDNI.Text = String.Empty;
            lbNombre.Text = String.Empty;
            lbMillasAcumuladas.Text = String.Empty;
            dgvCanjes.Rows.Clear();
            nudCantidad.Value = 1;
        }


    }
}
