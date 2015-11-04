using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Ruta
    {
        public Int32 Id { get; set; }
        public Int32 codRuta { get; set; }
        public Decimal precioBaseKG { get; set; }
        public Decimal precioBasePasaje { get; set; }

        public Boolean Estado { get; set; }
        public String ciudadOrigen { get; set; }
        public String ciudadDestino { get; set; }
        public String tipoServicio { get; set; }

        //public void Insertate()
        //{
        //    Validate();
        //    Ruta.Insertar(this);
        //}

        //public void Actualizate()
        //{
        //    Validate();
        //    Ruta.Actualizar(this);
        //}
        //public void Eliminate()
        //{
        //    Ruta.Eliminar(this);
        //}

        //private static void Insertar(Rol rol)
        //{
        //    SqlConnection con = null;
        //    SqlTransaction trans = null;
        //    try
        //    {

        //        con = Data.DataAccess.GetConnection();
        //        con.Open();
        //        trans = con.BeginTransaction();

        //        rol.Id = Data.Rol.Insertar(rol.Nombre, rol.Estado);

        //        foreach (var func in rol.Funcionalidades)
        //            Data.Funcionalidad.Insert(con, trans, rol.Id, func.Id);

        //        trans.Commit();
        //        con.Close();

        //    }
        //    catch (Exception)
        //    {
        //        if (trans != null)
        //            trans.Rollback();

        //        if (con != null)
        //            con.Close();

        //        throw;
        //    }
        //}

        //private static void Actualizar(Rol rol)
        //{
        //    SqlConnection con = null;
        //    SqlTransaction trans = null;
        //    try
        //    {

        //        con = Data.DataAccess.GetConnection();
        //        con.Open();
        //        trans = con.BeginTransaction();

        //        Data.Rol.Actualizar(rol.Id, rol.Nombre, rol.Estado);
        //        Data.Funcionalidad.Delete(con, trans, rol.Id);

        //        foreach (var func in rol.Funcionalidades)
        //            Data.Funcionalidad.Insert(con, trans, rol.Id, func.Id);

        //        trans.Commit();
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //            trans.Rollback();

        //        if (con != null)
        //            con.Close();

        //        throw;
        //    }
        //}

        //private static void Eliminar(Rol rol)
        //{
        //    Data.Rol.Eliminar(rol.Id);
        //}


        //private void Validate()
        //{
        //    if (Int32.Equals(this.precioBaseKG, null) 
        //        || Int32.Equals(this.precioBasePasaje, null) )
        //        throw new ArgumentException("El campo precio no puede estar vacio");
        //}

        public static DataTable Get(Int32? IdCiudadOrigen, Int32? IdCiudadDestino, Int32? IdTipoDeServicio)
        {
            return Data.Ruta.Get(IdCiudadOrigen, IdCiudadDestino, IdTipoDeServicio);
        }

        public static List<Ruta> Get(String nombreFiltro)
        {
            var dt = Data.Ruta.Get(nombreFiltro);
            var rutas = new List<Ruta>(dt.Rows.Count);
            Ruta ruta = null;

            foreach (DataRow row in dt.Rows)
            {
                ruta = new Ruta();
                ruta.Id = Int32.Parse(row["ID"].ToString());
                ruta.codRuta = Int32.Parse(row["CODIGO"].ToString());
                ruta.precioBaseKG = Decimal.Parse(row["PRECIOBASEKG"].ToString());
                ruta.precioBasePasaje = Decimal.Parse(row["PRECIOBASEPASAJE"].ToString());
                ruta.Estado = Boolean.Parse(row["STATUS"].ToString());
                ruta.ciudadOrigen = row["CO_NOMBRE"].ToString();
                ruta.ciudadDestino = row["CD_NOMBRE"].ToString();
//                ruta.tipoServicio = Int32.Parse(row["ID_SERVICIO"].ToString());

                rutas.Add(ruta);
            }

            dt.Dispose();

            return rutas;
        }

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

    }
}
