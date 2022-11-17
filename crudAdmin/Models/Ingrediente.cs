using System;
using System.Collections.Generic;

namespace crudAdmin.Models
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            Receta = new HashSet<Recetum>();
        }

        public decimal Idingrediente { get; set; }
        public string Nombreingrediente { get; set; } = null!;
        public decimal Precioingrediente { get; set; }

        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
