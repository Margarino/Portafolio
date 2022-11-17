using System;
using System.Collections.Generic;

namespace financeApp.Models
{
    public partial class Adm
    {
        public Adm()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public string Rut { get; set; } = null!;
        public string? Pass { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
