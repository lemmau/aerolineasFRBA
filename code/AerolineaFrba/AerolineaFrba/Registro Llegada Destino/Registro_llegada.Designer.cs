namespace AerolineaFrba.Registro_Llegada_Destino
{
    partial class Registro_llegada
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.h_llegada = new System.Windows.Forms.DateTimePicker();
            this.f_llegada = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMatricula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbCiudadDestino);
            this.panel1.Controls.Add(this.cbCiudadOrigen);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.h_llegada);
            this.panel1.Controls.Add(this.f_llegada);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbMatricula);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 299);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbCiudadDestino
            // 
            this.cbCiudadDestino.FormattingEnabled = true;
            this.cbCiudadDestino.Location = new System.Drawing.Point(134, 138);
            this.cbCiudadDestino.Name = "cbCiudadDestino";
            this.cbCiudadDestino.Size = new System.Drawing.Size(121, 21);
            this.cbCiudadDestino.TabIndex = 8;
            // 
            // cbCiudadOrigen
            // 
            this.cbCiudadOrigen.FormattingEnabled = true;
            this.cbCiudadOrigen.Location = new System.Drawing.Point(131, 102);
            this.cbCiudadOrigen.Name = "cbCiudadOrigen";
            this.cbCiudadOrigen.Size = new System.Drawing.Size(121, 21);
            this.cbCiudadOrigen.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ciudad Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ciudad Origen";
            // 
            // h_llegada
            // 
            this.h_llegada.Location = new System.Drawing.Point(350, 68);
            this.h_llegada.Name = "h_llegada";
            this.h_llegada.Size = new System.Drawing.Size(121, 20);
            this.h_llegada.TabIndex = 4;
            // 
            // f_llegada
            // 
            this.f_llegada.Location = new System.Drawing.Point(131, 68);
            this.f_llegada.Name = "f_llegada";
            this.f_llegada.Size = new System.Drawing.Size(200, 20);
            this.f_llegada.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de Llegada";
            // 
            // lbMatricula
            // 
            this.lbMatricula.Location = new System.Drawing.Point(131, 28);
            this.lbMatricula.Name = "lbMatricula";
            this.lbMatricula.Size = new System.Drawing.Size(108, 20);
            this.lbMatricula.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matricula";
            // 
            // Registro_llegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(606, 741);
            this.Controls.Add(this.panel1);
            this.Name = "Registro_llegada";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbCiudadDestino;
        private System.Windows.Forms.ComboBox cbCiudadOrigen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker h_llegada;
        private System.Windows.Forms.DateTimePicker f_llegada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lbMatricula;
        private System.Windows.Forms.Label label1;
    }
}