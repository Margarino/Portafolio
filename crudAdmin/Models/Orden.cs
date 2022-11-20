using System;
using System.Collections.Generic;

namespace crudAdmin.Models
{
    public partial class Orden
    {
        public decimal Idorden { get; set; }
        public string? Contenidoorden { get; set; }
        public string? Estadoorden { get; set; }
        public decimal? Total { get; set; }
        public decimal? Idmesa { get; set; }

        public virtual Mesa? IdmesaNavigation { get; set; }
    }
}
