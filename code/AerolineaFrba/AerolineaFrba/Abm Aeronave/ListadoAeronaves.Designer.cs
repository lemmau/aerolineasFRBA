namespace AerolineaFrba.Abm_Aeronave
{
    partial class ListadoAeronaves
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
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvAeronaves = new System.Windows.Forms.DataGridView();
            this.IdDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricanteDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matriculaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoServicioDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nButacasDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fueraServicioDGV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaReinicioDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finVidaUtilDGV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoDeServicio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFabricante = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAeronaves)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(677, 380);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 30;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(125, 380);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 29;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(30, 380);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 28;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(86, 85);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvAeronaves
            // 
            this.dgvAeronaves.AllowUserToAddRows = false;
            this.dgvAeronaves.AllowUserToDeleteRows = false;
            this.dgvAeronaves.ColumnHeadersHeight = 20;
            this.dgvAeronaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDGV,
            this.fabricanteDGV,
            this.modeloDGV,
            this.matriculaDGV,
            this.tipoServicioDGV,
            this.nButacasDGV,
            this.kgDgv,
            this.fueraServicioDGV,
            this.fechaReinicioDGV,
            this.finVidaUtilDGV});
            this.dgvAeronaves.Location = new System.Drawing.Point(30, 134);
            this.dgvAeronaves.MultiSelect = false;
            this.dgvAeronaves.Name = "dgvAeronaves";
            this.dgvAeronaves.ReadOnly = true;
            this.dgvAeronaves.RowHeadersWidth = 30;
            this.dgvAeronaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAeronaves.Size = new System.Drawing.Size(740, 240);
            this.dgvAeronaves.TabIndex = 26;
            // 
            // IdDGV
            // 
            this.IdDGV.DataPropertyName = "ID";
            this.IdDGV.HeaderText = "Id";
            this.IdDGV.MinimumWidth = 100;
            this.IdDGV.Name = "IdDGV";
            this.IdDGV.ReadOnly = true;
            this.IdDGV.Visible = false;
            // 
            // fabricanteDGV
            // 
            this.fabricanteDGV.HeaderText = "Fabricante";
            this.fabricanteDGV.Name = "fabricanteDGV";
            this.fabricanteDGV.ReadOnly = true;
            this.fabricanteDGV.Width = 80;
            // 
            // modeloDGV
            // 
            this.modeloDGV.HeaderText = "Modelo";
            this.modeloDGV.Name = "modeloDGV";
            this.modeloDGV.ReadOnly = true;
            this.modeloDGV.Width = 80;
            // 
            // matriculaDGV
            // 
            this.matriculaDGV.HeaderText = "Matricula";
            this.matriculaDGV.Name = "matriculaDGV";
            this.matriculaDGV.ReadOnly = true;
            this.matriculaDGV.Width = 85;
            // 
            // tipoServicioDGV
            // 
            this.tipoServicioDGV.DataPropertyName = "S_NOMBRE";
            this.tipoServicioDGV.HeaderText = "Servicio";
            this.tipoServicioDGV.Name = "tipoServicioDGV";
            this.tipoServicioDGV.ReadOnly = true;
            this.tipoServicioDGV.Width = 90;
            // 
            // nButacasDGV
            // 
            this.nButacasDGV.HeaderText = "Butacas";
            this.nButacasDGV.Name = "nButacasDGV";
            this.nButacasDGV.ReadOnly = true;
            this.nButacasDGV.Width = 50;
            // 
            // kgDgv
            // 
            this.kgDgv.HeaderText = "KG";
            this.kgDgv.Name = "kgDgv";
            this.kgDgv.ReadOnly = true;
            this.kgDgv.Width = 50;
            // 
            // fueraServicioDGV
            // 
            this.fueraServicioDGV.HeaderText = "Fuera Servicio";
            this.fueraServicioDGV.Name = "fueraServicioDGV";
            this.fueraServicioDGV.ReadOnly = true;
            this.fueraServicioDGV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fueraServicioDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fueraServicioDGV.Width = 81;
            // 
            // fechaReinicioDGV
            // 
            this.fechaReinicioDGV.HeaderText = "Reincorporacion";
            this.fechaReinicioDGV.Name = "fechaReinicioDGV";
            this.fechaReinicioDGV.ReadOnly = true;
            // 
            // finVidaUtilDGV
            // 
            this.finVidaUtilDGV.HeaderText = "Fin Vida Util";
            this.finVidaUtilDGV.Name = "finVidaUtilDGV";
            this.finVidaUtilDGV.ReadOnly = true;
            this.finVidaUtilDGV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.finVidaUtilDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.finVidaUtilDGV.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMatricula);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTipoDeServicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbFabricante);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(86, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 54);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // tbMatricula
            // 
            this.tbMatricula.Location = new System.Drawing.Point(475, 22);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(63, 20);
            this.tbMatricula.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Matrícula:";
            // 
            // cbTipoDeServicio
            // 
            this.cbTipoDeServicio.FormattingEnabled = true;
            this.cbTipoDeServicio.Location = new System.Drawing.Point(287, 22);
            this.cbTipoDeServicio.Name = "cbTipoDeServicio";
            this.cbTipoDeServicio.Size = new System.Drawing.Size(104, 21);
            this.cbTipoDeServicio.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Servicio:";
            // 
            // cbFabricante
            // 
            this.cbFabricante.FormattingEnabled = true;
            this.cbFabricante.Location = new System.Drawing.Point(84, 22);
            this.cbFabricante.Name = "cbFabricante";
            this.cbFabricante.Size = new System.Drawing.Size(95, 21);
            this.cbFabricante.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fabricante:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(571, 85);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ListadoAeronaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 418);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvAeronaves);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscar);
            this.Name = "ListadoAeronaves";
            this.Text = "Listado de Aeronaves";
            this.Load += new System.EventHandler(this.ListadoAeronaves_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAeronaves)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvAeronaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricanteDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn matriculaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoServicioDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nButacasDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgDgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fueraServicioDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaReinicioDGV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn finVidaUtilDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTipoDeServicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFabricante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
    }
}