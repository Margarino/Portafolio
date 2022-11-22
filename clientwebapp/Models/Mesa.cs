using System;
using System.Collections.Generic;

namespace clientwebapp.Models
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
        public string? Supervisor { get; set; }
        public string? Password { get; set; }
        public string? Keeploggedin { get; set; }

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
