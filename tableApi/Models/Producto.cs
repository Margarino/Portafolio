using System;
using System.Collections.Generic;

namespace tableApi.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Receta = new HashSet<Recetum>();
        }

        public decimal? Idproducto { get; set; }
        public string? Descripcionproducto { get; set; }
        public decimal? Valorproducto { get; set; }

        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
