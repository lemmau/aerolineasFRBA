namespace AerolineaFrba.Canje_Millas
{
    partial class CanjeMillas
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
            this.lbMillasAcumuladas = new System.Windows.Forms.Label();
            this.lbMillas = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvCanjes = new System.Windows.Forms.DataGridView();
            this.idDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.millasNecesariasDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanjes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMillasAcumuladas);
            this.groupBox1.Controls.Add(this.lbMillas);
            this.groupBox1.Controls.Add(this.tbDNI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Location = new System.Drawing.Point(37, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 54);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // lbMillasAcumuladas
            // 
            this.lbMillasAcumuladas.AutoSize = true;
            this.lbMillasAcumuladas.ForeColor = System.Drawing.Color.Black;
            this.lbMillasAcumuladas.Location = new System.Drawing.Point(412, 25);
            this.lbMillasAcumuladas.Name = "lbMillasAcumuladas";
            this.lbMillasAcumuladas.Size = new System.Drawing.Size(10, 13);
            this.lbMillasAcumuladas.TabIndex = 69;
            this.lbMillasAcumuladas.Text = "-";
            this.lbMillasAcumuladas.Visible = false;
            // 
            // lbMillas
            // 
            this.lbMillas.AutoSize = true;
            this.lbMillas.ForeColor = System.Drawing.Color.Black;
            this.lbMillas.Location = new System.Drawing.Point(301, 25);
            this.lbMillas.Name = "lbMillas";
            this.lbMillas.Size = new System.Drawing.Size(97, 13);
            this.lbMillas.TabIndex = 68;
            this.lbMillas.Text = "Millas Acumuladas:";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(107, 22);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(75, 20);
            this.tbDNI.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "DNI:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(204, 20);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvCanjes
            // 
            this.dgvCanjes.AllowUserToAddRows = false;
            this.dgvCanjes.AllowUserToDeleteRows = false;
            this.dgvCanjes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanjes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDGV,
            this.productoDGV,
            this.millasNecesariasDGV});
            this.dgvCanjes.Location = new System.Drawing.Point(97, 156);
            this.dgvCanjes.Name = "dgvCanjes";
            this.dgvCanjes.ReadOnly = true;
            this.dgvCanjes.Size = new System.Drawing.Size(363, 230);
            this.dgvCanjes.TabIndex = 18;
            // 
            // idDGV
            // 
            this.idDGV.HeaderText = "Id";
            this.idDGV.Name = "idDGV";
            this.idDGV.ReadOnly = true;
            this.idDGV.Visible = false;
            // 
            // productoDGV
            // 
            this.productoDGV.HeaderText = "Producto";
            this.productoDGV.Name = "productoDGV";
            this.productoDGV.ReadOnly = true;
            this.productoDGV.Width = 200;
            // 
            // millasNecesariasDGV
            // 
            this.millasNecesariasDGV.HeaderText = "Millas Necesarias";
            this.millasNecesariasDGV.Name = "millasNecesariasDGV";
            this.millasNecesariasDGV.ReadOnly = true;
            this.millasNecesariasDGV.Width = 120;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(261, 124);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(10, 13);
            this.lbNombre.TabIndex = 20;
            this.lbNombre.Text = "-";
            this.lbNombre.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Canjes posibles para el Sr./Sra.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ingrese la cantidad del producto seleccionado:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(342, 421);
            this.nudCantidad.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(47, 20);
            this.nudCantidad.TabIndex = 23;
            this.nudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(240, 482);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 24;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // CanjeMillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 528);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCanjes);
            this.Controls.Add(this.groupBox1);
            this.Name = "CanjeMillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canje de Millas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanjes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMillasAcumuladas;
        private System.Windows.Forms.Label lbMillas;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvCanjes;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn millasNecesariasDGV;
    }
}