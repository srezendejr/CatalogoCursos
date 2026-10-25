using Cted.CatalogoCursos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Repository.Interface
{
    public interface IModalidadeRepository
    {
        Task<IEnumerable<ModalidadeViewModel>> BuscarModalidades();

    }
}
