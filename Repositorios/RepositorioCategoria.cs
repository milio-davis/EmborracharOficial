using emb.Context;
using emb.Interfaces;
using emb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioCategoria(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Categoria> Categorias => _appDbContext.Categorias;
    }
}
