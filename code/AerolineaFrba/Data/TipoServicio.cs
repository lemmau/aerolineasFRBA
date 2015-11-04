using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{

    public sealed class TipoServicio
    {
        private const String SP_GET = "[HAY_TABLA].sp_select_tipos_de_servicio";

        public static DataTable Get()
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET, con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }
    }
}
