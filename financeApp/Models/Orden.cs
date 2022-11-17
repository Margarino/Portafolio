using System;
using System.Collections.Generic;

namespace financeApp.Models
{
    public partial class Orden
    {
        public decimal Idorden { get; set; }
        public string Contenidoorden { get; set; } = null!;
        public string Estadopedido { get; set; } = null!;
        public decimal Total { get; set; }
        public decimal? Idmesa { get; set; }
    }
}
