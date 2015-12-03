using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public sealed class ListadoEstadistico
    {

        public static DataTable Get(Int32 numeroListado, DateTime desde, DateTime hasta)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand("[HAY_TABLA].sp_get_listado_" + numeroListado.ToString(), con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = desde;
                cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = hasta;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

    }
}
