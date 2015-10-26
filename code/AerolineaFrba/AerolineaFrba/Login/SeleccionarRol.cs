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
using Configuracion;

namespace AerolineaFrba.Login
{
    public partial class SeleccionarRol : Form
    {
        private IngresoLogin padre;
        public SeleccionarRol(IngresoLogin _padre)
        {
            InitializeComponent();
            this.padre = _padre;
            Usuario _usr = Usuario.GetById(SharedData.Instance().currentUserId);
            cbRoles.Items.Clear();
            cbRoles.DataSource = new BindingSource(_usr.Roles, null);
            cbRoles.ValueMember = "Id";
            cbRoles.DisplayMember = "Nombre";
        }


        private void SeleccionDeRol_Load(object sender, EventArgs e)
        {

        }

        private void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            SharedData.Instance().currentRolId = Int32.Parse(cbRoles.SelectedValue.ToString());
            Usuario _usr = Usuario.GetById(SharedData.Instance().currentUserId);
            
            Menu _menu = new Menu(padre);
            _menu.Show();
            this.Hide();
        }
                
    }
}
