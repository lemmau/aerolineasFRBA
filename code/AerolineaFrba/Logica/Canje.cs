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
    public class Canje
    {
        public Int32 id { get; set; }
        public String producto { get; set; }
        public Int32 millasNecesarias { get; set; }
        public Int32 millasAcumuladas { get; set; }

        public static DataTable GetDatosClieByDNI(Int32 DNI)
        {
            return Data.Canje.GetDatosClieByDNI(DNI);
        }

        public static Int32 GetMillasAcumuladas(Int32 id, DateTime fechaActual)
        {
            return Data.Canje.GetMillasAcumuladas(id, fechaActual);
        }

        public static List<Canje> Get(Int32 acumuladas)
        {

            var dt = Data.Canje.Get(acumuladas);
            var canjes = new List<Canje>(dt.Rows.Count);
            Canje canje = null;

            foreach (DataRow row in dt.Rows)
            {
                canje = new Canje();
                canje.id = Int32.Parse(row["id"].ToString());
                canje.producto = row["producto"].ToString();
                canje.millasNecesarias = Int32.Parse(row["millasNecesarias"].ToString());

                canjes.Add(canje);
            }

            dt.Dispose();

            return canjes;
        }

        public static void ConfirmarCanje(Int32 idProducto, Int32 cantidad, Int32 dni, Int32 acumuladas, DateTime fechaActual)
        {
            Data.Canje.ConfirmarCanje(idProducto, cantidad, dni, acumuladas, fechaActual);
        }
    }
}
