using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DBAPI.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Reservacions = new HashSet<Reservacion>();
        }

        public int? IdUsuario { get; set; }
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Cedula { get; set; }
        public int?  Rol { get; set; }


        [JsonIgnore]
        public virtual Rol? IdUsuarioNavigation { get; set; }
        [JsonIgnore]

        public virtual ICollection<Reservacion> Reservacions { get; set; } 
    }
}
