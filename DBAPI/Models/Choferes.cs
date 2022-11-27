using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace DBAPI.Models
{
    public partial class Choferes
    {
        public Choferes()
        {
            Viajes = new HashSet<Viajes>();
        }

        public int? IdChofer { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public int? CategoriaLicencia { get; set; }
        public DateTime? ExpiracionLicencia { get; set; }
        public int? Autobus { get; set; }

        [JsonIgnore]
        public virtual Autobus? AutobusNavigation { get; set; } 
        [JsonIgnore]
        public virtual ICollection<Viajes> Viajes { get; set; }
    }
}
