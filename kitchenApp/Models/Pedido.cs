using System;
using System.Collections.Generic;

namespace kitchenApp.Models
{
    public partial class Pedido
    {
        public decimal Idpedido { get; set; }
        public string? Contpedido { get; set; }
        public string? Rut { get; set; }

        public virtual Adm? RutNavigation { get; set; }
    }
}
