using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class TipoServicio
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Double porcentajeAdicional { get; set; }

        public TipoServicio() { }

        public TipoServicio(Int32 id, String nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public static List<TipoServicio> Get()
        {
            var tipos = new List<TipoServicio>();

            using (var data = Data.TipoServicio.Get())
            {
                foreach (DataRow row in data.Rows)
                    tipos.Add(new TipoServicio(Int32.Parse(row["Id"].ToString()), row["Nombre"].ToString()));
            }

            return tipos;
        }

    }
}
