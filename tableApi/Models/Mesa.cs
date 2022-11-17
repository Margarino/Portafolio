using System;
using System.Collections.Generic;

namespace tableApi.Models
{
    public partial class Mesa
    {
        public decimal Idmesa { get; set; }
        public decimal Aforomaximo { get; set; }
        public string Estadomesa { get; set; } = null!;
    }
}
