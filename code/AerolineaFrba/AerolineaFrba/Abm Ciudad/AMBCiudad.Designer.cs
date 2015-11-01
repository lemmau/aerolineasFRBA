namespace AerolineaFrba.Abm_Ciudad
{
    partial class AbmCiudad
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEliminarCiudad = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAltaCiudad = new System.Windows.Forms.Button();
            this.txtAltaCiudad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVCiudad = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCiudad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Controls.Add(this.btnEliminarCiudad);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(313, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 106);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Baja de Ciudad";
            // 
            // btnEliminarCiudad
            // 
            this.btnEliminarCiudad.Location = new System.Drawing.Point(243, 43);
            this.btnEliminarCiudad.Name = "btnEliminarCiudad";
            this.btnEliminarCiudad.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCiudad.TabIndex = 2;
            this.btnEliminarCiudad.Text = "Eliminar";
            this.btnEliminarCiudad.UseVisualStyleBackColor = true;
            this.btnEliminarCiudad.Click += new System.EventHandler(this.btnEliminarCiudad_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Seleccione la ciudad a Eliminar";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.btnAltaCiudad);
            this.groupBox1.Controls.Add(this.txtAltaCiudad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(313, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 139);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alta de Ciudad";
            // 
            // btnAltaCiudad
            // 
            this.btnAltaCiudad.Location = new System.Drawing.Point(243, 90);
            this.btnAltaCiudad.Name = "btnAltaCiudad";
            this.btnAltaCiudad.Size = new System.Drawing.Size(75, 23);
            this.btnAltaCiudad.TabIndex = 2;
            this.btnAltaCiudad.Text = "Guardar";
            this.btnAltaCiudad.UseVisualStyleBackColor = true;
            this.btnAltaCiudad.Click += new System.EventHandler(this.btnAltaCiudad_Click);
            // 
            // txtAltaCiudad
            // 
            this.txtAltaCiudad.Location = new System.Drawing.Point(158, 44);
            this.txtAltaCiudad.Name = "txtAltaCiudad";
            this.txtAltaCiudad.Size = new System.Drawing.Size(218, 20);
            this.txtAltaCiudad.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese nombre ciudad:";
            // 
            // DGVCiudad
            // 
            this.DGVCiudad.AllowUserToAddRows = false;
            this.DGVCiudad.AllowUserToDeleteRows = false;
            this.DGVCiudad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCiudad.Location = new System.Drawing.Point(12, 12);
            this.DGVCiudad.Name = "DGVCiudad";
            this.DGVCiudad.ReadOnly = true;
            this.DGVCiudad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCiudad.Size = new System.Drawing.Size(263, 575);
            this.DGVCiudad.TabIndex = 4;
            // 
            // AbmCiudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 600);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGVCiudad);
            this.Name = "AbmCiudad";
            this.Text = "AMBCiudad";
            this.Load += new System.EventHandler(this.AbmCiudad_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCiudad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEliminarCiudad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAltaCiudad;
        private System.Windows.Forms.TextBox txtAltaCiudad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVCiudad;
    }
}