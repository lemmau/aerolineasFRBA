using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Viaje
    {
        private const String SP_GET_VIAJE= "[HAY_TABLA].sp_get_buscar_viaje";


        public static DataTable Get(DateTime f_salida , int idCiudadOrigen , int idCiudadDestino )
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_VIAJE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!String.IsNullOrEmpty(f_salida.ToString()))
                    cmd.Parameters.Add("@f_salida", SqlDbType.NVarChar).Value = f_salida;
                if (idCiudadOrigen != 0)
                    cmd.Parameters.Add("@idCiudadOrigen", SqlDbType.Int).Value = idCiudadOrigen;
                if (idCiudadDestino != 0)
                    cmd.Parameters.Add("@idCiudadDestino", SqlDbType.Int).Value = idCiudadDestino;
                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }
    }
}
