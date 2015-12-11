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
        decimal importeSelec = 0;
        decimal importeTotal = 0;
        int formaPago = 1;
        Int32 idCompra = 0;
        Int32 idButaca = 0;

        DateTime f_act = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
        
        Persona persona = new Persona();
        Pasaje pasaje = new Pasaje ();
        List<Pasaje> pasajes = new List<Pasaje>();
        DataTable   table = new DataTable();

 
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
            public  int id { get; set; }
            public  int id_rol { get; set; }
            public int dni { get; set; }
            public String nombre { get; set; }
            public String apellido { get; set; }
            public String direccion { get; set; }
            public String telefono { get; set; }
            public String email { get; set; }
            public DateTime f_nacimiento { get; set; }
            public override string ToString()
            {
                return "PASAJE";
            }

        }

        public class Pasaje
        {
            public int id { get; set; }
            public int dni { get; set; }
            public int id_compra { get; set; }
            public int id_viaje { get; set; }
            public int id_butaca { get; set; }
            public decimal importe { get; set; }
           
            public override string ToString()
            {
                return "PASAJE";
            }
        }

        private Int32? idCiudadOrigenSelec
        {
            get
            {
                if (ciudadOrigen.SelectedItem == null)
                    return null;

                return (Int32?)((KeyValuePair<Int32, String>)ciudadOrigen.SelectedItem).Key;
            }
        }

        private Int32? idCiudadDestinoSelec
        {
            get
            {
                if (ciudadDestino.SelectedItem == null)
                    return null;

                return (Int32?)((KeyValuePair<Int32, String>)ciudadDestino.SelectedItem).Key;
            }
        }

        private void CargarCiudad()
        {
            ciudadOrigen.DisplayMember = "Value";
            ciudadOrigen.ValueMember = "Key";
            ciudadOrigen.Items.Clear();
            foreach (var tipo in Logica.Ciudad.Get())
                ciudadOrigen.Items.Add(new KeyValuePair<Int32, String>(tipo.Id, tipo.Nombre));

            ciudadDestino.DisplayMember = "Value";
            ciudadDestino.ValueMember = "Key";
            ciudadDestino.Items.Clear();
            foreach (var tipo in Logica.Ciudad.Get())
                ciudadDestino.Items.Add(new KeyValuePair<Int32, String>(tipo.Id, tipo.Nombre));       
        }

        private void viajesBuscar(DateTime f_salida, Int32? idCiudadOrigen, Int32? idCiudadDestino)
        {   
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("HAY_TABLA.sp_get_buscar_viaje", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!String.IsNullOrEmpty(f_salida.ToString()))
                    cmd.Parameters.Add("@f_salida", SqlDbType.NVarChar).Value = f_salida;
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
                    viajes.Rows[i].Cells["matricula"].Value = DR[1].ToString();
                    viajes.Rows[i].Cells["servicio"].Value = DR[2].ToString();
                    viajes.Rows[i].Cells["id_a"].Value = DR[3].ToString();
                    viajes.Rows[i].Cells["butacas"].Value = DR[4].ToString();
                    viajes.Rows[i].Cells["kg"].Value = DR[5].ToString();
                    i++; 
                }
                DR.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime salida = f_salida.Value;
            viajesBuscar(salida, idCiudadOrigenSelec, idCiudadDestinoSelec);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            pasAcomprar.Text = cantPasaje.Text;

            if (!cantPasaje.Text.Trim().Equals(""))
            {
                llenarButacasLibre(this.idViaje, this.idAeronave);
            }
        }

        private void llenarButacasLibre(int idViaje, int idAeronave)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("[HAY_TABLA].sp_butacas_libres_viaje", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (this.idViaje!= 0)
                    cmd.Parameters.Add("@idViaje", SqlDbType.Int).Value = this.idViaje;
                if (this.idAeronave != 0)
                    cmd.Parameters.Add("@idAeronave", SqlDbType.Int).Value = this.idAeronave;
                con.Open();
                SqlDataReader DR = cmd.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    butacasLibres.Rows.Add();

                    butacasLibres.Rows[i].Cells["numero"].Value = DR[0].ToString();
                    butacasLibres.Rows[i].Cells["tipo"].Value = DR[1].ToString();
                    butacasLibres.Rows[i].Cells["importe"].Value = DR[2].ToString();
                   
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
                   }
               }
               else
               {
                   button4.Visible = true;
                   tnombre.Text =  "";
                   tapellido.Text = "";
                   tdirec.Text = "";
                   ttel.Text = "";
                   temail.Text = "";
                   f_nac.Value = this.f_act;
               }
            reader.Close();
            }
        }

        private void viajes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!e.RowIndex.Equals(-1))
            {
                this.idViaje = Convert.ToInt32(viajes.Rows[e.RowIndex].Cells["id_viaje"].Value.ToString());
                String matricula = viajes.Rows[e.RowIndex].Cells["matricula"].Value.ToString();
                MessageBox.Show("Usted a seleccionado un viaje con la aeronave ( " + matricula + ")", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.idAeronave = Convert.ToInt32(viajes.Rows[e.RowIndex].Cells["id_a"].Value.ToString());
            }
        }

        private void butacasLibres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idButaca = Convert.ToInt32(butacasLibres.Rows[e.RowIndex].Cells["numero"].Value.ToString());
            this.importeSelec = Convert.ToDecimal(butacasLibres.Rows[e.RowIndex].Cells["importe"].Value.ToString());

            MessageBox.Show("Usted a seleccionado la butaca número: " + this.idButaca  , "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void limpiarDatos()
        {
            this.tdni.Text = "";
            this.tnombre.Text= "";
            this.tapellido.Text = "";
            this.tdirec.Text = "";
            this.temail.Text = "";
            this.ttel.Text = "";

            this.panel3.Visible = false;
            this.button4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tdni.Text))
            {
                MessageBox.Show("Complete el campo 'Nro de Documento' para asociar al pasajero.");
                return;
            }

            int cantidadPasajeSel = int.Parse(cantPasaje.Text);
            string doc = tdni.Text;
            Pasaje pasaje1 = new Pasaje();
            pasaje1.dni = int.Parse(doc);
            pasaje1.id_viaje = idViaje;
            pasaje1.id_butaca = idButaca;
            pasaje1.importe = importeSelec;

            pasajes.Add(pasaje1);

            if (pasajes.Count > 0 && pasajes.Count == cantidadPasajeSel)
            {
                button6.Visible = true;
                panel3.Visible = false;
            }

            this.importeTotal = 0;
           for ( int i = 0; i < pasajes.Count; i++)
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pasajesI.Text = importeTotal.ToString();

            total.Text = importeTotalFactura(pasajesI, encomiendaI);
            tabControl1.SelectedTab = tabPage4;
            llenarTipoTarjeta();
        }

        private void llenarTipoTarjeta()
        {
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
                var cmd = new SqlCommand("[HAY_TABLA].sp_persona_dni", con);
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

            MessageBox.Show(" Se realizo la compra exitosamente : " + this.idCompra.ToString(),  null, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guardarCompra()
        {
            int dniComprador = int.Parse(tdniComprador.Text);

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("HAY_TABLA.sp_alta_compra", con);
                cmd.CommandType = CommandType.StoredProcedure;

                     if (dniComprador != 0)
                    cmd.Parameters.Add("@dniComprador", SqlDbType.Int).Value = dniComprador;
                     cmd.Parameters.Add("@idTarjeta", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@idformaPago", SqlDbType.Int).Value = this.formaPago;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = f_act;
                    cmd.Parameters.Add("@cantCuota", SqlDbType.Int).Value = 0;
                 
                 con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.idCompra = reader.GetInt32(0);    
                    }
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
                        var cmd = new SqlCommand("HAY_TABLA.sp_alta_pasaje", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@dniCliente", SqlDbType.Int).Value = pasajes.ElementAt(i).dni;
                        cmd.Parameters.Add("@idCompra", SqlDbType.Int).Value = this.idCompra;
                        cmd.Parameters.Add("@idViaje", SqlDbType.Int).Value = this.idViaje;
                        cmd.Parameters.Add("@importe", SqlDbType.Int).Value = pasajes.ElementAt(i).importe;
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


    }
}
