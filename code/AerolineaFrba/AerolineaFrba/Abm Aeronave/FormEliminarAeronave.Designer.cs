namespace AerolineaFrba.Abm_Aeronave
{
    partial class FormEliminarAeronave
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
            this.fechaReincorporacion = new System.Windows.Forms.DateTimePicker();
            this.label_fs_2 = new System.Windows.Forms.Label();
            this.rbFueraServicio = new System.Windows.Forms.RadioButton();
            this.rbFinVidaUtil = new System.Windows.Forms.RadioButton();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fechaReincorporacion);
            this.groupBox1.Controls.Add(this.label_fs_2);
            this.groupBox1.Controls.Add(this.rbFueraServicio);
            this.groupBox1.Controls.Add(this.rbFinVidaUtil);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 199);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de Baja";
            // 
            // fechaReincorporacion
            // 
            this.fechaReincorporacion.Location = new System.Drawing.Point(304, 77);
            this.fechaReincorporacion.Name = "fechaReincorporacion";
            this.fechaReincorporacion.Size = new System.Drawing.Size(206, 20);
            this.fechaReincorporacion.TabIndex = 68;
            // 
            // label_fs_2
            // 
            this.label_fs_2.AutoSize = true;
            this.label_fs_2.Location = new System.Drawing.Point(151, 80);
            this.label_fs_2.Name = "label_fs_2";
            this.label_fs_2.Size = new System.Drawing.Size(136, 13);
            this.label_fs_2.TabIndex = 67;
            this.label_fs_2.Text = "Fecha de Reincorporación:";
            // 
            // rbFueraServicio
            // 
            this.rbFueraServicio.AutoSize = true;
            this.rbFueraServicio.Checked = true;
            this.rbFueraServicio.Location = new System.Drawing.Point(12, 78);
            this.rbFueraServicio.Name = "rbFueraServicio";
            this.rbFueraServicio.Size = new System.Drawing.Size(108, 17);
            this.rbFueraServicio.TabIndex = 18;
            this.rbFueraServicio.TabStop = true;
            this.rbFueraServicio.Text = "Fuera de Servicio";
            this.rbFueraServicio.UseVisualStyleBackColor = true;
            this.rbFueraServicio.CheckedChanged += new System.EventHandler(this.rbFueraServicio_CheckedChanged);
            // 
            // rbFinVidaUtil
            // 
            this.rbFinVidaUtil.AutoSize = true;
            this.rbFinVidaUtil.Location = new System.Drawing.Point(12, 125);
            this.rbFinVidaUtil.Name = "rbFinVidaUtil";
            this.rbFinVidaUtil.Size = new System.Drawing.Size(81, 17);
            this.rbFinVidaUtil.TabIndex = 17;
            this.rbFinVidaUtil.Text = "Fin Vida Util";
            this.rbFinVidaUtil.UseVisualStyleBackColor = true;
            this.rbFinVidaUtil.CheckedChanged += new System.EventHandler(this.rbFinVidaUtil_CheckedChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(456, 243);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 23);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Confirmar Baja";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FormEliminarAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 278);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEliminar);
            this.Name = "FormEliminarAeronave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEliminarAeronave";
            this.Load += new System.EventHandler(this.FormEliminarAeronave_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker fechaReincorporacion;
        private System.Windows.Forms.Label label_fs_2;
        private System.Windows.Forms.RadioButton rbFueraServicio;
        private System.Windows.Forms.RadioButton rbFinVidaUtil;
        private System.Windows.Forms.Button btnEliminar;
    }
}