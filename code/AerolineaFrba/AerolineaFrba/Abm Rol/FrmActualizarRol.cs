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
    public partial class FrmActualizarRol : Form
    {
        private Rol _rol = null;
        public Rol RolActualizado
        {
            get
            {
                return _rol;
            }
        }

        public FrmActualizarRol(Rol rol)
        {
            InitializeComponent();
            _rol = rol;
            tbNombre.Text = rol.Nombre;
            cbActivo.Checked = rol.Estado;

            dgvFuncionalidades.Rows.Clear();

            //como el textbox filtro tiene un maximo de 255 no valido rango.
            foreach (var func in rol.Funcionalidades)
                AgregarFuncionalidad(func);
        }

        private void CargarFuncionalidades()
        {
            _rol.Funcionalidades.Clear();

            foreach (DataGridViewRow row in dgvFuncionalidades.Rows)
            {
                Boolean activado = Boolean.Parse(row.Cells["Seleccionado"].Value.ToString());
                if (!activado) continue;
                var func = new Funcionalidad();
                func.Id = Int32.Parse(row.Cells["Id"].Value.ToString());

                _rol.Funcionalidades.Add(func);

            }
        }

        private void AgregarFuncionalidad(Funcionalidad func)
        {
            Int32 index = dgvFuncionalidades.Rows.Add();
            dgvFuncionalidades.Rows[index].Cells["Id"].Value = func.Id;
            dgvFuncionalidades.Rows[index].Cells["Nombre"].Value = func.Nombre;
            dgvFuncionalidades.Rows[index].Cells["Seleccionado"].Value = func.Activo;
        }

        private void FrmActualizarRol_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarFuncionalidades();
                RolActualizado.Nombre = tbNombre.Text;
                RolActualizado.Estado = cbActivo.Checked;

                RolActualizado.Actualizate();
                MessageBox.Show("Rol actualizado satisfactoriamente");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
