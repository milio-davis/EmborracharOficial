using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Models
{
    public class DetalleOrden
    {
        public int DetalleOrdenId { get; set; }

        public int OrdenId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }

        public Producto Producto { get; set; }

        public Orden Orden { get; set; }

        public string NombreCategoria { get; set; }
    }
}
