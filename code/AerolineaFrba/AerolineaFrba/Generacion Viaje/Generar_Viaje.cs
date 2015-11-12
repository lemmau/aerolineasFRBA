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
        string tipo_servicio_aer;
        int id_ruta_selec = 0;

        int id_tipo_ser_ruta=0;
        int id_tipo_ser_aer=0;

        DateTime fecha_actual;

        public Generar_Viaje()
        {
            InitializeComponent();
        }

        private void Generar_Viaje_Load(object sender, EventArgs e)
        {
            fechaSalida.Format = DateTimePickerFormat.Time;
            fechaSalida.ShowUpDown = true;
            fechaLlegada.Format = DateTimePickerFormat.Time;
            fechaLlegada.ShowUpDown = true;
            fechaEst.Format = DateTimePickerFormat.Time;
            fechaEst.ShowUpDown = true;
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
                var cmd = new SqlCommand("HAY_TABLA.sp_get_tipo_servicio", conn);

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
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
            DateTime v_h_salida = fechaSalida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);

            DateTime v_f_llegada_estim = fechaEst1.Value;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(-v_f_llegada_estim.Hour);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(-v_f_llegada_estim.Minute);
            v_f_llegada_estim = v_f_llegada_estim.AddSeconds(-v_f_llegada_estim.Second);
            v_f_llegada_estim = v_f_llegada_estim.AddMilliseconds(-v_f_llegada_estim.Millisecond);
            DateTime v_h_llegada_estim = fechaEst.Value;
            int hora_llegada_estim = v_h_llegada_estim.Hour;
            int minutos_llegada_estim = v_h_llegada_estim.Minute;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(hora_llegada_estim);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(minutos_llegada_estim);

            if (v_f_llegada_estim <= v_f_salida)
                return true;

            return false;

        }

        private void fechaEst1_ValueChanged(object sender, EventArgs e)
        {
            String str_error = "";
            if (fechaLLegadaEstimMayor24hs())
                str_error += "El tiempo estimado de viaje no puede ser mayor a 24 hs\n";

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
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
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

            //le sumo 1 para que programen viajes posteriores a una hora. Es decir, si
            //son las 18hs no puedo programar un viaje para las 18hs
            this.fecha_actual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
            this.fecha_actual = this.fecha_actual.AddHours(DateTime.Now.Hour);
            this.fecha_actual = this.fecha_actual.AddHours(1);
            this.fecha_actual = this.fecha_actual.AddMinutes(DateTime.Now.Minute);

            DateTime v_f_salida = fechaSalida1.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
            DateTime v_h_salida = fechaSalida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);

            if (v_f_salida < this.fecha_actual)
                return true;

            return false;

        }



        private DateTime get_fecha_salida()
        {
            DateTime fecha = fechaSalida1.Value;
            fecha = fecha.AddHours(-fecha.Hour);
            fecha = fecha.AddMinutes(-fecha.Minute);
            fecha = fecha.AddMilliseconds(-fecha.Millisecond);

            DateTime fecha_h = fechaSalida.Value;
            int hora = fecha_h.Hour;
            int minuto = fecha_h.Minute;
            int segundo = fecha_h.Second;

            fecha = fecha.AddHours(hora);
            fecha = fecha.AddMinutes(minuto);
            fecha = fecha.AddSeconds(segundo);

            return fecha;

        }


        private DateTime get_fecha_llegada()
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



        }

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
                id_aeronave = Convert.ToInt32(aeronaves.Rows[e.RowIndex].Cells["id"].Value.ToString());
                tipo_servicio_aer = aeronaves.Rows[e.RowIndex].Cells["tipoServicio1"].Value.ToString();
                this.id_tipo_ser_aer = ((ComboboxItem)cbTipoServicio1.SelectedItem).Value;
                MessageBox.Show("Usted a seleccionado la Aeronave con ID " + id_aeronave.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }

        private void rutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( !e.RowIndex.Equals(-1))
            {
                this.id_ruta_selec = Convert.ToInt32(rutas.Rows[e.RowIndex].Cells["id_ruta"].Value.ToString());
                this.id_tipo_ser_ruta = ((ComboboxItem)cbTipoServicio.SelectedItem).Value;
                MessageBox.Show("Usted selecciono la ruta con ID :" + id_ruta_selec.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                DateTime f_llegada = get_fecha_llegada();

                DateTime f_llegada_est = get_fecha_llegada_est();

                using (var conn = DataAccess.GetConnection())
                {

                    var cmd = new SqlCommand("HAY_TABLA.sp_alta_viaje", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter fechaSalida = cmd.Parameters.Add("@f_salida", SqlDbType.DateTime);
                    SqlParameter fechaLlegada = cmd.Parameters.Add("@f_llegada", SqlDbType.DateTime);
                    SqlParameter fechaLlegadaEstimada = cmd.Parameters.Add("@f_llegada_est", SqlDbType.DateTime);
                    SqlParameter idAeronave = cmd.Parameters.Add("@id_aeronave", SqlDbType.Int);
                    SqlParameter idRuta = cmd.Parameters.Add("@id_ruta", SqlDbType.Int);

                    SqlParameter HAY_ERROR = cmd.Parameters.Add("@hayErr", SqlDbType.Int);
                    SqlParameter ERRORES = cmd.Parameters.Add("@errores", SqlDbType.VarChar, 200);



                    fechaSalida.Value = f_salida;
                    fechaLlegada.Value = f_llegada;
                    fechaLlegadaEstimada.Value = f_llegada_est;
                    idAeronave.Value = this.id_aeronave;
                    idRuta.Value = this.id_ruta_selec;
                    HAY_ERROR.Direction = ParameterDirection.Output;
                    ERRORES.Direction = ParameterDirection.Output;


                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        int hayError = Convert.ToInt16(cmd.Parameters["@hayErr"].Value.ToString());
                        if (hayError == 1)
                        {
                            string errores = cmd.Parameters["@errores"].Value.ToString();
                            MessageBox.Show("Error: \n" + errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            conn.Close();
                            return;
                        }
                        MessageBox.Show("El Viaje ha sido dado de alta", "", MessageBoxButtons.OK);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error en la creación del viaje. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conn.Close();
                        return;
                    }

                    Generar_Viaje.ActiveForm.Close();

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
            String tipo_ser_ruta = cbTipoServicio.Text;

            using (var conn = DataAccess.GetConnection())
            {

                var cmd = new SqlCommand("HAY_TABLA.sp_get_rutas_generar_viaje", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter tipoServicio = cmd.Parameters.Add("@servicio", SqlDbType.VarChar);

                tipoServicio.Value = tipo_ser_ruta;
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
                        rutas.Rows[i].Cells["tipo_servicio_ruta"].Value = DR[4].ToString();

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

                var cmd = new SqlCommand("HAY_TABLA.sp_get_aeronaves_generar_viaje", conn);

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
                        aeronaves.Rows[i].Cells["tipoServicio1"].Value = DR[4].ToString();

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
                    str_error += "Debe seleccionar una Aeronave";
                }
                if (this.id_ruta_selec == 0)
                {
                    str_error += "Debe seleccionar una Ruta";
                }
                if (this.id_tipo_ser_aer != 0 && this.id_tipo_ser_ruta != 0)
                {
                    if (id_tipo_ser_aer != id_tipo_ser_ruta)
                    {
                        str_error += "El tipo de servicio de la Ruta y Aeronave seleccionada deben ser iguales ";
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

    }
}
