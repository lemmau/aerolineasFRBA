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

namespace AerolineaFrba.Abm_Rol
{
    public partial class FrmEliminarRol : Form
    {
        private Rol _rol = null;

        public FrmEliminarRol(Rol rol)
        {
            InitializeComponent();
            _rol = rol;
            tbNombre.Text = rol.Nombre;
            cbActivo.Enabled = rol.Estado;

            dgvFuncionalidades.Rows.Clear();

            //como el textbox filtro tiene un maximo de 255 no valido rango.
            foreach (var func in rol.Funcionalidades)
                AgregarFuncionalidad(func);
        }

        private void AgregarFuncionalidad(Funcionalidad func)
        {
            Int32 index = dgvFuncionalidades.Rows.Add();
            dgvFuncionalidades.Rows[index].Cells["Id"].Value = func.Id;
            dgvFuncionalidades.Rows[index].Cells["Nombre"].Value = func.Nombre;
            dgvFuncionalidades.Rows[index].Cells["Seleccionado"].Value = func.Activo;
        }

        private void FrmEliminarRol_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                _rol.Eliminate();

                MessageBox.Show("Rol se ha borrado satisfactoriamente");
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
