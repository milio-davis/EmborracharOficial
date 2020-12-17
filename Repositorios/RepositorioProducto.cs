using emb.Context;
using emb.Interfaces;
using emb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Repositorios
{
    public class RepositorioProducto : IRepositorioProducto

    {
        private readonly AppDbContext _appDbContext;
        public RepositorioProducto(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Producto> Productos => _appDbContext.Productos.Include(c => c.Categoria);

        public Producto obtenerProductoPorId(int productoId) => _appDbContext.Productos.FirstOrDefault(p => p.ProductoId == productoId);

        

        public void AgregarProducto(Producto producto)
        {
            _appDbContext.Productos.Add(producto);
        }
    }
}
