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
        private const String SP_INSERT = "[HAY_TABLA].sp_insertar_aeronave";
        private const String SP_UPDATE = "[HAY_TABLA].sp_modificar_aeronave";
        private const String SP_DELETE_VIDA_UTIL = "[HAY_TABLA].sp_baja_vida_util";
        private const String SP_DELETE_FUERA_DE_SERVICIO = "[HAY_TABLA].sp_baja_fuera_de_servicio";
        private const String SP_VUELOS_PROGRAMADOS = "[HAY_TABLA].sp_chequear_vuelos_programados";
        private const String SP_DELETE_Y_BUSCA_PROGRAMADOS = "[HAY_TABLA].sp_baja_y_busca_vuelos_programados";
        private const String SP_CANCELA_PROGRAMADO_Y_BUSCA_ITEMS = "[HAY_TABLA].sp_cancela_vuelo_programado_y_busca_items_a_cancelar";
        private const String SP_BUSCA_PROGRAMADOS = "[HAY_TABLA].sp_busca_vuelos_programados";
        private const String SP_BUSCA_POSIBLES_REEMPLAZOS = "[HAY_TABLA].sp_busca_posibles_reemplazos";
        private const String SP_SATISFACE_VUELO = "[HAY_TABLA].sp_puede_satisfacer_vuelo";
        private const String SP_TRANSFERIR_PROGRAMADO_Y_BUSCA_ITEMS = "[HAY_TABLA].sp_transferir_programado_y_busca_items";
        private const String SP_TRANSFERIR_PASAJE_ENCOMIENDA = "[HAY_TABLA].sp_transferir_pasaje_encomienda";

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
            Int32 espacioKG, Int32 cantPasillo, Int32 cantVentanilla, Int32 idTipoServicio)
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
                cmd.Parameters.Add("@idTipoServicio", SqlDbType.Int).Value = idTipoServicio;
                cmd.Parameters.Add("@cantButacasPasillo", SqlDbType.Int).Value = cantPasillo;
                cmd.Parameters.Add("@cantButacasVentanilla", SqlDbType.Int).Value = cantVentanilla;

                con.Open();
                id_insertado = (int)cmd.ExecuteScalar();
                con.Close();
            }

            return id_insertado;
        }

        public static void Actualizar(DateTime fechaAlta, Int32 id, String fabricante, String modelo, String matricula,
            Int32 espacioKG, Int32 cantPasillo, Int32 cantVentanilla, Int32 idTipoServicio, String matriculaAnterior)
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
                cmd.Parameters.Add("@idTipoServicio", SqlDbType.Int).Value = idTipoServicio;
                cmd.Parameters.Add("@cantButacasPasillo", SqlDbType.Int).Value = cantPasillo;
                cmd.Parameters.Add("@cantButacasVentanilla", SqlDbType.Int).Value = cantVentanilla;
                cmd.Parameters.Add("@matriculaAnterior", SqlDbType.NVarChar).Value = matriculaAnterior;

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

        ///////  AGREGADO PARA CANCELAR AERONAVE Y VUELOS

        public static Int32 ChequearVuelosProgramados(int id, DateTime fechaActual, DateTime fechaReincorporacion, Int32 tipoBaja)
        {
            Int32 respuesta = -1;

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_VUELOS_PROGRAMADOS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;
                cmd.Parameters.Add("@fechaReincorporacion", SqlDbType.DateTime).Value = fechaReincorporacion;
                cmd.Parameters.Add("@tipoBaja", SqlDbType.Int).Value = tipoBaja;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = reader.GetInt32(0);
                }

                con.Close();
            }

            return respuesta;
        }

        public static DataTable BajaAeronaveYBuscaVuelosProgramados(Int32 id, DateTime fechaActual, DateTime fechaReincorporacion, Int32 tipoBaja)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_DELETE_Y_BUSCA_PROGRAMADOS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;
                cmd.Parameters.Add("@fechaReincorporacion", SqlDbType.DateTime).Value = fechaReincorporacion;
                cmd.Parameters.Add("@tipoBaja", SqlDbType.Int).Value = tipoBaja;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static DataTable CancelarVueloProgramadoYBuscaItemsACancear(Int32 idVuelo)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_CANCELA_PROGRAMADO_Y_BUSCA_ITEMS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idVuelo", SqlDbType.Int).Value = idVuelo;
                
                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        ///////  AGREGADO PARA REEMPLAZAR AERONAVE Y VUELOS

        public static DataTable BuscaVuelosProgramados(Int32 id, DateTime fechaActual, DateTime fechaReincorporacion, Int32 tipoBaja)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_BUSCA_PROGRAMADOS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = fechaActual;
                cmd.Parameters.Add("@fechaReincorporacion", SqlDbType.DateTime).Value = fechaReincorporacion;
                cmd.Parameters.Add("@tipoBaja", SqlDbType.Int).Value = tipoBaja;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static DataTable BuscaPosiblesReemplazos(Int32 id, /*Int32? idTipoServicio, */String modelo, String fabricante)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_BUSCA_POSIBLES_REEMPLAZOS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idAeronaveAReemplazar", SqlDbType.Int).Value = id;
                /*cmd.Parameters.Add("@tipoServicio", SqlDbType.Int).Value = idTipoServicio;*/
                cmd.Parameters.Add("@modelo", SqlDbType.NVarChar).Value = modelo;
                cmd.Parameters.Add("@fabricante", SqlDbType.NVarChar).Value = fabricante;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static Int32 PuedeSatisfacerVuelo(Int32 idAeronaveAReemplazar, Int32 idPosibleReemplazo, Int32 idViaje)
        {
            Int32 respuesta = 0;

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_SATISFACE_VUELO, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idAeronaveAReemplazar", SqlDbType.Int).Value = idAeronaveAReemplazar;
                cmd.Parameters.Add("@idPosibleReemplazo", SqlDbType.Int).Value = idPosibleReemplazo;
                cmd.Parameters.Add("@idViaje", SqlDbType.Int).Value = idViaje;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = reader.GetInt32(0);
                }

                con.Close();
            }

            return respuesta;
        }

        public static DataTable TransferirVueloProgramadoYBuscaItemsATransferir(Int32 idAeronaveLocal, Int32 idPosibleReemplazo, Int32 idVuelo)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_TRANSFERIR_PROGRAMADO_Y_BUSCA_ITEMS, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idAeronaveAReemplazar", SqlDbType.Int).Value = idAeronaveLocal;
                cmd.Parameters.Add("@idPosibleReemplazo", SqlDbType.Int).Value = idPosibleReemplazo;
                cmd.Parameters.Add("@idVuelo", SqlDbType.Int).Value = idVuelo;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static void TransferirPasajeEncomienda(Int32 idPasajeEncomienda, String tipoItem, Int32 idPosibleReemplazo)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_TRANSFERIR_PASAJE_ENCOMIENDA, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idPasajeEncomienda", SqlDbType.Int).Value = idPasajeEncomienda;
                cmd.Parameters.Add("@tipoItem", SqlDbType.NVarChar).Value = tipoItem;
                cmd.Parameters.Add("@idPosibleReemplazo", SqlDbType.Int).Value = idPosibleReemplazo;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
       
    }
}
