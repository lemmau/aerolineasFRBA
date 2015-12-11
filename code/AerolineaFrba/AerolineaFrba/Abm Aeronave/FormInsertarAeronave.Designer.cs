namespace AerolineaFrba.Abm_Aeronave
{
    partial class FormInsertarAeronave
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbCamposDeRuta = new System.Windows.Forms.GroupBox();
            this.cbTipoDeServicio = new System.Windows.Forms.ComboBox();
            this.tbButacasVentanilla = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbButacasPasillo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKG = new System.Windows.Forms.TextBox();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.tbModelo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbFechaActual = new System.Windows.Forms.Label();
            this.lbPrecioBaseKG = new System.Windows.Forms.Label();
            this.tbFabricante = new System.Windows.Forms.TextBox();
            this.lbPrecioBasePasaje = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCamposDeRuta.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(564, 355);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbCamposDeRuta
            // 
            this.gbCamposDeRuta.Controls.Add(this.cbTipoDeServicio);
            this.gbCamposDeRuta.Controls.Add(this.tbButacasVentanilla);
            this.gbCamposDeRuta.Controls.Add(this.label6);
            this.gbCamposDeRuta.Controls.Add(this.tbButacasPasillo);
            this.gbCamposDeRuta.Controls.Add(this.label5);
            this.gbCamposDeRuta.Controls.Add(this.tbKG);
            this.gbCamposDeRuta.Controls.Add(this.tbMatricula);
            this.gbCamposDeRuta.Controls.Add(this.tbModelo);
            this.gbCamposDeRuta.Controls.Add(this.label4);
            this.gbCamposDeRuta.Controls.Add(this.lbFechaActual);
            this.gbCamposDeRuta.Controls.Add(this.lbPrecioBaseKG);
            this.gbCamposDeRuta.Controls.Add(this.tbFabricante);
            this.gbCamposDeRuta.Controls.Add(this.lbPrecioBasePasaje);
            this.gbCamposDeRuta.Controls.Add(this.label3);
            this.gbCamposDeRuta.Controls.Add(this.label2);
            this.gbCamposDeRuta.Controls.Add(this.label1);
            this.gbCamposDeRuta.Location = new System.Drawing.Point(24, 22);
            this.gbCamposDeRuta.Name = "gbCamposDeRuta";
            this.gbCamposDeRuta.Size = new System.Drawing.Size(615, 313);
            this.gbCamposDeRuta.TabIndex = 12;
            this.gbCamposDeRuta.TabStop = false;
            this.gbCamposDeRuta.Text = "Campos de Aeronave";
            // 
            // cbTipoDeServicio
            // 
            this.cbTipoDeServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeServicio.FormattingEnabled = true;
            this.cbTipoDeServicio.Location = new System.Drawing.Point(257, 242);
            this.cbTipoDeServicio.Name = "cbTipoDeServicio";
            this.cbTipoDeServicio.Size = new System.Drawing.Size(170, 21);
            this.cbTipoDeServicio.TabIndex = 27;
            // 
            // tbButacasVentanilla
            // 
            this.tbButacasVentanilla.Location = new System.Drawing.Point(446, 179);
            this.tbButacasVentanilla.Name = "tbButacasVentanilla";
            this.tbButacasVentanilla.Size = new System.Drawing.Size(105, 20);
            this.tbButacasVentanilla.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Cant Butacas Ventanilla";
            // 
            // tbButacasPasillo
            // 
            this.tbButacasPasillo.Location = new System.Drawing.Point(446, 140);
            this.tbButacasPasillo.Name = "tbButacasPasillo";
            this.tbButacasPasillo.Size = new System.Drawing.Size(105, 20);
            this.tbButacasPasillo.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Cant Butacas Pasillo";
            // 
            // tbKG
            // 
            this.tbKG.Location = new System.Drawing.Point(446, 100);
            this.tbKG.Name = "tbKG";
            this.tbKG.Size = new System.Drawing.Size(105, 20);
            this.tbKG.TabIndex = 22;
            // 
            // tbMatricula
            // 
            this.tbMatricula.Location = new System.Drawing.Point(134, 179);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(105, 20);
            this.tbMatricula.TabIndex = 21;
            // 
            // tbModelo
            // 
            this.tbModelo.Location = new System.Drawing.Point(134, 140);
            this.tbModelo.Name = "tbModelo";
            this.tbModelo.Size = new System.Drawing.Size(105, 20);
            this.tbModelo.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fecha de Alta:";
            // 
            // lbFechaActual
            // 
            this.lbFechaActual.AutoSize = true;
            this.lbFechaActual.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbFechaActual.Location = new System.Drawing.Point(315, 44);
            this.lbFechaActual.Name = "lbFechaActual";
            this.lbFechaActual.Size = new System.Drawing.Size(69, 13);
            this.lbFechaActual.TabIndex = 19;
            this.lbFechaActual.Text = "dd/mm/aaaa";
            // 
            // lbPrecioBaseKG
            // 
            this.lbPrecioBaseKG.AutoSize = true;
            this.lbPrecioBaseKG.Location = new System.Drawing.Point(335, 103);
            this.lbPrecioBaseKG.Name = "lbPrecioBaseKG";
            this.lbPrecioBaseKG.Size = new System.Drawing.Size(82, 13);
            this.lbPrecioBaseKG.TabIndex = 10;
            this.lbPrecioBaseKG.Text = "Cantidad de KG";
            // 
            // tbFabricante
            // 
            this.tbFabricante.Location = new System.Drawing.Point(134, 100);
            this.tbFabricante.Name = "tbFabricante";
            this.tbFabricante.Size = new System.Drawing.Size(105, 20);
            this.tbFabricante.TabIndex = 7;
            // 
            // lbPrecioBasePasaje
            // 
            this.lbPrecioBasePasaje.AutoSize = true;
            this.lbPrecioBasePasaje.Location = new System.Drawing.Point(61, 143);
            this.lbPrecioBasePasaje.Name = "lbPrecioBasePasaje";
            this.lbPrecioBasePasaje.Size = new System.Drawing.Size(42, 13);
            this.lbPrecioBasePasaje.TabIndex = 6;
            this.lbPrecioBasePasaje.Text = "Modelo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fabricante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrícula";
            // 
            // FormInsertarAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 395);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbCamposDeRuta);
            this.Name = "FormInsertarAeronave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Aeronave";
            this.Load += new System.EventHandler(this.FormInsertarAeronave_Load);
            this.gbCamposDeRuta.ResumeLayout(false);
            this.gbCamposDeRuta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbCamposDeRuta;
        private System.Windows.Forms.TextBox tbButacasVentanilla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbButacasPasillo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbKG;
        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.TextBox tbModelo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbFechaActual;
        private System.Windows.Forms.Label lbPrecioBaseKG;
        private System.Windows.Forms.TextBox tbFabricante;
        private System.Windows.Forms.Label lbPrecioBasePasaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipoDeServicio;
    }
}