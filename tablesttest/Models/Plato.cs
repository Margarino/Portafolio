using System;
using System.Collections.Generic;

namespace tablesttest.Models
{
    public partial class Plato
    {
        public decimal Idplato { get; set; }
        public decimal? Idreceta { get; set; }
        public string Nombreplato { get; set; } = null!;

        public virtual Recetum? IdrecetaNavigation { get; set; }
    }
}
