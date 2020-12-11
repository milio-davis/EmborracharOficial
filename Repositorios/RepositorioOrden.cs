using emb.Context;
using emb.Interfaces;
using emb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Repositorios
{
    public class RepositorioOrden : IRepositorioOrden
    {

        private readonly AppDbContext _appDbContext;
        private readonly Carrito _carrito;

        public RepositorioOrden(AppDbContext appDbContext, Carrito carrito)
        {
            _appDbContext = appDbContext;
            _carrito = carrito;
        }
        public void CrearOrden(Orden orden)
        {
            orden.FechaCompra = DateTime.Now;
            _appDbContext.Ordenes.Add(orden);

            var itemsCarrito = _carrito.ItemsCarrito;

            foreach (var item in itemsCarrito)
            {
                var detalleOrden = new DetalleOrden()
                {
                    Cantidad = item.Cantidad,
                    ProductoId = item.Producto.ProductoId,
                    OrdenId = orden.OrdenId,
                    Precio = item.Producto.Precio
                };
                _appDbContext.DetallesOrden.Add(detalleOrden);
            }
            _appDbContext.SaveChanges();

        }

        public Orden GetOrden(int ordenId)
        {
            return _appDbContext.Ordenes.Where(p => p.OrdenId == ordenId).FirstOrDefault();
        }
    }

    
}
