using Cted.CatalogoCursos.Repository.Interface;
using Cted.CatalogoCursos.Service.Interface;
using Cted.CatalogoCursos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Service.Service
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly ILogger<CursoService> _logger;

        public CursoService(ICursoRepository cursoRepository, ILogger<CursoService> logger)
        {
            _cursoRepository = cursoRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CursoViewModel>> BuscarCursos()
        {
            try
            {
                var cursos = await _cursoRepository.BuscarCursos();
                return cursos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar cursos no repositório.");
                throw new InvalidOperationException("Não foi possível carregar os cursos no momento.");
            }
        }
    }
}
