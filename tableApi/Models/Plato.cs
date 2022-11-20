using System;
using System.Collections.Generic;

namespace tableApi.Models
{
    public partial class Plato
    {
        public decimal? Idplato { get; set; }
        public decimal? Idreceta { get; set; }
        public string Nombreplato { get; set; }
        public string DescripcionPlato { get; set; }
        public decimal Valorplato { get; set; }

        public virtual Recetum? IdrecetaNavigation { get; set; }
    }
}
