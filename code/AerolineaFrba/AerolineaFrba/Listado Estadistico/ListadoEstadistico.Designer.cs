namespace AerolineaFrba.Listado_Estadistico
{
    partial class ListadoEstadistico
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
            this.lbSemestre = new System.Windows.Forms.Label();
            this.lbAnio = new System.Windows.Forms.Label();
            this.cbSemestre = new System.Windows.Forms.ComboBox();
            this.tbAnio = new System.Windows.Forms.TextBox();
            this.gbListados = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.btListar = new System.Windows.Forms.Button();
            this.gbListados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSemestre
            // 
            this.lbSemestre.AutoSize = true;
            this.lbSemestre.Location = new System.Drawing.Point(12, 40);
            this.lbSemestre.Name = "lbSemestre";
            this.lbSemestre.Size = new System.Drawing.Size(51, 13);
            this.lbSemestre.TabIndex = 0;
            this.lbSemestre.Text = "Semestre";
            // 
            // lbAnio
            // 
            this.lbAnio.AutoSize = true;
            this.lbAnio.Location = new System.Drawing.Point(12, 9);
            this.lbAnio.Name = "lbAnio";
            this.lbAnio.Size = new System.Drawing.Size(26, 13);
            this.lbAnio.TabIndex = 1;
            this.lbAnio.Text = "Año";
            // 
            // cbSemestre
            // 
            this.cbSemestre.FormattingEnabled = true;
            this.cbSemestre.Location = new System.Drawing.Point(69, 37);
            this.cbSemestre.Name = "cbSemestre";
            this.cbSemestre.Size = new System.Drawing.Size(46, 21);
            this.cbSemestre.TabIndex = 2;
            // 
            // tbAnio
            // 
            this.tbAnio.Location = new System.Drawing.Point(69, 6);
            this.tbAnio.Name = "tbAnio";
            this.tbAnio.Size = new System.Drawing.Size(46, 20);
            this.tbAnio.TabIndex = 3;
            // 
            // gbListados
            // 
            this.gbListados.Controls.Add(this.radioButton5);
            this.gbListados.Controls.Add(this.radioButton4);
            this.gbListados.Controls.Add(this.radioButton3);
            this.gbListados.Controls.Add(this.radioButton2);
            this.gbListados.Controls.Add(this.radioButton1);
            this.gbListados.Location = new System.Drawing.Point(141, 9);
            this.gbListados.Name = "gbListados";
            this.gbListados.Size = new System.Drawing.Size(530, 141);
            this.gbListados.TabIndex = 4;
            this.gbListados.TabStop = false;
            this.gbListados.Text = "Listados";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(20, 111);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(292, 17);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Aeronaves con mayor cantidad de días fuera de servicio";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(20, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(206, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Destinos con más pasajes cancelados";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(20, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(250, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Clientes con más puntos acumulados a la fecha";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(196, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Destinos con aeronaves más vacias";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(203, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Destinos con más pasajes comprados";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // dgvListado
            // 
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(25, 183);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.Size = new System.Drawing.Size(835, 216);
            this.dgvListado.TabIndex = 5;
            // 
            // btListar
            // 
            this.btListar.Location = new System.Drawing.Point(596, 154);
            this.btListar.Name = "btListar";
            this.btListar.Size = new System.Drawing.Size(75, 23);
            this.btListar.TabIndex = 6;
            this.btListar.Text = "Listar";
            this.btListar.UseVisualStyleBackColor = true;
            this.btListar.Click += new System.EventHandler(this.btListar_Click_1);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 411);
            this.Controls.Add(this.btListar);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.gbListados);
            this.Controls.Add(this.tbAnio);
            this.Controls.Add(this.cbSemestre);
            this.Controls.Add(this.lbAnio);
            this.Controls.Add(this.lbSemestre);
            this.Name = "ListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados Estadísticos";
            this.gbListados.ResumeLayout(false);
            this.gbListados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSemestre;
        private System.Windows.Forms.Label lbAnio;
        private System.Windows.Forms.ComboBox cbSemestre;
        private System.Windows.Forms.TextBox tbAnio;
        private System.Windows.Forms.GroupBox gbListados;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Button btListar;
    }
}