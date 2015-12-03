using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public sealed class ListadoEstadistico
    {

        public static DataTable Get(Int32 numeroListado, DateTime desde, DateTime hasta)
        {
            return Data.ListadoEstadistico.Get(numeroListado, desde, hasta);
        }
    }
}
