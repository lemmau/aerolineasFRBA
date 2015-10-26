﻿using System;
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
    public partial class Menu : Form
    {
        private IngresoLogin padre;
        public Menu(IngresoLogin _padre)
        {
            InitializeComponent();
            if (SharedData.Instance().currentRolId != 0)
            {
                //Rol _rol = Rol.GetById(SharedData.Instance().currentRolId);
                foreach (ToolStripMenuItem item in menuStripSecciones.Items)
                {
                    foreach (ToolStripMenuItem innerItem in item.DropDownItems)
                    {
                        //MessageBox.Show("ID_ROL: " + SharedData.Instance().currentRolId + "ABM: " + innerItem.Tag.ToString());
                        innerItem.Visible = (FuncionalidadDeRol.GetById(SharedData.Instance().currentRolId, innerItem.Tag.ToString()).Where(x => x.Seleccionado).ToList().Count > 0);
                    }
                }
                menuStripSecciones.Refresh();
            }

            lbFecha.Text = lbFecha.Text + " " + SharedData.Instance().fechaDelSistema.ToShortDateString();
        }

        public Menu()
        {
            InitializeComponent();
            if (SharedData.Instance().currentRolId != 0)
            {
                foreach (ToolStripMenuItem item in menuStripSecciones.Items)
                {
                    foreach (ToolStripMenuItem innerItem in item.DropDownItems)
                    {
                        innerItem.Visible = (FuncionalidadDeRol.GetById(SharedData.Instance().currentRolId, innerItem.Tag.ToString()).Where(x => x.Seleccionado).ToList().Count > 0);
                    }
                }
                menuStripSecciones.Refresh();
            }

            lbFecha.Text = lbFecha.Text + " " + SharedData.Instance().fechaDelSistema.ToShortDateString();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void compraDePasajeEncomiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void seccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void itemRoles_Click(object sender, EventArgs e)
        {
            Abm_Rol.ListadoRoles _listado_roles = new Abm_Rol.ListadoRoles();
            _listado_roles.ShowDialog();
        }
    }
}
