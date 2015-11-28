namespace AerolineaFrba.Consulta_Millas
{
    partial class ConsultaMillas
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
            this.lbNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMillasAcumuladas = new System.Windows.Forms.Label();
            this.lbMillas = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvMillas = new System.Windows.Forms.DataGridView();
            this.millasDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMillas)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(212, 116);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(10, 13);
            this.lbNombre.TabIndex = 18;
            this.lbNombre.Text = "-";
            this.lbNombre.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Resumen de millas para el Sr./Sra.:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMillasAcumuladas);
            this.groupBox1.Controls.Add(this.lbMillas);
            this.groupBox1.Controls.Add(this.tbDNI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Location = new System.Drawing.Point(110, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 54);
            this.groupBox1.TabIndex = 16;
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
            // dgvMillas
            // 
            this.dgvMillas.AllowUserToAddRows = false;
            this.dgvMillas.AllowUserToDeleteRows = false;
            this.dgvMillas.ColumnHeadersHeight = 20;
            this.dgvMillas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.millasDGV,
            this.fechaDGV,
            this.detalleDGV});
            this.dgvMillas.Location = new System.Drawing.Point(35, 148);
            this.dgvMillas.MultiSelect = false;
            this.dgvMillas.Name = "dgvMillas";
            this.dgvMillas.ReadOnly = true;
            this.dgvMillas.RowHeadersWidth = 30;
            this.dgvMillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMillas.Size = new System.Drawing.Size(645, 259);
            this.dgvMillas.TabIndex = 15;
            // 
            // millasDGV
            // 
            this.millasDGV.HeaderText = "Millas";
            this.millasDGV.Name = "millasDGV";
            this.millasDGV.ReadOnly = true;
            this.millasDGV.Width = 80;
            // 
            // fechaDGV
            // 
            this.fechaDGV.HeaderText = "Fecha";
            this.fechaDGV.Name = "fechaDGV";
            this.fechaDGV.ReadOnly = true;
            this.fechaDGV.Width = 160;
            // 
            // detalleDGV
            // 
            this.detalleDGV.HeaderText = "Detalle";
            this.detalleDGV.Name = "detalleDGV";
            this.detalleDGV.ReadOnly = true;
            this.detalleDGV.Width = 355;
            // 
            // ConsultaMillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 462);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMillas);
            this.Name = "ConsultaMillas";
            this.Text = "Consulta de Millas";
            this.Load += new System.EventHandler(this.ConsultaMillas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMillas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMillasAcumuladas;
        private System.Windows.Forms.Label lbMillas;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvMillas;
        private System.Windows.Forms.DataGridViewTextBoxColumn millasDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalleDGV;
    }
}