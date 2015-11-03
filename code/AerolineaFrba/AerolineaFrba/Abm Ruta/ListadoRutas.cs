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
    public partial class ListadoRutas : Form
    {
        public ListadoRutas()
        {
            InitializeComponent();
        }

        private void ListadoRutas_Load(object sender, EventArgs e)
        {

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbCiudadOrigen.ResetText();
            cbCiudadDestino.ResetText();
            cbTipoDeServicio.ResetText();
        }
    }
}
