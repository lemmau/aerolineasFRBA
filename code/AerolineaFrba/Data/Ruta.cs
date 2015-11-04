using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public static class Ruta
    {
        private const String SP_GET_BY_NAME = "[HAY_TABLA].sp_select_rutas_con_ciudadOrigen";
        private const String SP_GET = "[HAY_TABLA].sp_select_rutas";
        private const String SP_GET_BY_ID = "[HAY_TABLA].sp_get_ruta_by_id";


        public static DataTable Get(Int32? idCiudadOrigen, Int32? idCiudadDestino, Int32? idTipoDeServicio)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (idCiudadOrigen.HasValue)
                    cmd.Parameters.Add("@idCiudadOrigen", SqlDbType.Decimal).Value = idCiudadOrigen;
                if (idCiudadDestino.HasValue)
                    cmd.Parameters.Add("@idCiudadDestino", SqlDbType.Decimal).Value = idCiudadDestino;
                if (idTipoDeServicio.HasValue)
                    cmd.Parameters.Add("@idTipoDeServicio", SqlDbType.Int).Value = idTipoDeServicio;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static DataTable GetById(int id)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_BY_ID, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static DataTable Get(String nombreFiltro)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_BY_NAME, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (String.IsNullOrEmpty(nombreFiltro))
                    cmd.Parameters.Add("@cdadOrigen", SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@cdadOrigen", SqlDbType.NVarChar).Value = nombreFiltro;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }
    }
}
