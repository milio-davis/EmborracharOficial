using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using emb.Context;
using emb.Models;
using emb.Interfaces;
using emb.ViewModels;

namespace emb.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IRepositorioProducto _repositorioProducto;
        private readonly Carrito _carrito;

        public CarritoController(IRepositorioProducto repositorioProducto, Carrito carrito)
        {
            _repositorioProducto = repositorioProducto;
            _carrito = carrito;
        }

        // GET: Carrito
        public ViewResult Index()
        {
            var items = _carrito.GetItemsCarrito();
            _carrito.ItemsCarrito = items;
            var carritoViewModel = new CarritoViewModel
            {
                Carrito = _carrito,
                CarritoTotal = _carrito.GetTotalCarrito()
            };

            return View(carritoViewModel);
        }

        public RedirectToActionResult AñadirACarrito(int productoId)
        {
            var productoSeleccionado = _repositorioProducto.Productos.FirstOrDefault(p => p.ProductoId == productoId);
            if (productoSeleccionado != null)
            {
                _carrito.AñadirACarrito(productoSeleccionado, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverDeCarrito(int productoId)
        {
            var productoSeleccionado = _repositorioProducto.Productos.FirstOrDefault(p => p.ProductoId == productoId);
            if (productoSeleccionado != null)
            {
                _carrito.RemoverDeCarrito(productoSeleccionado);
            }
            return RedirectToAction("Index");
        }
    }
}
