namespace AerolineaFrba.DevolucionPasajeEncomienda
{
    partial class DevolucionPasajeEncomienda
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
            this.btnConfirmarSeleccion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.motivoDevolucion = new System.Windows.Forms.RichTextBox();
            this.btnConfirmarDevolucion = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvDevolucion = new System.Windows.Forms.DataGridView();
            this.cancelarDGV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nroCompraDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbEncomienda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPasaje = new System.Windows.Forms.TextBox();
            this.tbCompra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolucion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirmarSeleccion
            // 
            this.btnConfirmarSeleccion.Location = new System.Drawing.Point(288, 395);
            this.btnConfirmarSeleccion.Name = "btnConfirmarSeleccion";
            this.btnConfirmarSeleccion.Size = new System.Drawing.Size(121, 23);
            this.btnConfirmarSeleccion.TabIndex = 45;
            this.btnConfirmarSeleccion.Text = "Confirmar Selección";
            this.btnConfirmarSeleccion.UseVisualStyleBackColor = true;
            this.btnConfirmarSeleccion.Click += new System.EventHandler(this.btnConfirmarSeleccion_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 449);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Motivo Cancelación:";
            // 
            // motivoDevolucion
            // 
            this.motivoDevolucion.Location = new System.Drawing.Point(120, 471);
            this.motivoDevolucion.Name = "motivoDevolucion";
            this.motivoDevolucion.Size = new System.Drawing.Size(452, 158);
            this.motivoDevolucion.TabIndex = 44;
            this.motivoDevolucion.Text = "";
            // 
            // btnConfirmarDevolucion
            // 
            this.btnConfirmarDevolucion.Location = new System.Drawing.Point(286, 639);
            this.btnConfirmarDevolucion.Name = "btnConfirmarDevolucion";
            this.btnConfirmarDevolucion.Size = new System.Drawing.Size(121, 23);
            this.btnConfirmarDevolucion.TabIndex = 43;
            this.btnConfirmarDevolucion.Text = "Confirmar Devolución";
            this.btnConfirmarDevolucion.UseVisualStyleBackColor = true;
            this.btnConfirmarDevolucion.Click += new System.EventHandler(this.btnConfirmarDevolucion_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(274, 95);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 42;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvDevolucion
            // 
            this.dgvDevolucion.AllowUserToAddRows = false;
            this.dgvDevolucion.AllowUserToDeleteRows = false;
            this.dgvDevolucion.ColumnHeadersHeight = 20;
            this.dgvDevolucion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cancelarDGV,
            this.nroCompraDGV,
            this.tipoDGV,
            this.codigoDGV,
            this.fechaDGV,
            this.nombreDGV});
            this.dgvDevolucion.Location = new System.Drawing.Point(35, 144);
            this.dgvDevolucion.MultiSelect = false;
            this.dgvDevolucion.Name = "dgvDevolucion";
            this.dgvDevolucion.RowHeadersWidth = 30;
            this.dgvDevolucion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevolucion.Size = new System.Drawing.Size(623, 240);
            this.dgvDevolucion.TabIndex = 41;
            // 
            // cancelarDGV
            // 
            this.cancelarDGV.HeaderText = "Cancelar";
            this.cancelarDGV.Name = "cancelarDGV";
            this.cancelarDGV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cancelarDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cancelarDGV.Width = 60;
            // 
            // nroCompraDGV
            // 
            this.nroCompraDGV.HeaderText = "Nro Compra";
            this.nroCompraDGV.Name = "nroCompraDGV";
            this.nroCompraDGV.ReadOnly = true;
            this.nroCompraDGV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nroCompraDGV.Width = 80;
            // 
            // tipoDGV
            // 
            this.tipoDGV.HeaderText = "Item";
            this.tipoDGV.Name = "tipoDGV";
            this.tipoDGV.ReadOnly = true;
            this.tipoDGV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipoDGV.Width = 90;
            // 
            // codigoDGV
            // 
            this.codigoDGV.HeaderText = "Nro Item";
            this.codigoDGV.Name = "codigoDGV";
            this.codigoDGV.ReadOnly = true;
            this.codigoDGV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigoDGV.Width = 75;
            // 
            // fechaDGV
            // 
            this.fechaDGV.HeaderText = "Fecha Compra";
            this.fechaDGV.Name = "fechaDGV";
            this.fechaDGV.ReadOnly = true;
            this.fechaDGV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fechaDGV.Width = 110;
            // 
            // nombreDGV
            // 
            this.nombreDGV.HeaderText = "Nombre";
            this.nombreDGV.Name = "nombreDGV";
            this.nombreDGV.ReadOnly = true;
            this.nombreDGV.Width = 175;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbEncomienda);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPasaje);
            this.groupBox1.Controls.Add(this.tbCompra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(35, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 54);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // tbEncomienda
            // 
            this.tbEncomienda.Location = new System.Drawing.Point(508, 22);
            this.tbEncomienda.Name = "tbEncomienda";
            this.tbEncomienda.Size = new System.Drawing.Size(94, 20);
            this.tbEncomienda.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Código Encomienda:";
            // 
            // tbPasaje
            // 
            this.tbPasaje.Location = new System.Drawing.Point(284, 22);
            this.tbPasaje.Name = "tbPasaje";
            this.tbPasaje.Size = new System.Drawing.Size(94, 20);
            this.tbPasaje.TabIndex = 9;
            // 
            // tbCompra
            // 
            this.tbCompra.Location = new System.Drawing.Point(87, 22);
            this.tbCompra.Name = "tbCompra";
            this.tbCompra.Size = new System.Drawing.Size(94, 20);
            this.tbCompra.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código Pasaje:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro Compra:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(367, 95);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // DevolucionPasajeEncomienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 681);
            this.Controls.Add(this.btnConfirmarSeleccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.motivoDevolucion);
            this.Controls.Add(this.btnConfirmarDevolucion);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvDevolucion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscar);
            this.Name = "DevolucionPasajeEncomienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolución Pasaje/Encomienda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolucion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmarSeleccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox motivoDevolucion;
        private System.Windows.Forms.Button btnConfirmarDevolucion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvDevolucion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cancelarDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroCompraDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbEncomienda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPasaje;
        private System.Windows.Forms.TextBox tbCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
    }
}