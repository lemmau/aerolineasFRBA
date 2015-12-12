using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public sealed class Ruta
    {
        public Int32 Id { get; set; }
        public Int32 codRuta { get; set; }
        public Decimal precioBaseKG { get; set; }
        public Decimal precioBasePasaje { get; set; }

        public Boolean Estado { get; set; }
        public Ciudad ciudadOrigen { get; set; }
        public Ciudad ciudadDestino { get; set; }
        public TipoServicio tipoServicio { get; set; }

        public Ruta()
        {
            ciudadOrigen = new Ciudad();
            ciudadDestino = new Ciudad();
            tipoServicio = new TipoServicio();
        }

        public void Insertate()
        {
            Validate();
            Ruta.Insertar(this);
        }

        public void Actualizate()
        {
            Validate();
            Ruta.Actualizar(this);
        }

        public void Eliminate()
        {
            Ruta.Eliminar(this);
        }

        private static void Insertar(Ruta ruta)
        {
            SqlConnection con = null;
            SqlTransaction trans = null;
            try
            {
                con = Data.DataAccess.GetConnection();
                con.Open();
                trans = con.BeginTransaction();

                ruta.codRuta = Data.Ruta.Insertar(ruta.ciudadOrigen.Id, ruta.ciudadDestino.Id, 
                      ruta.tipoServicio.Id, ruta.precioBasePasaje, ruta.precioBaseKG);

                trans.Commit();
                con.Close();
            }
            catch (Exception)
            {
                if (trans != null)
                    trans.Rollback();

                if (con != null)
                    con.Close();

                throw;
            }
        }

        private static void Actualizar(Ruta ruta)
        {
            SqlConnection con = null;
            SqlTransaction trans = null;
            try
            {
                con = Data.DataAccess.GetConnection();
                con.Open();
                trans = con.BeginTransaction();

                Data.Ruta.Actualizar(ruta.Id, ruta.ciudadOrigen.Id, ruta.ciudadDestino.Id,
                      ruta.tipoServicio.Id, ruta.precioBasePasaje, ruta.precioBaseKG, ruta.Estado);

                trans.Commit();
                con.Close();

            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();

                if (con != null)
                    con.Close();

                throw;
            }
        }

        private static void Eliminar(Ruta ruta)
        {
            Data.Ruta.Eliminar(ruta.Id);
        }


        private void Validate()
        {
            if (Int32.Equals(this.precioBaseKG, null)
                || Int32.Equals(this.precioBasePasaje, null))
                throw new ArgumentException("El campo precio no puede estar vacio");
        }

        public static Ruta Get(Int32 id)
        {
            var dt = Data.Ruta.Get(id);

            return CrearRuta(dt.Rows[0]);
        }

        public static DataTable Get(String CodRuta, Int32? IdCiudadOrigen, Int32? IdCiudadDestino, Int32? IdTipoDeServicio)
        {
            return Data.Ruta.Get(CodRuta, IdCiudadOrigen, IdCiudadDestino, IdTipoDeServicio);
        }

//        public static List<Ruta> Get(String nombreFiltro)
//        {
//            var dt = Data.Ruta.Get(nombreFiltro);
//            var rutas = new List<Ruta>(dt.Rows.Count);
//            Ruta ruta = null;

//            foreach (DataRow row in dt.Rows)
//            {
//                ruta = new Ruta();
//                ruta.Id = Int32.Parse(row["ID"].ToString());
//                ruta.codRuta = Int32.Parse(row["CODIGO"].ToString());
//                ruta.precioBaseKG = Decimal.Parse(row["PRECIOBASEKG"].ToString());
//                ruta.precioBasePasaje = Decimal.Parse(row["PRECIOBASEPASAJE"].ToString());
//                ruta.Estado = Boolean.Parse(row["STATUS"].ToString());
//                ruta.ciudadOrigen = row["CO_NOMBRE"].ToString();
//                ruta.ciudadDestino = row["CD_NOMBRE"].ToString();
////                ruta.tipoServicio = Int32.Parse(row["ID_SERVICIO"].ToString());

//                rutas.Add(ruta);
//            }

//            dt.Dispose();

//            return rutas;
//        }

        public static Ruta GetById(Int32 id)
        {
            var ruta = new Ruta();

            using (var data = Data.Ruta.GetById(id))
            {
                ruta.Id = Int32.Parse(data.Rows[0][data.Columns["Id"].Ordinal].ToString());
                ruta.codRuta = Int32.Parse(data.Rows[0][data.Columns["codRuta"].Ordinal].ToString());
                ruta.Estado = Boolean.Parse(data.Rows[0][data.Columns["Status"].Ordinal].ToString());

            }

            return ruta;
        }

        private static Ruta CrearRuta(DataRow row)
        {
            var ruta = new Ruta();

            ruta.Id = Int32.Parse(row["Id"].ToString());
            ruta.ciudadOrigen = new Ciudad(Int32.Parse(row["CO_ID"].ToString()), row["CO_NOMBRE"].ToString());
            ruta.ciudadDestino = new Ciudad(Int32.Parse(row["CD_ID"].ToString()), row["CD_NOMBRE"].ToString());
            ruta.precioBasePasaje = Decimal.Parse(row["preciobasepasaje"].ToString());
            ruta.precioBaseKG = Decimal.Parse(row["preciobasekg"].ToString());
            ruta.tipoServicio = new TipoServicio(Int32.Parse(row["S_ID"].ToString()), row["S_NOMBRE"].ToString());

            if ("Si" == row["STATUS"].ToString())
            {
                ruta.Estado = true;
            }
            else if ("No" == row["STATUS"].ToString())
            {
                ruta.Estado = false;
            }
            else
                ruta.Estado = Boolean.Parse(row["STATUS"].ToString());

            return ruta;
        }

        public static Int32 ChequearVuelosProgramados(Int32 idRutaBaja, DateTime fechaActual)
        {
            return Data.Ruta.ChequearVuelosProgramados(idRutaBaja, fechaActual);
        }

        public static DataTable BajaRutaYBuscaVuelosProgramados(Int32 idRutaBaja, DateTime fechaActual)
        {
            return Data.Ruta.BajaRutaYBuscaVuelosProgramados(idRutaBaja, fechaActual);
        }
    }
}
