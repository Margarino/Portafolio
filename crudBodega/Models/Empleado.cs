using System;
using System.Collections.Generic;

namespace crudBodega.Models
{
    public partial class Empleado
    {
        public string? Nombre { get; set; }
        public string Rut { get; set; } = null!;
        public string? Cargo { get; set; }

        public virtual Adm? Adm { get; set; }
    }
}
