using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBAPI.Models
{
    public partial class Autobus
    {
        public Autobus()
        {
            Choferes = new HashSet<Choferes>();
            Viajes = new HashSet<Viajes>();
        }

        public int? IdAutobus { get; set; }
        public string? Marca { get; set; }
        public int? CantidadAsientos { get; set; }


        [JsonIgnore]
        public virtual ICollection<Choferes> Choferes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Viajes> Viajes { get; set; }
    }
}
