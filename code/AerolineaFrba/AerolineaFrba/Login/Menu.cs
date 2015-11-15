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

        private void itemCiudades_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.AbmCiudad ciudad = new Abm_Ciudad.AbmCiudad();
            ciudad.Show();
        }

        private void itemRutas_Click(object sender, EventArgs e)
        {
            Abm_Ruta.ListadoRutas _listado_rutas = new Abm_Ruta.ListadoRutas();
            _listado_rutas.Show();
        }

        private void generarViajeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Generacion_Viaje.Generar_Viaje _generar_viaje = new Generacion_Viaje.Generar_Viaje();

            _generar_viaje.ShowDialog();
        }

        private void registroLlegadaDeAeronaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_Llegada_Destino.Registro_llegada _registro_llegada = new Registro_Llegada_Destino.Registro_llegada();
            _registro_llegada.ShowDialog();
        }
    }
}
