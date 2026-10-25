using Cted.CatalogoCursos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Service.Interface
{
    public interface IModalidadeService
    {
        Task<IEnumerable<ModalidadeViewModel>> BuscarModalidades();
    }
}
