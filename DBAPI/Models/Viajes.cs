using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBAPI.Models
{
    public partial class Viajes
    {
        public Viajes()
        {
            Reservacions = new HashSet<Reservacion>();
        }

        public int? IdViajes { get; set; }
        public int? IdRuta { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public int? IdAutobus { get; set; }
        public int? IdChofer { get; set; }

        [JsonIgnore]
        public virtual Autobus? IdAutobusNavigation { get; set; }
        [JsonIgnore]
        public virtual Choferes? IdChoferNavigation { get; set; }
        [JsonIgnore]
        public virtual Rutas? IdRutaNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reservacion> Reservacions { get; set; }
    }
}
