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
    public class Devolucion
    {

        public Int32 idCompra { get; set; }
        public String tipo { get; set; }
        public Int32 idPasajeEncomienda { get; set; }
        public Int32 idEncomienda { get; set; }
        public DateTime fechaCompra { get; set; }
        public String nombreCompleto { get; set; }

        public static int validarIngresos(String idCompra, String idPasaje, String idEncomienda)
        {
            Int32 idCompraNum;
            Int32 idPasajeNum;
            Int32 idEncomiendaNum;
            int mensaje = 0;

            if ((idCompra == "") && (idPasaje == "") && (idEncomienda == ""))
            {
                //Ningun filtro ingresado
                mensaje = 1;
            }
            else
            {
                try
                {
                    if (!(idCompra == ""))
                    {
                        idCompraNum = Int32.Parse(idCompra);
                    }
                    if (!(idPasaje == ""))
                    {
                        idPasajeNum = Int32.Parse(idPasaje);
                    }
                    if (!(idEncomienda == ""))
                    {
                        idEncomiendaNum = Int32.Parse(idEncomienda);
                    }
                }
                catch (Exception ex)
                {
                    //Algun campo numerico tiene un valor incorrecto
                    mensaje = 2;
                }
            }
            return mensaje;
        }

        public static List<Devolucion> Get(Int32 idCompra, Int32 idPasaje, Int32 idEncomienda, DateTime fechaActual)
        {
            var dt = Data.Devolucion.Get(idCompra, idPasaje, idEncomienda, fechaActual);
            var items = new List<Devolucion>(dt.Rows.Count);
            Devolucion item = null;

            foreach (DataRow row in dt.Rows)
            {
                item = new Devolucion();
                item.idCompra = Int32.Parse(row["idCompra"].ToString());
                item.tipo = row["tipo"].ToString();
                item.idPasajeEncomienda = Int32.Parse(row["idPasajeEncomienda"].ToString());
                item.fechaCompra = DateTime.Parse(row["fechaCompra"].ToString());
                item.nombreCompleto = row["nombreCompleto"].ToString();

                items.Add(item);
            }

            dt.Dispose();

            return items;
        }

        public static void CancelarPasajeEncomienda(Int32 idCompra, String tipo, Int32 idPasajeEncomienda, DateTime fechaActual, String motivo)
        {
            Data.Devolucion.CancelarPasajeEncomienda(idCompra, tipo, idPasajeEncomienda, fechaActual, motivo);
        }

    }
}
