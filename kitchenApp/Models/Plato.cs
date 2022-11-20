using System;
using System.Collections.Generic;

namespace kitchenApp.Models
{
    public partial class Plato
    {
        public decimal Idplato { get; set; }
        public decimal? Idreceta { get; set; }
        public string Nombreplato { get; set; } = null!;
        public decimal? Valorplato { get; set; }
        public string? DescripcionPlato { get; set; }

        public virtual Recetum? IdrecetaNavigation { get; set; }
    }
}
