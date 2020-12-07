using emb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Interfaces
{
    public interface IRepositorioCategoria
    {
        IEnumerable<Categoria> Categorias { get; }

    }
}
