using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Ciudad
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Boolean Estado { get; set; }

        private const String SP_GET_CIUDADES = "[HAY_TABLA].sp_get_ciudades";
        private const String SP_INSERTAR_CIUDAD = "[HAY_TABLA].sp_insertar_ciudad";
        private const String SP_ELIMINAR_CIUDAD = "[HAY_TABLA].sp_eliminar_ciudad";

        public Ciudad() { }

        public Ciudad(Int32 id, String nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public static List<Ciudad> Get()
        {
            var cdades = new List<Ciudad>();

            using (var data = Data.Ciudad.Get())
            {
                foreach (DataRow row in data.Rows)
                    cdades.Add(new Ciudad(Int32.Parse(row["Id"].ToString()), row["Nombre"].ToString()));
            }

            return cdades;
        }

        public static DataTable cargarDGVCiudad()
        {
            //  Devuelve un DataTable cargado para luego asignarlo al DGVCiudades

            DataTable datosDT;

            using (var con = Data.DataAccess.GetConnection())
            {
                con.Open();
                DataTable dtDatos = new DataTable();
                SqlDataAdapter mdaDatos = new SqlDataAdapter(SP_GET_CIUDADES, con);

                mdaDatos.Fill(dtDatos);
                datosDT = dtDatos;
                con.Close();
            }

            return datosDT;
        }

        public static void insertarCiudad(string ciudadAlta)
        {
            using (var con = Data.DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_INSERTAR_CIUDAD, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = ciudadAlta;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void eliminarCiudad(int ciudadEliminar, DateTime fechaActual)
        {
            using (var con = Data.DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_ELIMINAR_CIUDAD, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ciudadEliminar;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}