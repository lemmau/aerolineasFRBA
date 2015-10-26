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
    public partial class ListadoRoles : Form
    {
        public ListadoRoles()
        {
            InitializeComponent();
        }

        //Int32? = nullable. si no hay una fila seleccionado devuelvo null y listo.
        public Rol RolSeleccionado
        {
            get
            {
                if (dgvRoles.SelectedRows.Count == 0)
                    return null;

                int idRol = Int32.Parse(dgvRoles.SelectedRows[0].Cells["Id"].Value.ToString());
                return Rol.GetById(idRol);
            }
        }

        private void AgregarRol(Rol rol)
        {
            Int32 index = dgvRoles.Rows.Add();
            dgvRoles.Rows[index].Cells["Id"].Value = rol.Id;
            dgvRoles.Rows[index].Cells["Nombre"].Value = rol.Nombre;

            if (rol.Estado)
                dgvRoles.Rows[index].Cells["Activo"].Value = "SI";
            else
                dgvRoles.Rows[index].Cells["Activo"].Value = "NO";
        }

        private void CargarRoles()
        {
            dgvRoles.Rows.Clear();

            //como el textbox filtro tiene un maximo de 255 no valido rango.
            foreach (Rol rol in Rol.Get(tbNombre.Text))
                AgregarRol(rol);
        }

        private void BorrarRol()
        {
            dgvRoles.Rows.Remove(dgvRoles.SelectedRows[0]);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            var frm = new FrmInsertarRol();
            frm.ShowDialog();
            CargarRoles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (RolSeleccionado == null)
            {
                MessageBox.Show("Seleccione un rol del listado.");
                return;
            }

            var frm = new FrmEliminarRol(RolSeleccionado);

            frm.ShowDialog();
            CargarRoles();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (RolSeleccionado == null)
            {
                MessageBox.Show("Seleccione un rol del listado.");
                return;
            }

            var frm = new FrmActualizarRol(RolSeleccionado);

            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    var editado = frm.RolActualizado;

                    dgvRoles.SelectedRows[0].Cells["Nombre"].Value = editado.Nombre;
                    if (editado.Estado)
                        dgvRoles.SelectedRows[0].Cells["Activo"].Value = "SI";
                    else
                        dgvRoles.SelectedRows[0].Cells["Activo"].Value = "NO";
                    break;
                default:
                    //cerraron por otra razon, no hago nada.
                    break;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbNombre.Text = String.Empty;
            CargarRoles();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
