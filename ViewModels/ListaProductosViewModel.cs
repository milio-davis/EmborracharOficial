using emb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.ViewModels
{
    public class ListaProductosViewModel
    {
        public IEnumerable<Producto> Productos { get; set; }

        public string CategoriaActual { get; set; }
    }
}
