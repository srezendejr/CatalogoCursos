namespace Cted.CatalogoCursos.Models;

public sealed class CourseOffer
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string ShortDescription { get; init; } = string.Empty;
    public string FullDescription { get; init; } = string.Empty;
    public string Instructor { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string Modality { get; init; } = string.Empty;
    public string Level { get; init; } = string.Empty;
    public string TargetAudience { get; init; } = string.Empty;
    public int WorkloadHours { get; init; }
    public DateTime StartDate { get; init; }
}
