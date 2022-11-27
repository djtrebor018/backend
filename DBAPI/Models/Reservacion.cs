using System;
using System.Collections.Generic;

namespace DBAPI.Models
{
    public partial class Reservacion
    {
        public int? IdReservacion { get; set; }
        public int?  IdViaje { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Estatus { get; set; }
        public int? AsientosReservados { get; set; }

        public virtual Usuarios?  IdUsuarioNavigation { get; set; }
        public virtual Viajes? IdViajeNavigation { get; set; }
    }
}
