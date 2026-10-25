using Cted.CatalogoCursos.ViewModel;

namespace Cted.CatalogoCursos.Models;

public sealed class CourseCatalogViewModel
{
    public CourseCatalogFilter Filter { get; init; } = new();
    public string? ErrorMessage { get; init; }
    public IReadOnlyList<string> Categories { get; init; } = [];
    public IReadOnlyList<string> Modalities { get; init; } = [];
    public IReadOnlyList<string> Statuses { get; init; } = [];
    public IReadOnlyList<CursoViewModel> Courses { get; init; } = [];
}
