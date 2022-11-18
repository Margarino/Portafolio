using System;
using System.Collections.Generic;

namespace crudBodega.Models
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

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
