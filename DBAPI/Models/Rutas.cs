using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBAPI.Models
{
    public partial class Rutas
    {
        public Rutas()
        {
            Viajes = new HashSet<Viajes>();
        }

        public int? IdRuta { get; set; }
        public int? Origen { get; set; }
        public int? Destino { get; set; }
        public bool? Estatus { get; set; }

        [JsonIgnore]
        public virtual Destinos? DestinoNavigation { get; set; }
        [JsonIgnore]
        public virtual Destinos? OrigenNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Viajes> Viajes { get; set; }
    }
}
