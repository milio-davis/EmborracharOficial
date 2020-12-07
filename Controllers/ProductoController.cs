using emb.Interfaces;
using emb.Models;
using emb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IRepositorioProducto _repositorioProducto;
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ProductoController(IRepositorioCategoria repositorioCategoria, IRepositorioProducto repositorioProducto)
        {
            _repositorioCategoria = repositorioCategoria;
            _repositorioProducto = repositorioProducto;
        }

        public ViewResult Lista(string categoria)
        {
           
            string _categoria = categoria;
            IEnumerable<Producto> productos;

            string categoriaActual = string.Empty;

            if (string.IsNullOrEmpty(_categoria))
            {
                productos = _repositorioProducto.Productos.OrderBy(n => n.ProductoId);
                categoriaActual = "Todos los Productos";
            } else
            {
                if (string.Equals("Cervezas", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    productos = _repositorioProducto.Productos.Where(p => p.Categoria.Nombre.Equals("Cervezas")).OrderBy(n => n.ProductoId);
                    categoriaActual = "Cervezas";
                } else if (string.Equals("Vinos", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    productos = _repositorioProducto.Productos.Where(p => p.Categoria.Nombre.Equals("Vinos")).OrderBy(n => n.ProductoId);
                    categoriaActual = "Vinos";
                } else
                {
                    productos = _repositorioProducto.Productos.Where(p => p.Categoria.Nombre.Equals("Whiskies")).OrderBy(n => n.ProductoId);
                    categoriaActual = "Whiskies";
                }
                categoriaActual = _categoria;
            }
            var listaProductosViewModel = new ListaProductosViewModel
            {
                Productos = productos,
                CategoriaActual = categoriaActual
            };
            return View(listaProductosViewModel);
        }
    }
}
