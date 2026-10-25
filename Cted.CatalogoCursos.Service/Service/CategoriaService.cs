using Cted.CatalogoCursos.Repository.Interface;
using Cted.CatalogoCursos.Service.Interface;
using Cted.CatalogoCursos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Service.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public Task<IEnumerable<CategoriaViewModel>> BuscarCategorias()
        {
            var categorias = _categoriaRepository.BuscarCategorias();
            return categorias;
        }
    }
}
