using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public static class Millas
    {

        private const String SP_GET_DETALLE_MILLAS = "[HAY_TABLA].sp_listado_millas";
        private const String SP_GET_MILLAS_ACUMULADAS = "[HAY_TABLA].sp_get_millas_acumuladas";
        private const String SP_GET_DATOS_CLIE = "[HAY_TABLA].sp_get_datos_clie";

        public static Int32 GetMillasAcumuladas(Int32 id, DateTime fechaActual)
        {
            Int32 acumuladas = -1;

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_MILLAS_ACUMULADAS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    acumuladas = reader.GetInt32(0);
                }

                con.Close();
            }

            return acumuladas;
        }

        public static DataTable GetDatosClieByDNI(Int32 DNI)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_DATOS_CLIE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@DNI", SqlDbType.Int).Value = DNI;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }

        public static DataTable Get(Int32 id, DateTime fechaActual)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_DETALLE_MILLAS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }

    }
}
