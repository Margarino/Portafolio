using System;
using System.Collections.Generic;

namespace crudAdmin.Models
{
    public partial class Adm
    {
        public Adm()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public string Rut { get; set; } = null!;
        public string? Pass { get; set; }

        public virtual Empleado RutNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
