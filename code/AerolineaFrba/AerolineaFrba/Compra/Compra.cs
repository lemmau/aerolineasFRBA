using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class Compra : Form
    {
        Int32 idViaje = 0;
        Int32 idAeronave = 0;
//Pasaje
        decimal importeSelec = 0;
        decimal importeTotal = 0;
        int formaPago = 1;
        Int32 idCompra = 0;
        Int32 idTarjeta = 0 ;
        Int32 idButaca = 0;
        Int32 nro_butaca = 0;

        DateTime f_act = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);

        List<Encomienda> encomiendas = new List<Encomienda>();

        Persona persona = new Persona();
        Pasaje pasaje = new Pasaje();
        List<Pasaje> pasajes = new List<Pasaje>();
        DataTable table = new DataTable();

  //encomienda
        decimal importeEnT = 0;

        public Compra()
        {
            InitializeComponent();
            f_salida.Value = f_act;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCiudad();
        }

        public class Persona
        {
            public int id { get; set; }
            public int id_rol { get; set; }
            public int dni { get; set; }
            public String nombre { get; set; }
            public String apellido { get; set; }
            public String direccion { get; set; }
            public String telefono { get; set; }
            public String email { get; set; }
            public DateTime f_nacimiento { get; set; }
            public override string ToString()
            {
                return "PERSONA";
            }

        }

        public class Pasaje
        {
            public int id { get; set; }
            public int dni { get; set; }
            public int id_compra { get; set; }
            public int id_viaje { get; set; }
            public int id_butaca { get; set; }
            public int nro_butaca { get; set; }
            public decimal importe { get; set; }
           
		   public override string ToString()
            {
                return "PASAJE";
            }
        }
		   public class Tarjeta
        {
            public int idTipoTarjeta { get; set; }
            public int dniComprador { get; set; }
            public int numero { get; set; }
            public int clave { get; set; }
            public DateTime fechaVenc { get; set; }
           
            public override string ToString()
            {
                return "TARJETA";
            }

        }


           public class Encomienda
           {
               public decimal importe { get; set; }
               public int peso { get; set; }
               public override string ToString()
               {
                   return "ENCOMIENDA";
               }

           }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }

        }

        private void CargarCiudad()
        {
            using (var conn = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("[HAY_TABLA].sp_get_ciudades", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();


                    while (DR.Read())
                    {

                        int id = DR.GetInt32(0);
                        string ciudad = DR.GetString(1);


                        ComboboxItem item = new ComboboxItem();
                        item.Text = ciudad;
                        item.Value = id;

                        ciudadOrigen.Items.Add(item);
                        ciudadDestino.Items.Add(item);
                    }
                    DR.Close();
                }

                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        
        }

        private void viajesBuscar(DateTime f_salida, Int32? idCiudadOrigen, Int32? idCiudadDestino)
        {
            DateTime f_act = f_salida;
            f_act = f_act.AddHours(-f_act.Hour);
            f_act = f_act.AddMinutes(-f_act.Minute);
            f_act = f_act.AddSeconds(-f_act.Second);

            f_act = f_act.AddHours(DateTime.Now.Hour);
            f_act = f_act.AddMinutes(DateTime.Now.Minute);
            f_act = f_act.AddSeconds(DateTime.Now.Second);

            // only for testing
            //MessageBox.Show("fecha salida: " + f_salida.ToString("dd/MM/yyyy") + " y fecha del sistema: " + f_act);
           using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("[HAY_TABLA].sp_get_buscar_viaje", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!String.IsNullOrEmpty(f_salida.ToString()))
                    cmd.Parameters.Add("@f_salida", SqlDbType.DateTime).Value = f_salida;
                cmd.Parameters.Add("@fechaYHoraActual", SqlDbType.DateTime).Value = f_act;
                if (idCiudadOrigen != 0)
                    cmd.Parameters.Add("@idCiudadOrigen", SqlDbType.Int).Value = idCiudadOrigen;
                if (idCiudadDestino != 0)
                    cmd.Parameters.Add("@idCiudadDestino", SqlDbType.Int).Value = idCiudadDestino;
                con.Open();
                SqlDataReader DR = cmd.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    viajes.Rows.Add();

                    viajes.Rows[i].Cells["id_viaje"].Value = DR[0].ToString();
                    viajes.Rows[i].Cells["horarioDeSalida"].Value = DR[1].ToString();
                    viajes.Rows[i].Cells["matricula"].Value = DR[2].ToString();
                    viajes.Rows[i].Cells["servicio"].Value = DR[3].ToString();
                    viajes.Rows[i].Cells["id_a"].Value = DR[4].ToString();
                    viajes.Rows[i].Cells["butacas"].Value = DR[5].ToString();
                    viajes.Rows[i].Cells["kg"].Value = DR[6].ToString();
                    i++;
                   
                }
                DR.Close();
            }

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validarComboCiudadOrigen() && validarComboCiudadDestino())
            {
                DateTime salida = f_salida.Value;
                int idCiudadOrigenSelec = ((ComboboxItem)ciudadOrigen.SelectedItem).Value;
                int idCiudadDestinoSelec = ((ComboboxItem)ciudadDestino.SelectedItem).Value;
                viajesBuscar(salida, idCiudadOrigenSelec, idCiudadDestinoSelec);
            }
        }
        private Boolean validarComboCiudadOrigen()
        {
            if (((ComboboxItem)ciudadOrigen.SelectedItem) == null)
            {
                MessageBox.Show("Debe seleccionar ciudad de origen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private Boolean validarComboCiudadDestino()
        {
            if (((ComboboxItem)ciudadDestino.SelectedItem) == null)
            {
                MessageBox.Show("Debe seleccionar ciudad de destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.idViaje != 0)
            {
                int cantPasaje = int.Parse(cantPa.Text);
                int cantEncomienda = int.Parse(cantE.Text);

                if (cantPasaje == 0 && cantEncomienda == 0)
                {
                    MessageBox.Show("Ingrese la cantidad de Pasaje y/o Encomienda a comprar", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (cantPasaje != 0)
                    {
                        pasAcomprar.Text = cantPa.Text;
                        TabControl.SelectedTab = tabPasaje;
                        llenarButacasLibre(this.idViaje, this.idAeronave);
                    }

                    if (cantPasaje == 0)
                    {
                        button5.Visible = false;
                        TabControl.SelectedTab = TabEncomienda;
                        cantEncomiendaSelec.Text = cantE.Text;
                        llenarkgEncomienda();
                    }

                    if (cantEncomienda != 0 && cantPasaje != 0)
                    {
                        bcontinuarPasaje.Visible = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un viaje para continuar", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void llenarkgEncomienda()
        {


            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("HAY_TABLA.sp_kg_libre_viaje", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (this.idViaje != 0)
                    cmd.Parameters.Add("@idViaje", SqlDbType.Int).Value = this.idViaje;

                if (this.idAeronave != 0)
                    cmd.Parameters.Add("@idAeronave", SqlDbType.Int).Value = this.idAeronave;

                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EcantKg.Text = reader.GetInt32(0).ToString();
                        Eimporte.Text = reader.GetDecimal(1).ToString();
                    }
                }

                reader.Close();
            }
        }



        private void llenarButacasLibre(int idViaje, int idAeronave)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("[HAY_TABLA].sp_butacas_libres_viaje", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (this.idViaje != 0)
                    cmd.Parameters.Add("@idViaje", SqlDbType.Int).Value = this.idViaje;
                if (this.idAeronave != 0)
                    cmd.Parameters.Add("@idAeronave", SqlDbType.Int).Value = this.idAeronave;
                con.Open();
                SqlDataReader DR = cmd.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    butacasLibres.Rows.Add();

                    butacasLibres.Rows[i].Cells["id_butaca"].Value = DR[0].ToString();
                    butacasLibres.Rows[i].Cells["numero"].Value = DR[1].ToString();
                    butacasLibres.Rows[i].Cells["tipo"].Value = DR[2].ToString();
                    butacasLibres.Rows[i].Cells["importe"].Value = DR[3].ToString();

                    i++;
                }
                DR.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 numeroEntero;

            if (String.IsNullOrEmpty(tdni.Text))
            {
                MessageBox.Show("El campo 'Nro de Documento' se encuentra vacio.");
                return;
            }
            else if (!String.IsNullOrEmpty(tdni.Text)
                && !Int32.TryParse(tdni.Text, out numeroEntero))
            {
                MessageBox.Show("El número de DNI debe ser numérico y sin puntos.");
                return;
            }

            int dni = Int32.Parse(tdni.Text);
            panel3.Visible = true;

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("[HAY_TABLA].sp_persona_dni", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!String.IsNullOrEmpty(f_salida.ToString()))
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tnombre.Text = reader.GetString(0);
                        tapellido.Text = reader.GetString(1);
                        tdirec.Text = reader.GetString(2);
                        ttel.Text = reader.GetString(3);
                        temail.Text = reader.GetString(4);
                        f_nac.Value = reader.GetDateTime(5);
                       button4.Visible = false;
                       tdni.ReadOnly = true;
                       datosPasajero(true);
                       dniSele.Text = tdni.Text;
				  }
                }
                else
                {
                    button4.Visible = true;
                    tnombre.Text = "";
                    tapellido.Text = "";
                    tdirec.Text = "";
                    ttel.Text = "";
                    temail.Text = "";
                    
                    f_nac.Value = this.f_act;
					   datosPasajero(false); 
                }
                reader.Close();
            }
        }

 private void datosPasajero (Boolean edit  ){
            tnombre.ReadOnly = edit;
            tapellido.ReadOnly = edit;
            tdirec.ReadOnly = edit;
            ttel.ReadOnly = edit;
            temail.ReadOnly = edit;
            f_nac.Enabled = !edit;

        }


 private void datosComprador(Boolean edit)
 {
     tnombreC.ReadOnly = edit;
     tapellidoC.ReadOnly = edit;
     tdirecC.ReadOnly = edit;
     ttelCo.ReadOnly = edit;
     temailC.ReadOnly = edit;
     f_nacC.Enabled = !edit;

 }
		

        private void viajes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!e.RowIndex.Equals(-1))
            {
                this.idViaje = Convert.ToInt32(viajes.Rows[e.RowIndex].Cells["id_viaje"].Value.ToString());
                String matricula = viajes.Rows[e.RowIndex].Cells["matricula"].Value.ToString();
                MessageBox.Show("Usted a seleccionado un viaje con la aeronave ( " + matricula + " )", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.idAeronave = Convert.ToInt32(viajes.Rows[e.RowIndex].Cells["id_a"].Value.ToString());
            }
        }

        private void butacasLibres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idButaca = Convert.ToInt32(butacasLibres.Rows[e.RowIndex].Cells["id_butaca"].Value.ToString());
            this.nro_butaca = Convert.ToInt32(butacasLibres.Rows[e.RowIndex].Cells["numero"].Value.ToString());
            this.importeSelec = Convert.ToDecimal(butacasLibres.Rows[e.RowIndex].Cells["importe"].Value.ToString());

            MessageBox.Show("Usted a seleccionado la butaca número: " + this.nro_butaca, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            butacaSelect.Text = nro_butaca.ToString();
        }

        private void limpiarDatos()
        {
            this.tdni.Text = "";
            this.tnombre.Text = "";
            this.tapellido.Text = "";
            this.tdirec.Text = "";
            this.temail.Text = "";
            this.ttel.Text = "";

            this.panel3.Visible = false;
            this.button4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
         if (validarAddPasaje())

            {
                int cantEncomienda = int.Parse(cantE.Text);
                int cantidadPasajeSel = int.Parse(cantPa.Text);

                string doc = tdni.Text;

                Pasaje pasaje1 = new Pasaje();
                pasaje1.dni = int.Parse(doc);
                pasaje1.id_viaje = idViaje;
                pasaje1.id_butaca = idButaca;
                pasaje1.nro_butaca = nro_butaca;
                pasaje1.importe = importeSelec;

                if (validacionPasajero(pasaje1))
                {

                    pasajes.Add(pasaje1);

                    if (pasajes.Count > 0 && pasajes.Count == cantidadPasajeSel)
                    {

                        groupBox2.Visible = false;
                        MessageBox.Show("Usted a comprado la cantidad de pasaje selecciondo" + this.idCompra.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (cantEncomienda == 0)
                        {
                            pagarPasaje.Visible = true;
                        }

                    }

                    this.importeTotal = 0;
                    for (int i = 0; i < pasajes.Count; i++)
                    {


                        DataPasaje.Rows.Add();

                        DataPasaje.Rows[i].Cells["dniP"].Value = pasajes.ElementAt(i).dni;
                        DataPasaje.Rows[i].Cells["butacaP"].Value = pasajes.ElementAt(i).id_butaca;
                        DataPasaje.Rows[i].Cells["importeP"].Value = pasajes.ElementAt(i).importe;

                        this.importeTotal = this.importeTotal + pasajes.ElementAt(i).importe;


                    }

                    this.importePa.Text = importeTotal.ToString();

                    tdni.Text = "";
                    this.panel3.Visible = false;
                    this.idButaca = 0;
                    this.importeSelec = 0;
                    butacaSelect.Text = "";
                    dniSele.Text = "";
                    tdni.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show(" El pasajero que intenta cargar no  puede viajar " + this.idCompra.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool validacionPasajero(Pasaje pasaje1)
        {
           //validar
            return true;
        }

  
		    private bool validarAddPasaje()
        {
            if (this.idButaca == 0)

            {
             
                MessageBox.Show("Debe seleccionar una  butaca " + this.idCompra.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;


            }
            if (tdni.Text.Trim().Equals("") )

          {
                MessageBox.Show("Debe completar los datos personales del pasajero " + this.idCompra.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (!validarPasajeroDoble())
            {
                MessageBox.Show("El pasajero ya se encuentra con un pasaje asignado para la venta" + this.idCompra.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!validarButacaDoble())
            {
                MessageBox.Show("La butaca ya se encuentra con un pasaje asignado para la venta" + this.idCompra.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

            private bool validarButacaDoble()
            {
                int cantPasajes = pasajes.Count;
                for (int i = 0; i < cantPasajes; i++)
                {

                    int butaca = pasajes.ElementAt(i).id_butaca;
                    if (this.idButaca == butaca)
                    {
                        return false;
                    }

                }
                return true;
            }

            private bool validarPasajeroDoble()
            {
                int cantPasajes = pasajes.Count;
                for (int i = 0 ; i < cantPasajes; i++)
                {

                  int dniB =pasajes.ElementAt(i).dni;
                  if (int.Parse(tdni.Text) == dniB)
                  {
                      return false;
                  }

                }
                return true;

            }
		
        private void llenarTipoTarjeta()
        {
            using (var conn = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("[HAY_TABLA].sp_tipo_tarjeta", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();


                    while (DR.Read())
                    {

                        int id_tipo_tarjeta = DR.GetInt32(0);
                        string tipo_tarjeta = DR.GetString(1);


                        ComboboxItem item = new ComboboxItem();
                        item.Text = tipo_tarjeta;
                        item.Value = id_tipo_tarjeta;

                        ctipoTarjeta.Items.Add(item);
                       
                    }
                    DR.Close();
                }

                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }



        }

        private string importeTotalFactura(TextBox pasajesI, TextBox encomiendaI)
        {
            decimal i1 = decimal.Parse(pasajesI.Text);
            decimal i2 = decimal.Parse(encomiendaI.Text);
            decimal iTotal = i1 + i2;
            return iTotal.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tdniComprador.Text))
            {
                MessageBox.Show("El campo 'Nro de Documento' se encuentra vacio.");
                return;
            }

            int tdniC = Int32.Parse(tdniComprador.Text);
            panel8.Visible = true;

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("HAY_TABLA.sp_persona_dni", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!String.IsNullOrEmpty(f_salida.ToString()))
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = tdniC;
                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tnombreC.Text = reader.GetString(0);
                        tapellidoC.Text = reader.GetString(1);
                        tdirecC.Text = reader.GetString(2);
                        ttelCo.Text = reader.GetString(3);
                        temailC.Text = reader.GetString(4);
                        f_nacC.Value = reader.GetDateTime(5);
                        tdniComprador.ReadOnly = true;
                        registrarC.Visible = false;
                        datosComprador(true);
                    }
                }
                else
                {
                    registrarC.Visible = true;
                    tnombreC.Text = "";
                    tapellidoC.Text = "";
                    tdirecC.Text = "";
                    ttelCo.Text = "";
                    temailC.Text = "";
                    f_nacC.Value = this.f_act;

                }

                reader.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.formaPago = 1;
            guardarCompra();
            guardarPasajes();
            guardarEncomienda();
            MessageBox.Show(" Se realizo la compra exitosamente.\n\t PNR: [" + this.idCompra.ToString() + "]",  null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
			 
		}
		  private void guardarEncomienda()
        {
            for (int i = 0; i < encomiendas.Count; i++)
            {

                using (var con = DataAccess.GetConnection())
                {

                    try
                    {
                        var cmd = new SqlCommand("HAY_TABLA.sp_alta_encomienda", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add("@idCompra", SqlDbType.Int).Value = this.idCompra;
                        cmd.Parameters.Add("@idViaje", SqlDbType.Int).Value = this.idViaje;
                        cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = encomiendas.ElementAt(i).importe;
                        cmd.Parameters.Add("@peso", SqlDbType.Int).Value = encomiendas.ElementAt(i).peso;

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error en al guardar la encomienda  " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        con.Close();
                        return;
                    }
                    con.Close();

                }

            }


        }

        private void guardarCompra()
        {
            int dniComprador = int.Parse(tdniComprador.Text);

            int cantCuota = 0;
            int idTar = 0;
          
         
                if (this.formaPago == 2)
                {
                    cantCuota = int.Parse(tcuota.Text);
                    idTar = this.idTarjeta;
                    
                }


            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("HAY_TABLA.sp_alta_compra", con);
                cmd.CommandType = CommandType.StoredProcedure;

                     if (dniComprador != 0)
                    cmd.Parameters.Add("@dniComprador", SqlDbType.Int).Value = dniComprador;
                    cmd.Parameters.Add("@idTarjeta", SqlDbType.Int).Value = idTar;
                    cmd.Parameters.Add("@idformaPago", SqlDbType.Int).Value = this.formaPago;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = f_act;
                 
                     cmd.Parameters.Add("@cantCuota", SqlDbType.Int).Value = cantCuota;
                                    
                 con.Open();



                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.idCompra = reader.GetInt32(0);
                       
                    }
                    
                reader.Close();
                }

                reader.Close();
            }
        }

        private void guardarPasajes()
        {


            for (int i = 0; i < pasajes.Count; i++)
            {

                using (var con = DataAccess.GetConnection())
                {

                    try
                    {
                        var cmd = new SqlCommand("[HAY_TABLA].sp_alta_pasaje", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@dniCliente", SqlDbType.Int).Value = pasajes.ElementAt(i).dni;
                        cmd.Parameters.Add("@idCompra", SqlDbType.Int).Value = this.idCompra;
                        cmd.Parameters.Add("@idViaje", SqlDbType.Int).Value = this.idViaje;
                        cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = pasajes.ElementAt(i).importe;
                        cmd.Parameters.Add("@idButaca", SqlDbType.Int).Value = pasajes.ElementAt(i).id_butaca;

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error en al guardar el pasaje  " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        con.Close();
                        return;
                    }
                    con.Close();

                }


            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void DataPasaje_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void importePa_TextChanged(object sender, EventArgs e)
        {
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            ciudadOrigen.SelectedIndex = -1;
            ciudadDestino.SelectedIndex = -1;
        }

        private void bcontinuarPasaje_Click(object sender, EventArgs e)
        {
            pasajesI.Text = importeTotal.ToString();
            TabControl.SelectedTab = TabEncomienda;
            cantEncomiendaSelec.Text = cantE.Text;
            llenarkgEncomienda();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.formaPago = 2;
            llenarTipoTarjeta();
            groupBox3.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (validarCamposTarjeta())
            {

                int idTipoTarjeta = 0;

                Tarjeta tar = new Tarjeta();

                tar.dniComprador = int.Parse(this.tdniComprador.Text);


                if (validarComboVacio())
                    idTipoTarjeta = ((ComboboxItem)ctipoTarjeta.SelectedItem).Value;

                tar.idTipoTarjeta = idTipoTarjeta;

                tar.numero = int.Parse(tnumero.Text);
                tar.clave = int.Parse(tcodigo.Text);
                int mesVencimiento = int.Parse(tmes.SelectedItem.ToString());
                int aniVencimiento = int.Parse(tanio.SelectedItem.ToString());



                DateTime fvencimiento = new DateTime();
                fvencimiento = fvencimiento.AddDays(1);
                fvencimiento = fvencimiento.AddMonths(mesVencimiento);
                fvencimiento = fvencimiento.AddYears(aniVencimiento);
                tar.fechaVenc = fvencimiento;

                guardarTarjeta(tar);
                guardarCompra();
                guardarPasajes();
                guardarEncomienda();
               
                MessageBox.Show(" Se realizo la compra exitosamente : " + this.idCompra.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool validarCamposTarjeta()
        {
            if (tnumero.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe ingresar un número de tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            if (((ComboboxItem)ctipoTarjeta.SelectedItem) == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (tmes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar el mes de la fecha de Vencimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tanio.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccinar el año de la fecha de vencimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tcuota.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccinar una cuota ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;

        }

        private Boolean validarComboVacio()
        {
            if (((ComboboxItem)ctipoTarjeta.SelectedItem) == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void guardarTarjeta(Tarjeta tarjeta)
        {
            using (var con = DataAccess.GetConnection())
            {

                try
                {
                    var cmd = new SqlCommand("HAY_TABLA.sp_alta_tarjeta", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@idTipoTarjeta", SqlDbType.Int).Value = tarjeta.idTipoTarjeta;
                    cmd.Parameters.Add("@dniComprador", SqlDbType.Int).Value = tarjeta.dniComprador;
                    cmd.Parameters.Add("@numero", SqlDbType.Int).Value = tarjeta.numero;
                    cmd.Parameters.Add("@clave", SqlDbType.Int).Value = tarjeta.clave;
                    cmd.Parameters.Add("@fechaV", SqlDbType.DateTime).Value = tarjeta.fechaVenc;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            this.idTarjeta = reader.GetInt32(0);
                            MessageBox.Show("Error en al guardar los datos de la tarjeta  ", null, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        reader.Close();
                    }



                }
                catch (Exception error)
                {
                    MessageBox.Show("Error en al guardar los datos de la tarjeta  " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;
                }
                con.Close();
            }
        }

        private void registrarC_Click(object sender, EventArgs e)
        {
            if (validacionesDatosComprador())
            {
                Persona compradorNuevo = new Persona();
                compradorNuevo.dni = int.Parse(tdniComprador.Text);
                compradorNuevo.nombre = tnombreC.Text;
                compradorNuevo.apellido = tapellidoC.Text;
                compradorNuevo.direccion = tdirecC.Text;
                compradorNuevo.email = temail.Text;
                compradorNuevo.telefono = ttelCo.Text;

                DateTime fechaNacComprador = f_nacC.Value;
                fechaNacComprador = fechaNacComprador.AddHours(-fechaNacComprador.Hour);
                fechaNacComprador = fechaNacComprador.AddMinutes(-fechaNacComprador.Minute);
                fechaNacComprador = fechaNacComprador.AddSeconds(-fechaNacComprador.Second);
                fechaNacComprador = fechaNacComprador.AddMilliseconds(-fechaNacComprador.Millisecond);

                compradorNuevo.f_nacimiento = fechaNacComprador;

                altaPersona(compradorNuevo);

                registrarC.Visible = false;

                tdniComprador.ReadOnly = true;
                datosComprador(true);
            }

        }

        private void altaPersona(Persona per)
        {


            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("HAY_TABLA.sp_alta_persona", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@dni", SqlDbType.Int).Value = per.dni;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = per.nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = per.apellido;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = per.direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = per.telefono;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = per.email;
                cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = per.f_nacimiento;


                try
                {


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error en al guardar los Datos Persona  " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    con.Close();
                    return;
                }
                con.Close();

                MessageBox.Show("Se registrado  los datos correctamente  ", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                button4.Visible = false;
                tdni.ReadOnly = true;
                datosPasajero(true);
                dniSele.Text = tdni.Text;

            }


        }



        private Boolean validacionesDatosPasajero()
        {
            if (tdni.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe ingresar un DNI  ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tnombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe ingresar un Nombre  ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tapellido.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe ingresar un Apellido  ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DateTime fechaNac = f_nac.Value;
            if (fechaNac < this.f_act)
            {
                //MessageBox.Show("fec nac " + fechaNac + " fec actual " + this.f_act);
                MessageBox.Show("La fecha de nacimiento debe ser menor a la actual ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private Boolean validacionesDatosComprador()
        {


            if (tdniComprador.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe ingresar un DNI  ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tnombreC.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe ingresar un Nombre  ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tapellidoC.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe ingresar un Apellido  ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DateTime fechaNac = f_nacC.Value;
            if (fechaNac < this.f_act)
            {
                MessageBox.Show("La fecha del nacimiento debe ser menor a la actual ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;


        }

        private void button4_Click(object sender, EventArgs e)
             {

                 if (validacionesDatosPasajero())
                 {
                     Persona pasajero = new Persona();
                     pasajero.dni = int.Parse(tdni.Text);
                     pasajero.nombre = tnombre.Text;
                     pasajero.apellido = tapellido.Text;
                     pasajero.direccion = tdirec.Text;
                     pasajero.email = temail.Text;
                     pasajero.telefono = ttel.Text;

                     DateTime fechaNacimiento = f_nac.Value;
                     fechaNacimiento = fechaNacimiento.AddHours(-fechaNacimiento.Hour);
                     fechaNacimiento = fechaNacimiento.AddMinutes(-fechaNacimiento.Minute);
                     fechaNacimiento = fechaNacimiento.AddSeconds(-fechaNacimiento.Second);
                     fechaNacimiento = fechaNacimiento.AddMilliseconds(-fechaNacimiento.Millisecond);


                     pasajero.f_nacimiento = fechaNacimiento;

                     altaPersona(pasajero);
                 }   



        }

        private void pagarPasaje_Click(object sender, EventArgs e)
        {
            pasajesI.Text = importeTotal.ToString();

            total.Text = importeTotalFactura(pasajesI, encomiendaI);
            TabControl.SelectedTab = tabPage4;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (validarAddEncomienda())
            {
                int cantEncomienda = int.Parse(cantE.Text);

                Encomienda encomienda = new Encomienda();
                encomienda.peso = int.Parse(kgAenviar.Text);
                encomienda.importe = decimal.Parse(Eimporte.Text) * int.Parse(kgAenviar.Text);

                EcantKg.Text = (int.Parse(EcantKg.Text) - encomienda.peso).ToString();


                encomiendas.Add(encomienda);



                if (encomiendas.Count > 0 && encomiendas.Count == cantEncomienda)
                {

                    button12.Visible = true;

                    button11.Visible = false;
                    MessageBox.Show("Usted ha finalizado la cantidad de encomienda a enviar", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                this.importeEnT = 0;
                for (int i = 0; i < encomiendas.Count && i< cantEncomienda; i++)
                {


                    dataEncomienda.Rows.Add();

                    dataEncomienda.Rows[i].Cells["kgE"].Value = encomiendas.ElementAt(i).peso;
                    dataEncomienda.Rows[i].Cells["importeE"].Value = encomiendas.ElementAt(i).importe;


                    this.importeEnT = this.importeEnT + encomiendas.ElementAt(i).importe;



                }

                this.importeEncomienda.Text = importeEnT.ToString();

                kgAenviar.Text = "";

            }

        }

        private bool validarAddEncomienda()
        {

            int kgDisponible = int.Parse(EcantKg.Text);
            int KAenviar = int.Parse(kgAenviar.Text);
            int kgAvalidar = kgDisponible - KAenviar;

            if(kgAvalidar<0){

                MessageBox.Show("Los Kg que quiere enviar supera al Kg disponibles", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;   
            }

            return true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            encomiendaI.Text = importeEnT.ToString();
            total.Text = importeTotalFactura(pasajesI, encomiendaI);
            TabControl.SelectedTab = tabPage4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tdni.ReadOnly = false;
            datosPasajero(false);
            this.idButaca = 0;
            butacaSelect.Text = "";
            dniSele.Text = "";
            tdni.Text = "";
            tnombre.Text = "";
            tapellido.Text= "";
            tdirec.Text= "";
            temail.Text = "";
            ttel.Text = "";
            f_nac.Value = f_act;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            tdniComprador.ReadOnly = false;
            datosComprador(false);
            tdniComprador.Text = "";
            tnombreC.Text = "";
            tapellidoC.Text = "";
            tdirecC.Text = "";
            temailC.Text = "";
            ttelCo.Text = "";
            f_nacC.Value = f_act;
        }
        
    }




}
