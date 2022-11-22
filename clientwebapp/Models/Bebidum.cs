using System;
using System.Collections.Generic;

namespace clientwebapp.Models
{
    public partial class Bebidum
    {
        public decimal Idbebida { get; set; }
        public string Nombrebebida { get; set; } = null!;
        public decimal Valorbebida { get; set; }
        public decimal? Cantidadbebida { get; set; }
    }
}
