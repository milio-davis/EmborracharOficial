using emb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Interfaces
{
    public interface IRepositorioProducto
    {
        IEnumerable<Producto> Productos { get;}
        Producto obtenerProductoPorId(int productoId);

        void AgregarProducto(Producto producto);
    }
}
