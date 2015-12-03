using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuracion;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        public int NumeroListado
        {
            get
            {
                if (radioButton1.Checked) return 1;
                if (radioButton2.Checked) return 2;
                if (radioButton3.Checked) return 3;
                if (radioButton4.Checked) return 4;
                if (radioButton5.Checked) return 5;

                return 0;
            }
        }

        public ListadoEstadistico()
        {
            InitializeComponent();

            cbSemestre.Items.Add(new KeyValuePair<Int32, String>(1, "1er"));
            cbSemestre.Items.Add(new KeyValuePair<Int32, String>(2, "2do"));

            cbSemestre.ValueMember = "Key";
            cbSemestre.DisplayMember = "Value";
            cbSemestre.SelectedIndex = 0;

            tbAnio.Text = SharedData.Instance().fechaDelSistema.Year.ToString();
        }

        private void btListar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 anio = 0;

                if (!Int32.TryParse(tbAnio.Text, out anio))
                {
                    MessageBox.Show("Ingrese un año valido");
                    return;
                }
                dgvListado.DataSource = null;


                Int32 semestre = ((KeyValuePair<Int32, String>)cbSemestre.SelectedItem).Key - 1;
                DateTime desde = new DateTime(anio, 1 + semestre * 6, 1);
                DateTime hasta;

                if (semestre == 1)  // 2do semestre (el ultimo)
                    hasta = new DateTime(anio + 1, 1, 1).AddDays(-1);
                else
                    hasta = new DateTime(anio, 1 + (semestre + 1) * 6, 1).AddDays(-1);

                Cursor.Current = Cursors.WaitCursor;
                dgvListado.DataSource = Logica.ListadoEstadistico.Get(NumeroListado, desde, hasta);
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
