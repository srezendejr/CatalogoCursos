namespace Cted.CatalogoCursos.Models;

public sealed class CourseCatalogFilter
{
    public string? Term { get; init; }
    public string? Category { get; init; }
    public string? Modality { get; init; }
    public string? Status { get; init; }
}
