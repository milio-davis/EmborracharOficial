using emb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Interfaces
{
    public interface IRepositorioOrden
    {
        void CrearOrden(Orden orden);
        Orden GetOrden(int ordenId);
        List<DetalleOrden> GetDetallesOrden(int ordenId);
    }
}
