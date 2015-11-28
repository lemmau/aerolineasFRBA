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

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaMillas : Form
    {
        public ConsultaMillas()
        {
            InitializeComponent();
        }

        private void CargarDGVMillas()
        {
            Int32 dniNum = 0;
            Int32 id;
            String nombre;
            Int32 acumuladas;
            DateTime fechaActual;

            try
            {
                dniNum = Int32.Parse(tbDNI.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El número de DNI debe ser numérico y sin puntos");
            }

            using (var datadatosClie = Millas.GetDatosClieByDNI(dniNum))
            {
                id = Int32.Parse(datadatosClie.Rows[0][datadatosClie.Columns["Id"].Ordinal].ToString());
                nombre = datadatosClie.Rows[0][datadatosClie.Columns["nombre"].Ordinal].ToString();
            }

            fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);

            acumuladas = Millas.GetMillasAcumuladas(id, fechaActual);
            lbMillasAcumuladas.Visible = true;
            lbMillasAcumuladas.Text = acumuladas.ToString();

            lbNombre.Visible = true;
            lbNombre.Text = nombre;

            dgvMillas.Rows.Clear();

            foreach (Millas milla in Millas.Get(id, fechaActual))
                AgregarMilla(milla);
        }

        private void AgregarMilla(Millas milla)
        {
            Int32 index = dgvMillas.Rows.Add();
            dgvMillas.Rows[index].Cells["millasDGV"].Value = milla.millas;
            dgvMillas.Rows[index].Cells["fechaDGV"].Value = milla.fecha;
            dgvMillas.Rows[index].Cells["detalleDGV"].Value = milla.detalle;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarDGVMillas();
        }

        private void ConsultaMillas_Load(object sender, EventArgs e)
        {

        }

    }
}