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
        private const String SP_GET_ALL = "[HAY_TABLA].sp_select_rutas";
        private const String SP_GET = "[HAY_TABLA].sp_select_ruta";
        private const String SP_GET_BY_ID = "[HAY_TABLA].sp_get_ruta_by_id";
        private const String SP_INSERT = "[HAY_TABLA].sp_insertar_ruta";
        private const String SP_UPDATE = "[HAY_TABLA].sp_modificacion_ruta";
        private const String SP_DELETE = "[HAY_TABLA].sp_baja_ruta";

        public static DataTable Get(Int32 id)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_BY_ID, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id ", SqlDbType.Int).Value = id;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }

        public static DataTable Get(String codRuta, Int32? idCiudadOrigen, Int32? idCiudadDestino, Int32? idTipoDeServicio)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_ALL, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!String.IsNullOrEmpty(codRuta))
                    cmd.Parameters.Add("@codRuta", SqlDbType.NVarChar).Value = codRuta;
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

        public static void Eliminar(int id)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_DELETE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static int Insertar(Int32 idCiudadOrigen, Int32 idCiudadDestino,
            Int32 idTipoServicio, Decimal precioBasePasaje, Decimal precioBaseKG, Boolean estado)
        {
            int id_insertado = -1;
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_INSERT, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idCiudadOrigen", SqlDbType.Int).Value = idCiudadOrigen;
                cmd.Parameters.Add("@idCiudadDestino", SqlDbType.Int).Value = idCiudadDestino;
                cmd.Parameters.Add("@idTipoServicio", SqlDbType.Int).Value = idTipoServicio;
                cmd.Parameters.Add("@precioBasePasaje", SqlDbType.Decimal).Value = precioBasePasaje;
                cmd.Parameters.Add("@precioBaseKG", SqlDbType.Decimal).Value = precioBaseKG;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = estado;

                con.Open();
                id_insertado = (int)cmd.ExecuteScalar();
                con.Close();
            }

            return id_insertado;
        }

        public static void Actualizar(int id, Int32 idCiudadOrigen, Int32 idCiudadDestino,
            Int32 idTipoServicio, Decimal precioBasePasaje, Decimal precioBaseKG, Boolean estado)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_UPDATE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@idCiudadOrigen", SqlDbType.Int).Value = idCiudadOrigen;
                cmd.Parameters.Add("@idCiudadDestino", SqlDbType.Int).Value = idCiudadDestino;
                cmd.Parameters.Add("@idTipoServicio", SqlDbType.Int).Value = idTipoServicio;
                cmd.Parameters.Add("@precioBasePasaje", SqlDbType.Decimal).Value = precioBasePasaje;
                cmd.Parameters.Add("@precioBaseKG", SqlDbType.Decimal).Value = precioBaseKG;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = estado;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
