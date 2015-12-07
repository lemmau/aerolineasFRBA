namespace AerolineaFrba.Abm_Aeronave
{
    partial class DecisionEliminar
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelarVuelos = new System.Windows.Forms.Button();
            this.btnReemplazarAeronave = new System.Windows.Forms.Button();
            this.btnCancelarBaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "La aeronave que desea dar de baja posee vuelos programados, como desea proseguir?" +
    "";
            // 
            // btnCancelarVuelos
            // 
            this.btnCancelarVuelos.Location = new System.Drawing.Point(72, 83);
            this.btnCancelarVuelos.Name = "btnCancelarVuelos";
            this.btnCancelarVuelos.Size = new System.Drawing.Size(83, 40);
            this.btnCancelarVuelos.TabIndex = 1;
            this.btnCancelarVuelos.Text = "Cancelar Vuelos";
            this.btnCancelarVuelos.UseVisualStyleBackColor = true;
            this.btnCancelarVuelos.Click += new System.EventHandler(this.btnCancelarVuelos_Click);
            // 
            // btnReemplazarAeronave
            // 
            this.btnReemplazarAeronave.Location = new System.Drawing.Point(198, 83);
            this.btnReemplazarAeronave.Name = "btnReemplazarAeronave";
            this.btnReemplazarAeronave.Size = new System.Drawing.Size(83, 40);
            this.btnReemplazarAeronave.TabIndex = 1;
            this.btnReemplazarAeronave.Text = "Reemplazar Aeronave";
            this.btnReemplazarAeronave.UseVisualStyleBackColor = true;
            this.btnReemplazarAeronave.Click += new System.EventHandler(this.btnReemplazarAeronave_Click);
            // 
            // btnCancelarBaja
            // 
            this.btnCancelarBaja.Location = new System.Drawing.Point(322, 83);
            this.btnCancelarBaja.Name = "btnCancelarBaja";
            this.btnCancelarBaja.Size = new System.Drawing.Size(83, 40);
            this.btnCancelarBaja.TabIndex = 1;
            this.btnCancelarBaja.Text = "Cancelar Baja";
            this.btnCancelarBaja.UseVisualStyleBackColor = true;
            this.btnCancelarBaja.Click += new System.EventHandler(this.btnCancelarBaja_Click);
            // 
            // DecisionEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 161);
            this.Controls.Add(this.btnCancelarBaja);
            this.Controls.Add(this.btnReemplazarAeronave);
            this.Controls.Add(this.btnCancelarVuelos);
            this.Controls.Add(this.label1);
            this.Name = "DecisionEliminar";
            this.Text = "Aviso Importante!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelarVuelos;
        private System.Windows.Forms.Button btnReemplazarAeronave;
        private System.Windows.Forms.Button btnCancelarBaja;
    }
}