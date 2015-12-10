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

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class Generar_Viaje : Form
    {
        int id_aeronave = 0;
        int id_ruta_selec = 0;
        String matricula_seleccionada;
        String ciudadOrigen_seleccionada;
        String ciudadDestino_seleccionada;

        int id_tipo_ser_ruta=0;
        int id_tipo_ser_aer=0;

        DateTime fecha_actual;
        DateTime fechaSis;
        public Generar_Viaje()
        {
            InitializeComponent();
        }

        private void Generar_Viaje_Load(object sender, EventArgs e)
        {
            fechaSis = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
            fechaSis = fechaSis.AddHours(DateTime.Now.Hour);
            fechaSis = fechaSis.AddMinutes(DateTime.Now.Minute);
            fechaSis = fechaSis.AddSeconds(DateTime.Now.Second);

            fechaSalida1.Value = fechaSis;
            fechaEst1.Value = fechaSis;
           
            fechaSalida.Format = DateTimePickerFormat.Time;
            fechaSalida.Value = fechaSis;
            fechaSalida.ShowUpDown = true;
            
           
            fechaEst.Format = DateTimePickerFormat.Time;
            fechaEst.ShowUpDown = true;
            fechaEst.Value = fechaSis;

            llenarCombo();
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
        private void llenarCombo()
        {
            using (var conn = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("[HAY_TABLA].sp_get_tipo_servicio", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();
                    

                    while (DR.Read())
                    {

                        int id_tipo_serv = DR.GetInt32(0);
                        string tipo_serv = DR.GetString(1);


                        ComboboxItem item = new ComboboxItem();
                        item.Text = tipo_serv;
                        item.Value = id_tipo_serv;

                        cbTipoServicio.Items.Add(item);
                        cbTipoServicio1.Items.Add(item);
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
        

        private void fechaSalida1_ValueChanged(object sender, EventArgs e)
        {
            String str_error = "";
            if (fechaSalidaMenorActual())
                str_error += "La fecha de salida no puede ser previa a la actual y en caso de ser la misma, debe tener una hora de diferencia\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

          


        }

        private void fechaLlegada1_ValueChanged(object sender, EventArgs e)
        {

            String str_error = "";
            if (fechaLLegadaEstimMenorFechaSalida())
                str_error += "La fecha de llegada estimada no puede ser previa a la fecha de salida\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

 

        public Boolean fechaLLegadaEstimMenorFechaSalida()
        {

            DateTime v_f_salida = fechaSalida1.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
         
            DateTime v_h_salida = fechaSalida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            int segundo_salida = v_h_salida.Second;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);
            v_h_salida = v_f_salida.AddSeconds(segundo_salida);

            DateTime v_f_llegada_estim = fechaEst1.Value;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(-v_f_llegada_estim.Hour);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(-v_f_llegada_estim.Minute);
            v_f_llegada_estim = v_f_llegada_estim.AddSeconds(-v_f_llegada_estim.Second);
            v_f_llegada_estim = v_f_llegada_estim.AddMilliseconds(-v_f_llegada_estim.Millisecond);
            DateTime v_h_llegada_estim = fechaEst.Value;
            int hora_llegada_estim = v_h_llegada_estim.Hour;
            int minutos_llegada_estim = v_h_llegada_estim.Minute;
            int segundo_llegada_estim = v_h_llegada_estim.Second;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(hora_llegada_estim);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(minutos_llegada_estim);
            v_h_llegada_estim = v_h_llegada_estim.AddSeconds(segundo_llegada_estim);
            if (v_f_llegada_estim <= v_f_salida)
                return true;

            return false;

        }

        private void fechaEst1_ValueChanged(object sender, EventArgs e)
        {
            String str_error = "";
            if (fechaLLegadaEstimMayor24hs())
                str_error += "El tiempo estimado de viaje no puede ser mayor a 24 hs\n ";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        public Boolean fechaLLegadaEstimMayor24hs()
        {

            DateTime v_f_salida = fechaSalida1.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
            DateTime v_h_salida = fechaSalida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            int segundo_salida = v_h_salida.Second;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);
            v_f_salida = v_f_salida.AddSeconds(segundo_salida);

            v_f_salida = v_f_salida.AddHours(24);

            DateTime v_f_llegada_estim = fechaEst1.Value;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(-v_f_llegada_estim.Hour);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(-v_f_llegada_estim.Minute);
            v_f_llegada_estim = v_f_llegada_estim.AddSeconds(-v_f_llegada_estim.Second);
            v_f_llegada_estim = v_f_llegada_estim.AddMilliseconds(-v_f_llegada_estim.Millisecond);
            DateTime v_h_llegada_estim = fechaEst.Value;
            int hora_llegada_estim = v_h_llegada_estim.Hour;
            int minutos_llegada_estim = v_h_llegada_estim.Minute;
            int segundo_llegada_estim = v_h_llegada_estim.Second;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(hora_llegada_estim);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(minutos_llegada_estim);
            v_f_llegada_estim = v_f_llegada_estim.AddSeconds(segundo_llegada_estim);


            if (v_f_llegada_estim >= v_f_salida)
                return true;

            return false;

        }


        public Boolean fechaSalidaMenorActual()
        {
           


            this.fechaSis = this.fechaSis.AddHours(1);



            
            DateTime v_f_salida = fechaSalida1.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
       
            DateTime v_h_salida = fechaSalida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            int segundo_salida = v_h_salida.Second;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);
            v_f_salida = v_f_salida.AddSeconds(segundo_salida);

            if (v_f_salida < this.fechaSis)
            {
                this.fechaSis = this.fechaSis.AddHours(-1);
                return true;
            }
            else
            {
                this.fechaSis = this.fechaSis.AddHours(-1);
                return false;
            }
        }



        private DateTime get_fecha_salida()
        {
            DateTime fecha = fechaSalida1.Value;
            fecha = fecha.AddHours(-fecha.Hour);
            fecha = fecha.AddMinutes(-fecha.Minute);
            fecha = fecha.AddSeconds(-fecha.Second);

            DateTime fecha_h = fechaSalida.Value;
            int hora = fecha_h.Hour;
            int minuto = fecha_h.Minute;
            int segundo = fecha_h.Second;

            fecha = fecha.AddHours(hora);
            fecha = fecha.AddMinutes(minuto);
            fecha = fecha.AddSeconds(segundo);

            return fecha;

        }


      /*  private DateTime get_fecha_llegada()
        {
            DateTime fecha = fechaLlegada1.Value;
            fecha = fecha.AddHours(-fecha.Hour);
            fecha = fecha.AddMinutes(-fecha.Minute);
            fecha = fecha.AddMilliseconds(-fecha.Millisecond);
            DateTime fecha_h = fechaLlegada.Value;
            int hora = fecha_h.Hour;
            int minuto = fecha_h.Minute;
            int segundo = fecha_h.Second;
            fecha = fecha.AddHours(hora);
            fecha = fecha.AddMinutes(minuto);
            fecha = fecha.AddSeconds(segundo);
            return fecha;



        }*/

        private DateTime get_fecha_llegada_est()
        {

            DateTime fecha = fechaEst1.Value;
            fecha = fecha.AddHours(-fecha.Hour);
            fecha = fecha.AddMinutes(-fecha.Minute);
            fecha = fecha.AddSeconds(-fecha.Second);
            fecha = fecha.AddMilliseconds(-fecha.Millisecond);

            DateTime fecha_h = fechaEst.Value;
            int hora = fecha_h.Hour;
            int minuto = fecha_h.Minute;
            int seg = fecha_h.Second;

            fecha = fecha.AddHours(hora);
            fecha = fecha.AddMinutes(minuto);
            fecha = fecha.AddSeconds(seg);

            return fecha;
        }

        private void aeronaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!e.RowIndex.Equals(-1))
            {
                this.id_aeronave = Convert.ToInt32(aeronaves.Rows[e.RowIndex].Cells["id"].Value.ToString());
                this.matricula_seleccionada = aeronaves.Rows[e.RowIndex].Cells["matricula"].Value.ToString();


                this.id_tipo_ser_aer = Convert.ToInt32(aeronaves.Rows[e.RowIndex].Cells["idServicioA"].Value.ToString());
                MessageBox.Show("Usted a seleccionado la Aeronave con la matricula " + this.matricula_seleccionada, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                label8.Text = "Usted a seleccionado la Aeronave con la matricula " + this.matricula_seleccionada;
                
            }
        }

        private void rutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( !e.RowIndex.Equals(-1))
            {
                this.id_ruta_selec = Convert.ToInt32(rutas.Rows[e.RowIndex].Cells["id_ruta"].Value.ToString());
                this.id_tipo_ser_ruta = Convert.ToInt32(rutas.Rows[e.RowIndex].Cells["idServicioRuta"].Value.ToString());
                this.ciudadOrigen_seleccionada =rutas.Rows[e.RowIndex].Cells["ciudad_origen"].Value.ToString();
                this.ciudadDestino_seleccionada = rutas.Rows[e.RowIndex].Cells["ciudad_destino"].Value.ToString();
                MessageBox.Show("Usted selecciono la ruta con ciudad de origen :" + this.ciudadOrigen_seleccionada  +" ciudad destino: "+ this.ciudadDestino_seleccionada , "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                label3.Text = "Usted selecciono la ruta con ciudad de origen :" + this.ciudadOrigen_seleccionada + " ciudad destino: " + this.ciudadDestino_seleccionada;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Generar_Viaje.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validaciones())
            {

                DateTime f_salida = get_fecha_salida();

                DateTime f_llegada_est = get_fecha_llegada_est();

                using (var conn = DataAccess.GetConnection())
                {

                    var cmd = new SqlCommand("[HAY_TABLA].sp_alta_viaje", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter fechaSalida = cmd.Parameters.Add("@f_salida", SqlDbType.DateTime);
                    SqlParameter fechaLlegadaEstimada = cmd.Parameters.Add("@f_llegada_est", SqlDbType.DateTime);
                    SqlParameter idAeronave = cmd.Parameters.Add("@id_aeronave", SqlDbType.Int);
                    SqlParameter idRuta = cmd.Parameters.Add("@id_ruta", SqlDbType.Int);



                    fechaSalida.Value = f_salida;
                
                    fechaLlegadaEstimada.Value = f_llegada_est;
                    idAeronave.Value = this.id_aeronave;
                    idRuta.Value = this.id_ruta_selec;



                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

              
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error en la creación del viaje. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conn.Close();
                        return;
                    }

                    MessageBox.Show("Se ha guardado correctamente el viaje", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   this.Close();
                }
            }

        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            if (validarComboVacio() && validarFechas())
            {
                
                this.id_tipo_ser_ruta = ((ComboboxItem)cbTipoServicio.SelectedItem).Value;
                cargarRutas();
            }
        }

        private Boolean validarFechas()
        {
            string str_error = "";

            if (fechaSalidaMenorActual())

            {

                
                str_error += "La fecha de salida no puede ser previa a la actual y en caso de ser la misma, debe tener una hora de diferencia\n";
            }
            if (fechaLLegadaEstimMenorFechaSalida())
            {
                str_error += "La fecha de llegada estimada no puede ser previa a la fecha de salida\n";
            }
            if (fechaLLegadaEstimMayor24hs())
            {
                str_error += "El tiempo estimado de viaje no puede ser mayor a 24 hs\n";
            }
            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private void cargarRutas()
        {
             int  id_tipo_ser_ruta = ((ComboboxItem)cbTipoServicio.SelectedItem).Value;

            using (var conn = DataAccess.GetConnection())
            {

                var cmd = new SqlCommand("[HAY_TABLA].sp_get_rutas_generar_viaje", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter tipoServicio = cmd.Parameters.Add("@idservicio", SqlDbType.Int);

                tipoServicio.Value = id_tipo_ser_ruta;
                try
                {
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();
                    int i = 0;

                    while (DR.Read())
                    {
                        rutas.Rows.Add();

                        rutas.Rows[i].Cells["id_ruta"].Value = DR[0].ToString();
                        rutas.Rows[i].Cells["codigo_ruta"].Value = DR[1].ToString();
                        rutas.Rows[i].Cells["ciudad_origen"].Value = DR[2].ToString();
                        rutas.Rows[i].Cells["ciudad_destino"].Value = DR[3].ToString();
                        rutas.Rows[i].Cells["idServicioRuta"].Value = DR[4].ToString();
                        rutas.Rows[i].Cells["tipo_servicio_ruta"].Value = DR[5].ToString();

                        i++;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (validarCombo1Vacio() && validarFechas())
            {
                
                this.id_tipo_ser_aer = ((ComboboxItem)cbTipoServicio1.SelectedItem).Value;
                cargarAeronave();
            }
        }

        private void cargarAeronave()
        {
            using (var conn = DataAccess.GetConnection())
            {

                var cmd = new SqlCommand("[HAY_TABLA].sp_get_aeronaves_generar_viaje", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter fechaSalida = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                SqlParameter id_tipo_servicio = cmd.Parameters.Add("@id_tipo_ser", SqlDbType.Int);

                fechaSalida.Value = get_fecha_salida();
                id_tipo_servicio.Value = ((ComboboxItem)cbTipoServicio1.SelectedItem).Value;

                try
                {
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();
                    int i = 0;

                    while (DR.Read())
                    {
                        aeronaves.Rows.Add();

                        aeronaves.Rows[i].Cells["id"].Value = DR[0].ToString();
                        aeronaves.Rows[i].Cells["modelo"].Value = DR[1].ToString();
                        aeronaves.Rows[i].Cells["matricula"].Value = DR[2].ToString();
                        aeronaves.Rows[i].Cells["fabricante"].Value = DR[3].ToString();
                        aeronaves.Rows[i].Cells["idServicioA"].Value = DR[4].ToString();
                        aeronaves.Rows[i].Cells["tipoServicio1"].Value = DR[5].ToString();

                        i++;
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
        private Boolean validarCombo1Vacio()
        {
            if (((ComboboxItem)cbTipoServicio1.SelectedItem) == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private Boolean validarComboVacio()
        {
            if (((ComboboxItem)cbTipoServicio.SelectedItem) == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
                return true ; 
        }


        private Boolean validaciones()
        {
            if (validarFechas())
            {
                String str_error = "";
                if (this.id_aeronave == 0)
                {
                    str_error += "Debe seleccionar una Aeronave\n";
                }
                if (this.id_ruta_selec == 0)
                {
                    str_error += "Debe seleccionar una Ruta\n";
                }
                if (this.id_tipo_ser_aer != 0 && this.id_tipo_ser_ruta != 0)
                {
                    if (id_tipo_ser_aer != id_tipo_ser_ruta)
                    {
                        str_error += "El tipo de servicio de la Ruta y Aeronave seleccionada deben ser iguales\n";
                    }
                }
                if (!str_error.Equals(""))
                {
                    MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return true;
                }


            } return false;
        }

        private void cbTipoServicio1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (validarCombo1Vacio() && validarFechas())
            {

                this.id_tipo_ser_aer = ((ComboboxItem)cbTipoServicio1.SelectedItem).Value;
                cargarAeronave();
            }
        }

        private void cbTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (validarComboVacio() && validarFechas())
            {

                this.id_tipo_ser_ruta = ((ComboboxItem)cbTipoServicio.SelectedItem).Value;
                cargarRutas();
            }
        }

    }
}
