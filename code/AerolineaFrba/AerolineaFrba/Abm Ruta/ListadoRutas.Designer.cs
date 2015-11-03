namespace AerolineaFrba.Abm_Ruta
{
    partial class ListadoRutas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTipoDeServicio = new System.Windows.Forms.ComboBox();
            this.cbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudadOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudadDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioBaseKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioBasePasaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTipoDeServicio);
            this.groupBox1.Controls.Add(this.cbCiudadDestino);
            this.groupBox1.Controls.Add(this.cbCiudadOrigen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 158);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // cbTipoDeServicio
            // 
            this.cbTipoDeServicio.FormattingEnabled = true;
            this.cbTipoDeServicio.Location = new System.Drawing.Point(302, 106);
            this.cbTipoDeServicio.Name = "cbTipoDeServicio";
            this.cbTipoDeServicio.Size = new System.Drawing.Size(170, 21);
            this.cbTipoDeServicio.TabIndex = 5;
            // 
            // cbCiudadDestino
            // 
            this.cbCiudadDestino.FormattingEnabled = true;
            this.cbCiudadDestino.Location = new System.Drawing.Point(302, 66);
            this.cbCiudadDestino.Name = "cbCiudadDestino";
            this.cbCiudadDestino.Size = new System.Drawing.Size(170, 21);
            this.cbCiudadDestino.TabIndex = 4;
            // 
            // cbCiudadOrigen
            // 
            this.cbCiudadOrigen.FormattingEnabled = true;
            this.cbCiudadOrigen.Location = new System.Drawing.Point(302, 26);
            this.cbCiudadOrigen.Name = "cbCiudadOrigen";
            this.cbCiudadOrigen.Size = new System.Drawing.Size(170, 21);
            this.cbCiudadOrigen.TabIndex = 3;
            this.cbCiudadOrigen.SelectedIndexChanged += new System.EventHandler(this.cbCiudadOrigen_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Servicio";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ciudad Destino";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ciudad Origen";
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.codigoRuta,
            this.ciudadOrigen,
            this.ciudadDestino,
            this.precioBaseKG,
            this.precioBasePasaje});
            this.dgvRoles.Location = new System.Drawing.Point(10, 224);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(762, 376);
            this.dgvRoles.TabIndex = 8;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 400;
            // 
            // codigoRuta
            // 
            this.codigoRuta.HeaderText = "Cod Ruta";
            this.codigoRuta.Name = "codigoRuta";
            this.codigoRuta.ReadOnly = true;
            // 
            // ciudadOrigen
            // 
            this.ciudadOrigen.HeaderText = "Ciudad Origen";
            this.ciudadOrigen.Name = "ciudadOrigen";
            this.ciudadOrigen.ReadOnly = true;
            this.ciudadOrigen.Width = 200;
            // 
            // ciudadDestino
            // 
            this.ciudadDestino.HeaderText = "Ciudad Destino";
            this.ciudadDestino.Name = "ciudadDestino";
            this.ciudadDestino.ReadOnly = true;
            this.ciudadDestino.Width = 200;
            // 
            // precioBaseKG
            // 
            this.precioBaseKG.HeaderText = "Precio Base x KG";
            this.precioBaseKG.Name = "precioBaseKG";
            this.precioBaseKG.ReadOnly = true;
            this.precioBaseKG.Width = 110;
            // 
            // precioBasePasaje
            // 
            this.precioBasePasaje.HeaderText = "Precio Base x Pasaje";
            this.precioBasePasaje.Name = "precioBasePasaje";
            this.precioBasePasaje.ReadOnly = true;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(697, 606);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 13;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(115, 606);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(20, 606);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(602, 182);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(20, 182);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ListadoRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 641);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Name = "ListadoRutas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Rutas";
            this.Load += new System.EventHandler(this.ListadoRutas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTipoDeServicio;
        private System.Windows.Forms.ComboBox cbCiudadDestino;
        private System.Windows.Forms.ComboBox cbCiudadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudadDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioBaseKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioBasePasaje;
    }
}