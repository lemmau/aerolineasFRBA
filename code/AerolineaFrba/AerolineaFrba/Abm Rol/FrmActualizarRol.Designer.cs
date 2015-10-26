namespace AerolineaFrba.Abm_Rol
{
    partial class FrmActualizarRol
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
            this.GVRol = new System.Windows.Forms.GroupBox();
            this.cbActivo = new System.Windows.Forms.CheckBox();
            this.lbFuncionalidades = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.dgvFuncionalidades = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // GVRol
            // 
            this.GVRol.Controls.Add(this.cbActivo);
            this.GVRol.Controls.Add(this.lbFuncionalidades);
            this.GVRol.Controls.Add(this.tbNombre);
            this.GVRol.Controls.Add(this.lbNombre);
            this.GVRol.Controls.Add(this.dgvFuncionalidades);
            this.GVRol.Location = new System.Drawing.Point(12, 12);
            this.GVRol.Name = "GVRol";
            this.GVRol.Size = new System.Drawing.Size(407, 513);
            this.GVRol.TabIndex = 0;
            this.GVRol.TabStop = false;
            this.GVRol.Text = "Campos del Rol";
            // 
            // cbActivo
            // 
            this.cbActivo.AutoSize = true;
            this.cbActivo.Location = new System.Drawing.Point(334, 489);
            this.cbActivo.Name = "cbActivo";
            this.cbActivo.Size = new System.Drawing.Size(56, 17);
            this.cbActivo.TabIndex = 4;
            this.cbActivo.Text = "Activo";
            this.cbActivo.UseVisualStyleBackColor = true;
            // 
            // lbFuncionalidades
            // 
            this.lbFuncionalidades.AutoSize = true;
            this.lbFuncionalidades.Location = new System.Drawing.Point(6, 52);
            this.lbFuncionalidades.Name = "lbFuncionalidades";
            this.lbFuncionalidades.Size = new System.Drawing.Size(84, 13);
            this.lbFuncionalidades.TabIndex = 3;
            this.lbFuncionalidades.Text = "Funcionalidades";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(114, 20);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(276, 20);
            this.tbNombre.TabIndex = 2;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(64, 23);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 1;
            this.lbNombre.Text = "Nombre";
            // 
            // dgvFuncionalidades
            // 
            this.dgvFuncionalidades.AllowUserToAddRows = false;
            this.dgvFuncionalidades.AllowUserToDeleteRows = false;
            this.dgvFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuncionalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Seleccionado,
            this.Nombre});
            this.dgvFuncionalidades.Location = new System.Drawing.Point(6, 68);
            this.dgvFuncionalidades.Name = "dgvFuncionalidades";
            this.dgvFuncionalidades.Size = new System.Drawing.Size(384, 415);
            this.dgvFuncionalidades.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(344, 531);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 400;
            // 
            // Seleccionado
            // 
            this.Seleccionado.HeaderText = "Seleccionado";
            this.Seleccionado.Name = "Seleccionado";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 200;
            // 
            // FrmActualizarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 561);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.GVRol);
            this.Name = "FrmActualizarRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmActualizarRol";
            this.Load += new System.EventHandler(this.FrmActualizarRol_Load);
            this.GVRol.ResumeLayout(false);
            this.GVRol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionalidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GVRol;
        private System.Windows.Forms.DataGridView dgvFuncionalidades;
        private System.Windows.Forms.CheckBox cbActivo;
        private System.Windows.Forms.Label lbFuncionalidades;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}