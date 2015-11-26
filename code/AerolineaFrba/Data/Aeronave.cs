using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public static class Aeronave
    {

        private const String SP_GET_BY_ID = "[HAY_TABLA].sp_get_aeronave_by_id";
        //para cargar el cbbox fabricantes
        private const String SP_GET_FABRICANTES = "[HAY_TABLA].sp_get_fabricantes";
        //traer aeronaves por filtro de busqueda
        private const String SP_GET_ALL = "[HAY_TABLA].sp_select_aeronaves";
        //inserta una aeronave
        private const String SP_INSERT = "[HAY_TABLA].sp_insertar_aeronave";
        //modificar una aeronave
        private const String SP_UPDATE = "[HAY_TABLA].sp_modificar_aeronave";
        private const String SP_DELETE_VIDA_UTIL = "[HAY_TABLA].sp_baja_vida_util";
        private const String SP_DELETE_FUERA_DE_SERVICIO = "[HAY_TABLA].sp_baja_fuera_de_servicio";


        public static DataTable Get(String Matricula, Int32? IdTipoDeServicioSeleccionado, String FabricanteSeleccionado)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_ALL, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!String.IsNullOrEmpty(Matricula))
                    cmd.Parameters.Add("@matricula", SqlDbType.NVarChar).Value = Matricula;
                if (IdTipoDeServicioSeleccionado.HasValue)
                    cmd.Parameters.Add("@idTipoDeServicio", SqlDbType.Int).Value = IdTipoDeServicioSeleccionado;
                if (!String.IsNullOrEmpty(FabricanteSeleccionado))
                    cmd.Parameters.Add("@fabricante", SqlDbType.NVarChar).Value = FabricanteSeleccionado;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }

        public static DataTable cargarCBFabricantes()
        {
            DataTable datosDT;

            using (var con = Data.DataAccess.GetConnection())
            {
                con.Open();
                DataTable dtDatos = new DataTable();
                SqlDataAdapter mdaDatos = new SqlDataAdapter(SP_GET_FABRICANTES, con);

                mdaDatos.Fill(dtDatos);
                datosDT = dtDatos;
                con.Close();
            }
            return datosDT;
        }

        /*
                aeronave.fabricante = tbFabricante.Text;
                aeronave.modelo = tbModelo.Text;
                aeronave.matricula = tbMatricula.Text;
                aeronave.espacioKG = Int32.Parse(tbKG.Text);
                aeronave.cantButacas = Int32.Parse(tbButacasPasillo.Text); //ver hacer pasillo
                aeronave.cantButacas = Int32.Parse(tbButacasVentanilla.Text); //ver hacer ventanilla
                aeronave.tipoServicio.Id = IdTipoDeServicioSeleccionado.Value;
        */

        public static int Insertar(DateTime fechaAlta, String fabricante, String modelo, String matricula,
            Int32 espacioKG, Int32 cantButacas, Int32 idTipoServicio, Int32 cantPasillo, Int32 cantVentanilla)
        {
            int id_insertado = -1;
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_INSERT, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fechaAlta", SqlDbType.DateTime).Value = fechaAlta;
                cmd.Parameters.Add("@fabricante", SqlDbType.NVarChar).Value = fabricante;
                cmd.Parameters.Add("@modelo", SqlDbType.NVarChar).Value = modelo;
                cmd.Parameters.Add("@matricula", SqlDbType.NVarChar).Value = matricula;
                cmd.Parameters.Add("@espacioKG", SqlDbType.Int).Value = espacioKG;
                cmd.Parameters.Add("@cantButacas", SqlDbType.Int).Value = cantButacas;
                cmd.Parameters.Add("@idTipoServicio", SqlDbType.Int).Value = idTipoServicio;
                cmd.Parameters.Add("@cantPasillo", SqlDbType.Int).Value = cantPasillo;
                cmd.Parameters.Add("@cantVentanilla", SqlDbType.Int).Value = cantVentanilla;

                con.Open();
                id_insertado = (int)cmd.ExecuteScalar();
                con.Close();
            }

            return id_insertado;
        }

        public static void Actualizar(DateTime fechaAlta, Int32 id, String fabricante, String modelo, String matricula,
            Int32 espacioKG, Int32 cantButacas, Int32 idTipoServicio, Int32 cantPasillo, Int32 cantVentanilla)
        {
             using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_UPDATE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fechaAlta", SqlDbType.DateTime).Value = fechaAlta;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fabricante", SqlDbType.NVarChar).Value = fabricante;
                cmd.Parameters.Add("@modelo", SqlDbType.NVarChar).Value = modelo;
                cmd.Parameters.Add("@matricula", SqlDbType.NVarChar).Value = matricula;
                cmd.Parameters.Add("@espacioKG", SqlDbType.Int).Value = espacioKG;
                cmd.Parameters.Add("@cantButacas", SqlDbType.Int).Value = cantButacas;
                cmd.Parameters.Add("@idTipoServicio", SqlDbType.Int).Value = idTipoServicio;
                cmd.Parameters.Add("@cantPasillo", SqlDbType.Int).Value = cantPasillo;
                cmd.Parameters.Add("@cantVentanilla", SqlDbType.Int).Value = cantVentanilla;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static DataTable GetById(Int32 id)
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

        public static void BajaVidaUtil(int id, DateTime fechaActual)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_DELETE_VIDA_UTIL, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void BajaFueraDeServicio(int id, DateTime fechaActual, DateTime fechaReincorporacion)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_DELETE_FUERA_DE_SERVICIO, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;
                cmd.Parameters.Add("@fechaReincorporacion", SqlDbType.DateTime).Value = fechaReincorporacion;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
