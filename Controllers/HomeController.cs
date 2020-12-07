using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using emb.Models;
using emb.Interfaces;
using emb.ViewModels;

namespace emb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepositorioProducto _repositorioProducto;

        public HomeController(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto;
        }
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Productos = _repositorioProducto.Productos
            };
            return View(homeViewModel);
        }

        public ViewResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
