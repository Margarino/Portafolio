using System;
using System.Collections.Generic;

namespace tableApi.Models
{
    public partial class Mesa
    {
        public Mesa()
        {
            Ordens = new HashSet<Orden>();
        }

        public decimal Idmesa { get; set; }
        public decimal Aforomaximo { get; set; }
        public string Estadomesa { get; set; } = null!;
        public string? Supervisor { get; set; } = null;
        public string? Password { get; set; } = null;
        public bool Keeploggedin { get; set; }

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
