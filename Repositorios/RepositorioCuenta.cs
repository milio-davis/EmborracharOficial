using emb.Context;
using emb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Repositorios
{
    public class RepositorioCuenta : IRepositorioCuenta
    {
        private readonly AppDbContext _appDbContext;
        public RepositorioCuenta(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //public IEnumerable<Producto> Productos => _appDbContext.Productos.Include(c => c.Categoria);

        //public Producto obtenerProductoPorId(int productoId) => _appDbContext.Productos.FirstOrDefault(p => p.ProductoId == productoId);
    }
}
