using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public static class Usuario
    {
        private const String SP_GET_BY_ID = "[HAY_TABLA].sp_get_usuario_by_id";
        private const String SP_GET_BY_LOGIN = "[HAY_TABLA].sp_get_usuario_by_login";
        private const String SP_GET_INTENTOS = "[HAY_TABLA].sp_get_usuario_intentos";
        private const String SP_SET_INTENTOS = "[HAY_TABLA].sp_set_usuario_intentos";
        private const String SP_SET_STATUS = "[HAY_TABLA].sp_set_status_usuario";
        private const String SP_GET_ROLES = "[HAY_TABLA].sp_select_roles_de_usuario";


        public static DataTable GetByLogin(String username, String password)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_BY_LOGIN, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static DataTable GetIntentos(String username)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_INTENTOS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static void SetIntentos(String username, int intentos)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_SET_INTENTOS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@intentos", SqlDbType.Int).Value = intentos;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void SetStatus(String username, int status)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_SET_STATUS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@status", SqlDbType.Int).Value = status;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
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

        public static DataTable GetRoles(int id)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_ROLES, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }
    }
}
