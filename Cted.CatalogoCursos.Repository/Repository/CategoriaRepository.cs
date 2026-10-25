using Cted.CatalogoCursos.Database;
using Cted.CatalogoCursos.Repository.Interface;
using Cted.CatalogoCursos.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Repository.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoriaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<CategoriaViewModel>> BuscarCategorias()
        {
            var categorias = await (from c in _appDbContext.Categorias
                                    select new CategoriaViewModel
                                    {
                                        IdCategoria = c.IdCategoria,
                                        Descricao = c.Descricao
                                    }).ToListAsync();
            return categorias;
        }
    }
}
