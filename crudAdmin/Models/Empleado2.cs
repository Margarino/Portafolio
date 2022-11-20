using System;
using System.Collections.Generic;

namespace crudAdmin.Models
{
    public partial class Empleado2
    {
        public string? Nombre { get; set; }
        public string Rut { get; set; } = null!;
        public decimal? IdCargo { get; set; }
        public string? DescripcionCargo { get; set; }
    }
}
