using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public List<Producto> Productos { get; set; }

    }
}
