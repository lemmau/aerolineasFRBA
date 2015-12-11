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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaEst1 = new System.Windows.Forms.DateTimePicker();
            this.fechaSalida = new System.Windows.Forms.DateTimePicker();
            this.fechaEst = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.cbTipoServicio1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aeronaves = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idServicioA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoServicio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selec = new System.Windows.Forms.DataGridViewImageColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.cbTipoServicio = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rutas = new System.Windows.Forms.DataGridView();
            this.id_ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad_origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad_destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idServicioRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_servicio_ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selec1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fechaSalida1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aeronaves)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rutas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de Salida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Llegada Estimado";
            // 
            // fechaEst1
            // 
            this.fechaEst1.Location = new System.Drawing.Point(171, 63);
            this.fechaEst1.Name = "fechaEst1";
            this.fechaEst1.Size = new System.Drawing.Size(200, 20);
            this.fechaEst1.TabIndex = 6;
            this.fechaEst1.ValueChanged += new System.EventHandler(this.fechaEst1_ValueChanged);
            // 
            // fechaSalida
            // 
            this.fechaSalida.Location = new System.Drawing.Point(381, 26);
            this.fechaSalida.Name = "fechaSalida";
            this.fechaSalida.Size = new System.Drawing.Size(117, 20);
            this.fechaSalida.TabIndex = 7;
            // 
            // fechaEst
            // 
            this.fechaEst.Location = new System.Drawing.Point(381, 63);
            this.fechaEst.Name = "fechaEst";
            this.fechaEst.Size = new System.Drawing.Size(117, 20);
            this.fechaEst.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.cbTipoServicio1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.aeronaves);
            this.panel1.Location = new System.Drawing.Point(32, 345);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 243);
            this.panel1.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(389, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 21);
            this.button4.TabIndex = 5;
            this.button4.Text = "Buscar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbTipoServicio1
            // 
            this.cbTipoServicio1.FormattingEnabled = true;
            this.cbTipoServicio1.Location = new System.Drawing.Point(248, 13);
            this.cbTipoServicio1.Name = "cbTipoServicio1";
            this.cbTipoServicio1.Size = new System.Drawing.Size(121, 21);
            this.cbTipoServicio1.TabIndex = 5;
            this.cbTipoServicio1.SelectedIndexChanged += new System.EventHandler(this.cbTipoServicio1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo de Servicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Aeronave";
            // 
            // aeronaves
            // 
            this.aeronaves.AllowUserToAddRows = false;
            this.aeronaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aeronaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.modelo,
            this.matricula,
            this.fabricante,
            this.idServicioA,
            this.tipoServicio1,
            this.selec});
            this.aeronaves.Location = new System.Drawing.Point(13, 40);
            this.aeronaves.Name = "aeronaves";
            this.aeronaves.RowHeadersVisible = false;
            this.aeronaves.Size = new System.Drawing.Size(603, 191);
            this.aeronaves.TabIndex = 1;
            this.aeronaves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.aeronaves_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            this.modelo.Width = 110;
            // 
            // matricula
            // 
            this.matricula.HeaderText = "Matricula";
            this.matricula.Name = "matricula";
            this.matricula.Width = 110;
            // 
            // fabricante
            // 
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.Name = "fabricante";
            this.fabricante.ReadOnly = true;
            this.fabricante.Width = 110;
            // 
            // idServicioA
            // 
            this.idServicioA.HeaderText = "Column1";
            this.idServicioA.Name = "idServicioA";
            this.idServicioA.Visible = false;
            // 
            // tipoServicio1
            // 
            this.tipoServicio1.HeaderText = "Tipo de Servicio";
            this.tipoServicio1.Name = "tipoServicio1";
            this.tipoServicio1.Width = 130;
            // 
            // selec
            // 
            this.selec.HeaderText = "Seleccionar";
            this.selec.Image = ((System.Drawing.Image)(resources.GetObject("selec.Image")));
            this.selec.Name = "selec";
            this.selec.Width = 130;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ruta";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbTipoServicio);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.rutas);
            this.panel2.Location = new System.Drawing.Point(29, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 197);
            this.panel2.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(386, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 21);
            this.button3.TabIndex = 4;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbTipoServicio
            // 
            this.cbTipoServicio.FormattingEnabled = true;
            this.cbTipoServicio.Location = new System.Drawing.Point(245, 16);
            this.cbTipoServicio.Name = "cbTipoServicio";
            this.cbTipoServicio.Size = new System.Drawing.Size(121, 21);
            this.cbTipoServicio.TabIndex = 3;
            this.cbTipoServicio.SelectedIndexChanged += new System.EventHandler(this.cbTipoServicio_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tipo de Servicio";
            // 
            // rutas
            // 
            this.rutas.AllowUserToAddRows = false;
            this.rutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rutas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_ruta,
            this.codigo_ruta,
            this.ciudad_origen,
            this.ciudad_destino,
            this.idServicioRuta,
            this.tipo_servicio_ruta,
            this.selec1});
            this.rutas.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rutas.Location = new System.Drawing.Point(3, 43);
            this.rutas.Name = "rutas";
            this.rutas.RowHeadersVisible = false;
            this.rutas.Size = new System.Drawing.Size(610, 148);
            this.rutas.TabIndex = 1;
            this.rutas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rutas_CellContentClick);
            // 
            // id_ruta
            // 
            this.id_ruta.HeaderText = "ID";
            this.id_ruta.Name = "id_ruta";
            this.id_ruta.Visible = false;
            // 
            // codigo_ruta
            // 
            this.codigo_ruta.HeaderText = "Codigo";
            this.codigo_ruta.Name = "codigo_ruta";
            this.codigo_ruta.Visible = false;
            // 
            // ciudad_origen
            // 
            this.ciudad_origen.HeaderText = "Ciudad Origen";
            this.ciudad_origen.Name = "ciudad_origen";
            this.ciudad_origen.Width = 200;
            // 
            // ciudad_destino
            // 
            this.ciudad_destino.HeaderText = "Ciudad Destino";
            this.ciudad_destino.Name = "ciudad_destino";
            this.ciudad_destino.Width = 200;
            // 
            // idServicioRuta
            // 
            this.idServicioRuta.HeaderText = "Column1";
            this.idServicioRuta.Name = "idServicioRuta";
            this.idServicioRuta.ReadOnly = true;
            this.idServicioRuta.Visible = false;
            // 
            // tipo_servicio_ruta
            // 
            this.tipo_servicio_ruta.HeaderText = "Tipo Servicio";
            this.tipo_servicio_ruta.Name = "tipo_servicio_ruta";
            // 
            // selec1
            // 
            this.selec1.HeaderText = "Seleccionar";
            this.selec1.Image = ((System.Drawing.Image)(resources.GetObject("selec1.Image")));
            this.selec1.Name = "selec1";
            this.selec1.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 646);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(471, 646);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 44);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fechaSalida1
            // 
            this.fechaSalida1.Location = new System.Drawing.Point(171, 26);
            this.fechaSalida1.Name = "fechaSalida1";
            this.fechaSalida1.Size = new System.Drawing.Size(200, 20);
            this.fechaSalida1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(34, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Usted a seleccionado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(36, 604);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Usted a seleccionado";
            // 
            // Generar_Viaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(711, 733);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fechaSalida1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fechaEst);
            this.Controls.Add(this.fechaSalida);
            this.Controls.Add(this.fechaEst1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "Generar_Viaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaEst1;
        private System.Windows.Forms.DateTimePicker fechaSalida;
        private System.Windows.Forms.DateTimePicker fechaEst;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView aeronaves;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView rutas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbTipoServicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbTipoServicio1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker fechaSalida1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idServicioA;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoServicio1;
        private System.Windows.Forms.DataGridViewImageColumn selec;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad_origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad_destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn idServicioRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_servicio_ruta;
        private System.Windows.Forms.DataGridViewImageColumn selec1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
    }
}