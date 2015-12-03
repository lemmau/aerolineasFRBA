using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public static class Devolucion
    {

        private const String SP_GET_ITEMS = "[HAY_TABLA].sp_select_items";
        private const String SP_CANCELAR_PASAJE_ENCOMIENDA = "[HAY_TABLA].sp_cancelar_pasaje_encomienda";

        public static DataTable Get(Int32 idCompra, Int32 idPasaje, Int32 idEncomienda, DateTime fechaActual)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_ITEMS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idCompra", SqlDbType.Int).Value = idCompra;
                cmd.Parameters.Add("@idPasaje", SqlDbType.Int).Value = idPasaje;
                cmd.Parameters.Add("@idEncomienda", SqlDbType.Int).Value = idEncomienda;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }

        public static void CancelarPasajeEncomienda(Int32 idCompra, String tipo, Int32 idPasajeEncomienda, DateTime fechaActual, String motivo)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_CANCELAR_PASAJE_ENCOMIENDA, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idCompra", SqlDbType.Int).Value = idCompra;
                cmd.Parameters.Add("@tipoItem", SqlDbType.NVarChar).Value = tipo;
                cmd.Parameters.Add("@idPasajeEncomienda", SqlDbType.Int).Value = idPasajeEncomienda;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;
                cmd.Parameters.Add("@motivoDevolucion", SqlDbType.NVarChar).Value = motivo;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
