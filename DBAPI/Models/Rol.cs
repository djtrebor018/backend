using System;
using System.Collections.Generic;

namespace DBAPI.Models
{
    public partial class Rol
    {
        public int IdRoles { get; set; }
        public string? Rol1 { get; set; }

        public virtual Usuarios? Usuario { get; set; } 
    }
}
