using System;
using System.Collections.Generic;

namespace kitchenApp.Models
{
    public partial class Recetum
    {
        public Recetum()
        {
            Platos = new HashSet<Plato>();
        }

        public decimal Idreceta { get; set; }
        public decimal? Idingrediente { get; set; }
        public decimal? Idproducto { get; set; }

        public virtual Ingrediente? IdingredienteNavigation { get; set; }
        public virtual Producto? IdproductoNavigation { get; set; }
        public virtual ICollection<Plato> Platos { get; set; }
    }
}
