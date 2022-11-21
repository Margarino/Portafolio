using System;
using System.Collections.Generic;

namespace clientwebapp.Models
{
    public partial class Empleado2
    {
        public string? Nombre { get; set; }
        public string? Rut { get; set; }
        public decimal? IdCargo { get; set; }
        public string? DescripcionCargo { get; set; }

        public Boolean KeepLoggedIn { get; set; }
    }
}
