using emb.Models;
using emb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Components
{
    public class SumarioCarrito : ViewComponent
    {

        private readonly Carrito _carrito;
        public SumarioCarrito(Carrito carrito)
        {
            _carrito = carrito;
        }

        public IViewComponentResult Invoke()
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
    }
}
