using System;
using System.Collections.Generic;

namespace crudBodega.Models
{
    public partial class Producto
    {
        public decimal Idproducto { get; set; }
        public string? Descripcionproducto { get; set; }
        public decimal? Valorproducto { get; set; }
    }
}
