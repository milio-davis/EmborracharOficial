using emb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Components
{
    public class MenuCategorias : ViewComponent

    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public MenuCategorias(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _repositorioCategoria.Categorias.OrderBy(p => p.Nombre);
            return View(categorias);
        }
    }
}
