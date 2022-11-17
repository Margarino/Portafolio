using System;
using System.Collections.Generic;

namespace clientwebapp.Models
{
    public partial class Ingrediente
    {
        public decimal Idingrediente { get; set; }
        public string Nombreingrediente { get; set; } = null!;
        public decimal Precioingrediente { get; set; }
    }
}
