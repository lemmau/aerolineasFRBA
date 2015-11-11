namespace AerolineaFrba.Abm_Ruta
{
    partial class FrmActualizarRuta
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
            this.btActualizar = new System.Windows.Forms.Button();
            this.gbCamposDeRuta = new System.Windows.Forms.GroupBox();
            this.lbPrecioBaseKG = new System.Windows.Forms.Label();
            this.tbPrecioBaseKG = new System.Windows.Forms.TextBox();
            this.cbActiva = new System.Windows.Forms.CheckBox();
            this.tbPrecioBasePasaje = new System.Windows.Forms.TextBox();
            this.lbPrecioBasePasaje = new System.Windows.Forms.Label();
            this.cbTipoDeServicio = new System.Windows.Forms.ComboBox();
            this.cbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCamposDeRuta.SuspendLayout();
            this.SuspendLayout();
            // 
            // btActualizar
            // 
            this.btActualizar.Location = new System.Drawing.Point(497, 295);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(75, 23);
            this.btActualizar.TabIndex = 11;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // gbCamposDeRuta
            // 
            this.gbCamposDeRuta.Controls.Add(this.lbPrecioBaseKG);
            this.gbCamposDeRuta.Controls.Add(this.tbPrecioBaseKG);
            this.gbCamposDeRuta.Controls.Add(this.cbActiva);
            this.gbCamposDeRuta.Controls.Add(this.tbPrecioBasePasaje);
            this.gbCamposDeRuta.Controls.Add(this.lbPrecioBasePasaje);
            this.gbCamposDeRuta.Controls.Add(this.cbTipoDeServicio);
            this.gbCamposDeRuta.Controls.Add(this.cbCiudadDestino);
            this.gbCamposDeRuta.Controls.Add(this.cbCiudadOrigen);
            this.gbCamposDeRuta.Controls.Add(this.label3);
            this.gbCamposDeRuta.Controls.Add(this.label2);
            this.gbCamposDeRuta.Controls.Add(this.label1);
            this.gbCamposDeRuta.Location = new System.Drawing.Point(12, 12);
            this.gbCamposDeRuta.Name = "gbCamposDeRuta";
            this.gbCamposDeRuta.Size = new System.Drawing.Size(560, 257);
            this.gbCamposDeRuta.TabIndex = 10;
            this.gbCamposDeRuta.TabStop = false;
            this.gbCamposDeRuta.Text = "Campos de Ruta";
            // 
            // lbPrecioBaseKG
            // 
            this.lbPrecioBaseKG.AutoSize = true;
            this.lbPrecioBaseKG.Location = new System.Drawing.Point(351, 118);
            this.lbPrecioBaseKG.Name = "lbPrecioBaseKG";
            this.lbPrecioBaseKG.Size = new System.Drawing.Size(82, 13);
            this.lbPrecioBaseKG.TabIndex = 10;
            this.lbPrecioBaseKG.Text = "Precio Base KG";
            // 
            // tbPrecioBaseKG
            // 
            this.tbPrecioBaseKG.Location = new System.Drawing.Point(451, 113);
            this.tbPrecioBaseKG.Name = "tbPrecioBaseKG";
            this.tbPrecioBaseKG.Size = new System.Drawing.Size(83, 20);
            this.tbPrecioBaseKG.TabIndex = 9;
            // 
            // cbActiva
            // 
            this.cbActiva.AutoSize = true;
            this.cbActiva.Location = new System.Drawing.Point(485, 232);
            this.cbActiva.Name = "cbActiva";
            this.cbActiva.Size = new System.Drawing.Size(56, 17);
            this.cbActiva.TabIndex = 8;
            this.cbActiva.Text = "Activa";
            this.cbActiva.UseVisualStyleBackColor = true;
            // 
            // tbPrecioBasePasaje
            // 
            this.tbPrecioBasePasaje.Location = new System.Drawing.Point(451, 57);
            this.tbPrecioBasePasaje.Name = "tbPrecioBasePasaje";
            this.tbPrecioBasePasaje.Size = new System.Drawing.Size(83, 20);
            this.tbPrecioBasePasaje.TabIndex = 7;
            // 
            // lbPrecioBasePasaje
            // 
            this.lbPrecioBasePasaje.AutoSize = true;
            this.lbPrecioBasePasaje.Location = new System.Drawing.Point(334, 60);
            this.lbPrecioBasePasaje.Name = "lbPrecioBasePasaje";
            this.lbPrecioBasePasaje.Size = new System.Drawing.Size(99, 13);
            this.lbPrecioBasePasaje.TabIndex = 6;
            this.lbPrecioBasePasaje.Text = "Precio Base Pasaje";
            // 
            // cbTipoDeServicio
            // 
            this.cbTipoDeServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeServicio.FormattingEnabled = true;
            this.cbTipoDeServicio.Location = new System.Drawing.Point(263, 175);
            this.cbTipoDeServicio.Name = "cbTipoDeServicio";
            this.cbTipoDeServicio.Size = new System.Drawing.Size(170, 21);
            this.cbTipoDeServicio.TabIndex = 5;
            // 
            // cbCiudadDestino
            // 
            this.cbCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudadDestino.FormattingEnabled = true;
            this.cbCiudadDestino.Location = new System.Drawing.Point(121, 118);
            this.cbCiudadDestino.Name = "cbCiudadDestino";
            this.cbCiudadDestino.Size = new System.Drawing.Size(170, 21);
            this.cbCiudadDestino.TabIndex = 4;
            // 
            // cbCiudadOrigen
            // 
            this.cbCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudadOrigen.FormattingEnabled = true;
            this.cbCiudadOrigen.Location = new System.Drawing.Point(121, 57);
            this.cbCiudadOrigen.Name = "cbCiudadOrigen";
            this.cbCiudadOrigen.Size = new System.Drawing.Size(170, 21);
            this.cbCiudadOrigen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ciudad Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ciudad Origen";
            // 
            // FrmActualizarRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 330);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.gbCamposDeRuta);
            this.Name = "FrmActualizarRuta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Ruta Aerea";
            this.Load += new System.EventHandler(this.FrmActualizarRuta_Load);
            this.gbCamposDeRuta.ResumeLayout(false);
            this.gbCamposDeRuta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.GroupBox gbCamposDeRuta;
        private System.Windows.Forms.Label lbPrecioBaseKG;
        private System.Windows.Forms.TextBox tbPrecioBaseKG;
        private System.Windows.Forms.CheckBox cbActiva;
        private System.Windows.Forms.TextBox tbPrecioBasePasaje;
        private System.Windows.Forms.Label lbPrecioBasePasaje;
        private System.Windows.Forms.ComboBox cbTipoDeServicio;
        private System.Windows.Forms.ComboBox cbCiudadDestino;
        private System.Windows.Forms.ComboBox cbCiudadOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}