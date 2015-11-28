using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data;

namespace Logica
{
    public class Millas
    {
        public Int32 millas { get; set; }
        public DateTime fecha { get; set; }
        public String detalle { get; set; }

        public static Int32 GetMillasAcumuladas(Int32 id, DateTime fechaActual)
        {
            return Data.Millas.GetMillasAcumuladas(id, fechaActual);
        }

        public static DataTable GetDatosClieByDNI(Int32 DNI)
        {
            return Data.Millas.GetDatosClieByDNI(DNI);
        }

        public static List<Millas> Get(Int32 id, DateTime fechaActual)
        {

            var dt = Data.Millas.Get(id, fechaActual);
            var millas = new List<Millas>(dt.Rows.Count);
            Millas milla = null;

            foreach (DataRow row in dt.Rows)
            {
                milla = new Millas();
                milla.millas = Int32.Parse(row["millas"].ToString());
                milla.fecha = DateTime.Parse(row["fecha"].ToString());
                milla.detalle = row["detalle"].ToString();

                millas.Add(milla);
            }

            dt.Dispose();

            return millas;
        }

    }
}
