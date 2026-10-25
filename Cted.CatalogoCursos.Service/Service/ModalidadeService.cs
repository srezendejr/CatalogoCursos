using Cted.CatalogoCursos.Repository.Interface;
using Cted.CatalogoCursos.Service.Interface;
using Cted.CatalogoCursos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Service.Service
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly IModalidadeRepository _modalidadeRepository;
        public ModalidadeService(IModalidadeRepository modalidadeRepository)
        {
            _modalidadeRepository = modalidadeRepository;
        }
        public Task<IEnumerable<ModalidadeViewModel>> BuscarModalidades()
        {
            var modalidades = _modalidadeRepository.BuscarModalidades();
            return modalidades;
        }
    }
}
