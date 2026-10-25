using Cted.CatalogoCursos.ViewModel;

namespace Cted.CatalogoCursos.Repository.Interface
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<CategoriaViewModel>> BuscarCategorias();
    }
}
