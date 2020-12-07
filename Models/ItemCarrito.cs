using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Models
{
    public class ItemCarrito
    {
        public int ItemCarritoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        [ForeignKey("Carrito")]
        public string CarritoId { get; set; }

    }
}
