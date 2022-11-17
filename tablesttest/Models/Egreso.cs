using System;
using System.Collections.Generic;

namespace tablesttest.Models
{
    public partial class Egreso
    {
        public decimal Idegreso { get; set; }
        public decimal Montoegreso { get; set; }
        public DateTime Fechaegreso { get; set; }
        public string Descripcionegreso { get; set; } = null!;
    }
}
