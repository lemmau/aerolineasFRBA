namespace AerolineaFrba.Generacion_Viaje
{
    partial class Generar_Viaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generar_Viaje));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaSalida1 = new System.Windows.Forms.DateTimePicker();
            this.fechaLlegada1 = new System.Windows.Forms.DateTimePicker();
            this.fechaEst1 = new System.Windows.Forms.DateTimePicker();
            this.fechaSalida = new System.Windows.Forms.DateTimePicker();
            this.fechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.fechaEst = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.aeronaves = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rutas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.id_ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad_origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad_destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_servicio_ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selec1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoServicio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selec = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aeronaves)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rutas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una Fecha de Salida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de Salida";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de llegada";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Llegada Estimado";
            this.label4.Visible = false;
            // 
            // fechaSalida1
            // 
            this.fechaSalida1.Location = new System.Drawing.Point(136, 53);
            this.fechaSalida1.Name = "fechaSalida1";
            this.fechaSalida1.Size = new System.Drawing.Size(200, 20);
            this.fechaSalida1.TabIndex = 4;
            this.fechaSalida1.Value = new System.DateTime(1999, 1, 1, 6, 4, 0, 0);
            this.fechaSalida1.ValueChanged += new System.EventHandler(this.fechaSalida1_ValueChanged);
            // 
            // fechaLlegada1
            // 
            this.fechaLlegada1.Location = new System.Drawing.Point(136, 78);
            this.fechaLlegada1.Name = "fechaLlegada1";
            this.fechaLlegada1.Size = new System.Drawing.Size(200, 20);
            this.fechaLlegada1.TabIndex = 5;
            this.fechaLlegada1.Visible = false;
            this.fechaLlegada1.ValueChanged += new System.EventHandler(this.fechaLlegada1_ValueChanged);
            // 
            // fechaEst1
            // 
            this.fechaEst1.Location = new System.Drawing.Point(175, 105);
            this.fechaEst1.Name = "fechaEst1";
            this.fechaEst1.Size = new System.Drawing.Size(200, 20);
            this.fechaEst1.TabIndex = 6;
            this.fechaEst1.Visible = false;
            this.fechaEst1.ValueChanged += new System.EventHandler(this.fechaEst1_ValueChanged);
            // 
            // fechaSalida
            // 
            this.fechaSalida.Location = new System.Drawing.Point(381, 53);
            this.fechaSalida.Name = "fechaSalida";
            this.fechaSalida.Size = new System.Drawing.Size(117, 20);
            this.fechaSalida.TabIndex = 7;
            // 
            // fechaLlegada
            // 
            this.fechaLlegada.Location = new System.Drawing.Point(381, 78);
            this.fechaLlegada.Name = "fechaLlegada";
            this.fechaLlegada.Size = new System.Drawing.Size(117, 20);
            this.fechaLlegada.TabIndex = 8;
            this.fechaLlegada.Visible = false;
            // 
            // fechaEst
            // 
            this.fechaEst.Location = new System.Drawing.Point(381, 105);
            this.fechaEst.Name = "fechaEst";
            this.fechaEst.Size = new System.Drawing.Size(117, 20);
            this.fechaEst.TabIndex = 9;
            this.fechaEst.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.aeronaves);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(29, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 191);
            this.panel1.TabIndex = 10;
            // 
            // aeronaves
            // 
            this.aeronaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aeronaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.modelo,
            this.matricula,
            this.fabricante,
            this.tipoServicio1,
            this.selec});
            this.aeronaves.Location = new System.Drawing.Point(7, 33);
            this.aeronaves.Name = "aeronaves";
            this.aeronaves.RowHeadersVisible = false;
            this.aeronaves.Size = new System.Drawing.Size(590, 150);
            this.aeronaves.TabIndex = 1;
            this.aeronaves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.aeronaves_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Seleccione una Aeronave";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rutas);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(29, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 248);
            this.panel2.TabIndex = 11;
            // 
            // rutas
            // 
            this.rutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rutas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_ruta,
            this.codigo_ruta,
            this.ciudad_origen,
            this.ciudad_destino,
            this.tipo_servicio_ruta,
            this.selec1});
            this.rutas.Location = new System.Drawing.Point(7, 52);
            this.rutas.Name = "rutas";
            this.rutas.RowHeadersVisible = false;
            this.rutas.Size = new System.Drawing.Size(602, 193);
            this.rutas.TabIndex = 1;
            this.rutas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rutas_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Seleccione una Ruta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 655);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 655);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 44);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // id_ruta
            // 
            this.id_ruta.HeaderText = "ID";
            this.id_ruta.Name = "id_ruta";
            this.id_ruta.ReadOnly = true;
            // 
            // codigo_ruta
            // 
            this.codigo_ruta.HeaderText = "Codigo";
            this.codigo_ruta.Name = "codigo_ruta";
            // 
            // ciudad_origen
            // 
            this.ciudad_origen.HeaderText = "Ciudad Origen";
            this.ciudad_origen.Name = "ciudad_origen";
            this.ciudad_origen.ReadOnly = true;
            // 
            // ciudad_destino
            // 
            this.ciudad_destino.HeaderText = "Ciudad Destino";
            this.ciudad_destino.Name = "ciudad_destino";
            this.ciudad_destino.ReadOnly = true;
            // 
            // tipo_servicio_ruta
            // 
            this.tipo_servicio_ruta.HeaderText = "Tipo Servicio";
            this.tipo_servicio_ruta.Name = "tipo_servicio_ruta";
            this.tipo_servicio_ruta.ReadOnly = true;
            // 
            // selec1
            // 
            this.selec1.HeaderText = "Seleccionar";
            this.selec1.Image = ((System.Drawing.Image)(resources.GetObject("selec1.Image")));
            this.selec1.Name = "selec1";
            this.selec1.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            // 
            // matricula
            // 
            this.matricula.HeaderText = "Matricula";
            this.matricula.Name = "matricula";
            // 
            // fabricante
            // 
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.Name = "fabricante";
            this.fabricante.ReadOnly = true;
            // 
            // tipoServicio1
            // 
            this.tipoServicio1.HeaderText = "Tipo de Servicio";
            this.tipoServicio1.Name = "tipoServicio1";
            // 
            // selec
            // 
            this.selec.HeaderText = "Seleccionar";
            this.selec.Image = ((System.Drawing.Image)(resources.GetObject("selec.Image")));
            this.selec.Name = "selec";
            // 
            // Generar_Viaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 733);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fechaEst);
            this.Controls.Add(this.fechaLlegada);
            this.Controls.Add(this.fechaSalida);
            this.Controls.Add(this.fechaEst1);
            this.Controls.Add(this.fechaLlegada1);
            this.Controls.Add(this.fechaSalida1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Generar_Viaje";
            this.Text = "Generar_Viaje";
            this.Load += new System.EventHandler(this.Generar_Viaje_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aeronaves)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rutas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaSalida1;
        private System.Windows.Forms.DateTimePicker fechaLlegada1;
        private System.Windows.Forms.DateTimePicker fechaEst1;
        private System.Windows.Forms.DateTimePicker fechaSalida;
        private System.Windows.Forms.DateTimePicker fechaLlegada;
        private System.Windows.Forms.DateTimePicker fechaEst;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView aeronaves;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView rutas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad_origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad_destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_servicio_ruta;
        private System.Windows.Forms.DataGridViewImageColumn selec1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoServicio1;
        private System.Windows.Forms.DataGridViewImageColumn selec;
    }
}