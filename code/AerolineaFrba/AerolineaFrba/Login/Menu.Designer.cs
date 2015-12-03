namespace AerolineaFrba.Login
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStripSecciones = new System.Windows.Forms.MenuStrip();
            this.seccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRutas = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCiudades = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAeronaves = new System.Windows.Forms.ToolStripMenuItem();
            this.generarViajeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registroLlegadaDeAeronaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraDePasajeEncomiendaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.devolCancelDePasajeEncomiendaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemConsultaMillas = new System.Windows.Forms.ToolStripMenuItem();
            this.canjeDeMillasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbFecha = new System.Windows.Forms.Label();
            this.menuStripSecciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStripSecciones
            // 
            this.menuStripSecciones.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStripSecciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seccionesToolStripMenuItem});
            this.menuStripSecciones.Location = new System.Drawing.Point(0, 0);
            this.menuStripSecciones.Name = "menuStripSecciones";
            this.menuStripSecciones.Size = new System.Drawing.Size(1037, 24);
            this.menuStripSecciones.TabIndex = 0;
            this.menuStripSecciones.Text = "mnSecciones";
            // 
            // seccionesToolStripMenuItem
            // 
            this.seccionesToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.seccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemRoles,
            this.itemRutas,
            this.itemCiudades,
            this.itemAeronaves,
            this.generarViajeToolStripMenuItem1,
            this.registroLlegadaDeAeronaveToolStripMenuItem,
            this.compraDePasajeEncomiendaToolStripMenuItem1,
            this.devolCancelDePasajeEncomiendaToolStripMenuItem1,
            this.itemConsultaMillas,
            this.canjeDeMillasToolStripMenuItem1,
            this.estadisticasToolStripMenuItem});
            this.seccionesToolStripMenuItem.Name = "seccionesToolStripMenuItem";
            this.seccionesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.seccionesToolStripMenuItem.Text = "Secciones";
            this.seccionesToolStripMenuItem.Click += new System.EventHandler(this.seccionesToolStripMenuItem_Click);
            // 
            // itemRoles
            // 
            this.itemRoles.Name = "itemRoles";
            this.itemRoles.Size = new System.Drawing.Size(268, 22);
            this.itemRoles.Tag = "ABM DE ROL";
            this.itemRoles.Text = "Roles";
            this.itemRoles.Click += new System.EventHandler(this.itemRoles_Click);
            // 
            // itemRutas
            // 
            this.itemRutas.Name = "itemRutas";
            this.itemRutas.Size = new System.Drawing.Size(268, 22);
            this.itemRutas.Tag = "ABM DE RUTA AEREA";
            this.itemRutas.Text = "Rutas";
            this.itemRutas.Click += new System.EventHandler(this.itemRutas_Click);
            // 
            // itemCiudades
            // 
            this.itemCiudades.Name = "itemCiudades";
            this.itemCiudades.Size = new System.Drawing.Size(268, 22);
            this.itemCiudades.Tag = "ABM DE CIUDAD";
            this.itemCiudades.Text = "Ciudades";
            this.itemCiudades.Click += new System.EventHandler(this.itemCiudades_Click);
            // 
            // itemAeronaves
            // 
            this.itemAeronaves.Name = "itemAeronaves";
            this.itemAeronaves.Size = new System.Drawing.Size(268, 22);
            this.itemAeronaves.Tag = "ABM DE AERONAVE";
            this.itemAeronaves.Text = "Aeronaves";
            this.itemAeronaves.Click += new System.EventHandler(this.itemAeronaves_Click);
            // 
            // generarViajeToolStripMenuItem1
            // 
            this.generarViajeToolStripMenuItem1.Name = "generarViajeToolStripMenuItem1";
            this.generarViajeToolStripMenuItem1.Size = new System.Drawing.Size(268, 22);
            this.generarViajeToolStripMenuItem1.Tag = "GENERACION DE VIAJE";
            this.generarViajeToolStripMenuItem1.Text = "Generar viaje";
            this.generarViajeToolStripMenuItem1.Click += new System.EventHandler(this.generarViajeToolStripMenuItem1_Click);
            // 
            // registroLlegadaDeAeronaveToolStripMenuItem
            // 
            this.registroLlegadaDeAeronaveToolStripMenuItem.Name = "registroLlegadaDeAeronaveToolStripMenuItem";
            this.registroLlegadaDeAeronaveToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.registroLlegadaDeAeronaveToolStripMenuItem.Tag = "REGISTRO DE LLEGADA A DESTINO";
            this.registroLlegadaDeAeronaveToolStripMenuItem.Text = "Registro llegada de Aeronave";
            this.registroLlegadaDeAeronaveToolStripMenuItem.Click += new System.EventHandler(this.registroLlegadaDeAeronaveToolStripMenuItem_Click);
            // 
            // compraDePasajeEncomiendaToolStripMenuItem1
            // 
            this.compraDePasajeEncomiendaToolStripMenuItem1.Name = "compraDePasajeEncomiendaToolStripMenuItem1";
            this.compraDePasajeEncomiendaToolStripMenuItem1.Size = new System.Drawing.Size(268, 22);
            this.compraDePasajeEncomiendaToolStripMenuItem1.Tag = "COMPRA DE PASAJE/ENCOMIENDA";
            this.compraDePasajeEncomiendaToolStripMenuItem1.Text = "Compra de Pasaje/Encomienda";
            // 
            // devolCancelDePasajeEncomiendaToolStripMenuItem1
            // 
            this.devolCancelDePasajeEncomiendaToolStripMenuItem1.Name = "devolCancelDePasajeEncomiendaToolStripMenuItem1";
            this.devolCancelDePasajeEncomiendaToolStripMenuItem1.Size = new System.Drawing.Size(268, 22);
            this.devolCancelDePasajeEncomiendaToolStripMenuItem1.Tag = "DEVOLUCION/CANCELACION DE PASAJE/ENCOMIENDA";
            this.devolCancelDePasajeEncomiendaToolStripMenuItem1.Text = "Devol/Cancel de Pasaje/Encomienda";
            // 
            // itemConsultaMillas
            // 
            this.itemConsultaMillas.Name = "itemConsultaMillas";
            this.itemConsultaMillas.Size = new System.Drawing.Size(268, 22);
            this.itemConsultaMillas.Tag = "CONSULTA DE MILLAS";
            this.itemConsultaMillas.Text = "Consulta de Millas";
            this.itemConsultaMillas.Click += new System.EventHandler(this.itemConsultaMillas_Click);
            // 
            // canjeDeMillasToolStripMenuItem1
            // 
            this.canjeDeMillasToolStripMenuItem1.Name = "canjeDeMillasToolStripMenuItem1";
            this.canjeDeMillasToolStripMenuItem1.Size = new System.Drawing.Size(268, 22);
            this.canjeDeMillasToolStripMenuItem1.Tag = "CANJE DE MILLAS";
            this.canjeDeMillasToolStripMenuItem1.Text = "Canje de Millas";
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.estadisticasToolStripMenuItem.Tag = "LISTADO ESTADISTICO";
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            this.estadisticasToolStripMenuItem.Click += new System.EventHandler(this.estadisticasToolStripMenuItem_Click);
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lbFecha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbFecha.Location = new System.Drawing.Point(90, 6);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(97, 13);
            this.lbFecha.TabIndex = 3;
            this.lbFecha.Text = "Fecha del Sistema:";
            this.lbFecha.Click += new System.EventHandler(this.label1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1037, 362);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.menuStripSecciones);
            this.MainMenuStrip = this.menuStripSecciones;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStripSecciones.ResumeLayout(false);
            this.menuStripSecciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.MenuStrip menuStripSecciones;
        private System.Windows.Forms.ToolStripMenuItem seccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemRoles;
        private System.Windows.Forms.ToolStripMenuItem itemRutas;
        private System.Windows.Forms.ToolStripMenuItem itemCiudades;
        private System.Windows.Forms.ToolStripMenuItem itemAeronaves;
        private System.Windows.Forms.ToolStripMenuItem generarViajeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registroLlegadaDeAeronaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraDePasajeEncomiendaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem devolCancelDePasajeEncomiendaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem itemConsultaMillas;
        private System.Windows.Forms.ToolStripMenuItem canjeDeMillasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.Label lbFecha;
    }
}