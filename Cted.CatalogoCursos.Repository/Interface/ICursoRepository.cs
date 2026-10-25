using Cted.CatalogoCursos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Repository.Interface
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoViewModel>> BuscarCursos();
    }
}
