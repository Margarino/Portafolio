using System;
using System.Collections.Generic;

namespace crudBodega.Models
{
    public partial class Ingreso
    {
        public decimal Idingreso { get; set; }
        public decimal Montoingreso { get; set; }
        public DateTime Fechaingreso { get; set; }
        public string Descripcioningreso { get; set; } = null!;
    }
}
