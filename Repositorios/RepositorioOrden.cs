﻿using emb.Context;
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

            orden.TotalOrden = _carrito.GetTotalCarrito();

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

        public List<DetalleOrden> GetDetallesOrden(int ordenId)
        {
            
            var query = from a in _appDbContext.DetallesOrden
                        join s in _appDbContext.Ordenes on a.OrdenId equals s.OrdenId
                        join d in _appDbContext.Productos on a.ProductoId equals d.ProductoId
                        join f in _appDbContext.Categorias on d.CategoriaId equals f.CategoriaId
                        where a.OrdenId == ordenId
                        select new DetalleOrden
                        {
                            DetalleOrdenId = a.DetalleOrdenId,
                            OrdenId = a.OrdenId,
                            ProductoId = a.ProductoId,
                            Cantidad = a.Cantidad,
                            Precio = a.Precio,
                            Producto = a.Producto,                            
                            Orden = a.Orden,
                            NombreCategoria = f.NombreCategoria
                        };
            return query.ToList();

        }
    }
}