using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBAPI.Models
{
    public partial class Destinos
    {
        public Destinos()
        {
            RutaDestinoNavigations = new HashSet<Rutas>();
            RutaOrigenNavigations = new HashSet<Rutas>();
        }

        public int IdDestinos { get; set; }
        public string? Destino { get; set; }


        public virtual ICollection<Rutas>RutaDestinoNavigations { get; set; }
       
        public virtual ICollection<Rutas>RutaOrigenNavigations { get; set; }
    }
}
