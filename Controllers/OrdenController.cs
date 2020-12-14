﻿using emb.Interfaces;
using emb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Controllers
{
    public class OrdenController : Controller
    {
        private readonly IRepositorioOrden _repositorioOrden;
        private readonly Carrito _carrito;

        public OrdenController(IRepositorioOrden repositorioOrden, Carrito carrito)
        {
            _repositorioOrden = repositorioOrden;
            _carrito = carrito;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Orden orden)
        {
            var items = _carrito.GetItemsCarrito();
            _carrito.ItemsCarrito = items;

            if (_carrito.ItemsCarrito.Count < 1)
            {
                ModelState.AddModelError("", "Orden vacia, añada productos primero");
            }

            if (ModelState.IsValid)
            {
                _repositorioOrden.CrearOrden(orden);
                _carrito.LimpiarCarrito();
                return RedirectToAction("CheckoutCompleto", new { orden.OrdenId });
            }

            return View(orden);
        }

        public IActionResult CheckoutCompleto(int ordenId)
        {
            ViewBag.CheckoutCompleteMessage = "Gracias por su compra";            
            Orden orden = _repositorioOrden.GetOrden(ordenId);
            return View(orden);
        }

    }
}