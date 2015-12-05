using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public static class Canje
    {

        private const String SP_GET_DATOS_CLIE = "[HAY_TABLA].sp_get_datos_clie";
        private const String SP_GET_MILLAS_ACUMULADAS = "[HAY_TABLA].sp_get_millas_acumuladas";
        private const String SP_GET_CANJES_POSIBLES = "[HAY_TABLA].sp_get_canjes_posibles";
        private const String SP_CONFIRMAR_CANJE = "[HAY_TABLA].sp_confirmar_canje";

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

        public static DataTable Get(Int32 acumuladas)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_CANJES_POSIBLES, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@acumuladas", SqlDbType.Int).Value = acumuladas;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }

        public static void ConfirmarCanje(Int32 idProducto, Int32 cantidad, Int32 dni, Int32 acumuladas, DateTime fechaActual)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_CONFIRMAR_CANJE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                cmd.Parameters.Add("@acumuladas", SqlDbType.Int).Value = acumuladas;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



    }
}
