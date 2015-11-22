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
    public partial class IngresoLogin : Form
    {
        public IngresoLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var intentos = Usuario.GetIntentos(txtUsuario.Text);
            if (intentos < 3)
            {
                Usuario _usuario = Usuario.GetByLogin(txtUsuario.Text, Usuario.SHA256Encripta(txtContrasenia.Text));
                if (_usuario != null)
                {
                    Usuario.SetIntentos(txtUsuario.Text, 0);

                    SharedData.Instance().currentUserId = _usuario.Id;

                    if (_usuario.Roles.Count > 1)
                    {
                        SeleccionarRol _selectRol = new SeleccionarRol(this);
                        _selectRol.Show();
                        this.Hide();
                    }
                    else if (_usuario.Roles.Count == 1)
                    {
                        SharedData.Instance().currentRolId = _usuario.Roles[0].Id;
                        Menu _menu = new Menu(this);
                        _menu.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("El usuario no tiene un rol asignado");
                }
                else
                {
                    Usuario.SetIntentos(txtUsuario.Text, intentos + 1);
                    MessageBox.Show("Usuario o contraseña no valido");
                }
            }
            else
            {
                Usuario.SetStatus(txtUsuario.Text, 0);    // actualizo status en 0
                MessageBox.Show("Usuario bloqueado por repetidos intentos de logueo");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Inicial prev = new Inicial();
            prev.Show();
            this.Hide();
        }

        private void Ingreso_Load(object sender, EventArgs e)
        {

        }
    }
}
