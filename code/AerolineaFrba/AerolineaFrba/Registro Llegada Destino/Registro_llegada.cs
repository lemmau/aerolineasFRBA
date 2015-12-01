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

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class Registro_llegada : Form
    {

        DateTime fechaSis = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);

        Boolean existe_matricula = false;
        public Registro_llegada()
        {
            InitializeComponent();
            fechaSis = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
            fechaSis = fechaSis.AddHours(00);
            fechaSis = fechaSis.AddMinutes(00);
            fechaSis = fechaSis.AddSeconds(00);
            cargarCombosCiudad();
            f_llegada.Value = fechaSis;
            h_llegada.Format = DateTimePickerFormat.Time;

            h_llegada.ShowUpDown = true;
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
        public void cargarCombosCiudad()
        {

            using (var conn = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("HAY_TABLA.sp_get_ciudades", conn);

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

                        cbCiudadOrigen.Items.Add(item);
                        cbCiudadDestino.Items.Add(item);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Registro_llegada.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (validar())
            {
                using (var conn = DataAccess.GetConnection())
                {
                    var cmd = new SqlCommand("HAY_TABLA.sp_alta_registro_llegada", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter matricula = cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                    SqlParameter fechaLlegada = cmd.Parameters.Add("@f_llegada", SqlDbType.DateTime);
                    SqlParameter idCiudadOrigen = cmd.Parameters.Add("@id_ciudad_origen", SqlDbType.Int);
                    SqlParameter idCiudadDestino = cmd.Parameters.Add("@id_ciudad_destino", SqlDbType.Int);

                    SqlParameter fechaActual = cmd.Parameters.Add("@f_actual", SqlDbType.DateTime);

                    SqlParameter HAY_ERROR = cmd.Parameters.Add("@hayErr", SqlDbType.Int);
                    SqlParameter ERRORES = cmd.Parameters.Add("@errores", SqlDbType.VarChar, 200);


                    matricula.Value = lbMatricula.Text;
                    fechaActual.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaDelSistema"]);
                    fechaLlegada.Value = getfecha();
                    idCiudadOrigen.Value = ((ComboboxItem)cbCiudadOrigen.SelectedItem).Value;
                    idCiudadDestino.Value = ((ComboboxItem)cbCiudadDestino.SelectedItem).Value;
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

                        if (hayError == 2)
                        {
                            string errores = cmd.Parameters["@errores"].Value.ToString();
                            MessageBox.Show("Atención: \n" + errores + "\n" + "Se ha registrado de llegada de la Aeronave: " + lbMatricula.Text, "", MessageBoxButtons.OK);

                            conn.Close();

                        }
                        else
                        {
                            MessageBox.Show("Se ha registrado de llegada de la Aeronave: " + lbMatricula.Text, "", MessageBoxButtons.OK);
                            conn.Close();
                        }

                    }

                    catch (Exception error)
                    {
                        MessageBox.Show("Error  en el registro de llegada " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conn.Close();
                        return;

                    }
                    this.Close();
                }

            }



        }





        private Boolean validar()
        {
            string str_error = "";

            if (lbMatricula.Text.Trim().Equals(""))
                str_error = str_error + "Debe ingresar la matricua de la aeronave .\n";

            if (((ComboboxItem)cbCiudadOrigen.SelectedItem) == null || ((ComboboxItem)cbCiudadDestino.SelectedItem) == null)
                str_error = "Debe seleccionar las ciudades Origen y Destino.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }




        }

        private DateTime getfecha()
        {

            DateTime fechaLlegada = f_llegada.Value;
            fechaLlegada = fechaLlegada.AddHours(-fechaLlegada.Hour);
            fechaLlegada = fechaLlegada.AddMinutes(-fechaLlegada.Minute);
            fechaLlegada = fechaLlegada.AddSeconds(-fechaLlegada.Second);

            DateTime h_fecha = h_llegada.Value;
            fechaLlegada = fechaLlegada.AddHours(h_fecha.Hour);
            fechaLlegada = fechaLlegada.AddMinutes(h_fecha.Minute);
            fechaLlegada = fechaLlegada.AddSeconds(h_fecha.Second);

            return fechaLlegada;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
            existe_matricula = false;
            using (var conn = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("HAY_TABLA.sp_aeronave_x_matricula", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter matricula = cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                matricula.Value = lbMatricula.Text;
                SqlParameter HAY_ERROR = cmd.Parameters.Add("@hayErr", SqlDbType.Int);
                SqlParameter ERRORES = cmd.Parameters.Add("@errores", SqlDbType.VarChar, 200);
                HAY_ERROR.Direction = ParameterDirection.Output;
                ERRORES.Direction = ParameterDirection.Output;

                try
                {

                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();

                    

                    
                        while (DR.Read())
                        {

                            int b_id = DR.GetInt32(0);

                            string b_modelo = DR.GetString(1);
                            string b_fabricante = DR.GetString(2);
                            string b_tipo_servicio = DR.GetString(3);
                            existe_matricula = true;

                            textBox1.Text = b_modelo;
                            textBox2.Text = b_fabricante;
                            textBox3.Text = b_tipo_servicio;

                            existe_matricula = true;

                        }

                        if (!existe_matricula)
                        {
                            int hayError = Convert.ToInt16(cmd.Parameters["@hayErr"].Value.ToString());
                            if (hayError == 1)
                            {
                                string errores = cmd.Parameters["@errores"].Value.ToString();
                                MessageBox.Show("Error: \n" + errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                conn.Close();
                                return;
                            }

                        }
                    conn.Close();


                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }




            }
        }







    }
}
