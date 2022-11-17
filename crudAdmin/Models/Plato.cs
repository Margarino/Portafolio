using System;
using System.Collections.Generic;

namespace crudAdmin.Models
{
    public partial class Plato
    {
        public decimal Idplato { get; set; }
        public string Nombreplato { get; set; } = null!;
        public string Descripcionplato { get; set; } = null!;
    }
}
