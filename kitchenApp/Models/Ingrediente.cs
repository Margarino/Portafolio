using System;
using System.Collections.Generic;

namespace kitchenApp.Models
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            Receta = new HashSet<Recetum>();
        }

        public decimal Idingrediente { get; set; }
        public string Nombreingrediente { get; set; } = null!;
        public string? Unidadmedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? Precioingrediente { get; set; }

        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
