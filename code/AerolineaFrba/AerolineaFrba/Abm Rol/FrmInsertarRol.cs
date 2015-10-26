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
    public partial class FrmInsertarRol : Form
    {
        private Rol _rol = null;
        public Rol RolInsertado
        {
            get
            {
                return _rol;
            }
        }

        public FrmInsertarRol()
        {
            InitializeComponent();
            _rol = new Rol();
            _rol.Funcionalidades = Funcionalidad.Get();
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

        private void FrmInsertarRol_Load(object sender, EventArgs e)
        {
            dgvFuncionalidades.Rows.Clear();

            //como el textbox filtro tiene un maximo de 255 no valido rango.
            foreach (var func in _rol.Funcionalidades)
                AgregarFuncionalidad(func);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbNombre.Text))
            {
                MessageBox.Show("El nombre del rol no puede estar vacio.");
                return;
            }

            try
            {
                CargarFuncionalidades();
                _rol.Nombre = tbNombre.Text;
                _rol.Estado = cbActivo.Checked;

                _rol.Insertate();

                MessageBox.Show("Rol creado satisfactoriamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
