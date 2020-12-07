using emb.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Models
{
    public class Carrito
    {
        public string CarritoId { get; set; }

        public List<ItemCarrito> ItemsCarrito { get; set; }

        private readonly AppDbContext _appDbContext;

        public Carrito(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static Carrito GetCarrito(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string carritoId = session.GetString("CarritoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarritoId", carritoId);

            return new Carrito(context) { CarritoId = carritoId };
        }

        public void AñadirACarrito(Producto producto, int cantidad)
        {
            var itemCarrito =
                _appDbContext.ItemsCarrito.SingleOrDefault(
                    s => s.Producto.ProductoId == producto.ProductoId && s.CarritoId == CarritoId);

            if (itemCarrito == null)
            {
                itemCarrito = new ItemCarrito
                {
                    CarritoId = CarritoId,
                    Producto = producto,
                    Cantidad = 1
                };

                _appDbContext.ItemsCarrito.Add(itemCarrito);
            } else
            {
                itemCarrito.Cantidad++;
            }
            _appDbContext.SaveChanges();            
        }

        public int RemoverDeCarrito(Producto producto)
        {
            var itemCarrito =
                _appDbContext.ItemsCarrito.SingleOrDefault(
                    s => s.Producto.ProductoId == producto.ProductoId && s.CarritoId == CarritoId);
            var cantidadLocal = 0;

            if (itemCarrito != null)
            {
                if (itemCarrito.Cantidad > 1)
                {
                    itemCarrito.Cantidad--;
                    cantidadLocal = itemCarrito.Cantidad;
                }
                else
                {
                    _appDbContext.ItemsCarrito.Remove(itemCarrito);
                }
            }
            _appDbContext.SaveChanges();
            return cantidadLocal;
        }

        public List<ItemCarrito> GetItemsCarrito()
        {
            return ItemsCarrito ??
                (ItemsCarrito =
                _appDbContext.ItemsCarrito.Where(c => c.CarritoId == CarritoId)
                .Include(s => s.Producto)
                .ToList());
        }

        public void LimpiarCarrito()
        {
            var itemsCarrito = _appDbContext
                .ItemsCarrito
                .Where(carrito => carrito.CarritoId == CarritoId);

            _appDbContext.ItemsCarrito.RemoveRange(itemsCarrito);

            _appDbContext.SaveChanges();
        }

        public double GetTotalCarrito()
        {
            var total = _appDbContext.ItemsCarrito.Where(c => c.CarritoId == CarritoId)
                .Select(c => c.Producto.Precio * c.Cantidad).Sum();
            return total;
        }
    }
}
