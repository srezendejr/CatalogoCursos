using System.Net.Http.Json;
using Cted.CatalogoCursos.Models;
using Cted.CatalogoCursos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cted.CatalogoCursos.Controllers;

public sealed class CoursesController(IHttpClientFactory httpClientFactory) : Controller
{
    private HttpClient ApiClient => httpClientFactory.CreateClient("CursoApi");

    public async Task<IActionResult> Index([FromQuery] CourseCatalogFilter filter)
    {
        string? errorMessage = null;
        List<CursoViewModel> cursos;

        try
        {
            cursos = await BuscarCursosNaApi();
        }
        catch (InvalidOperationException ex)
        {
            cursos = [];
            errorMessage = ex.Message;
        }

        var allCourses = cursos.Select(curso => new CourseOffer
        {
            Id = curso.IdCurso,
            Title = curso.NomeCompleto,
            ShortDescription = curso.NomeBreve,
            FullDescription = curso.Descricao,
            Instructor = "Corpo docente SESI",
            Category = curso.Categoria,
            Modality = curso.Modalidade,
            Level = curso.Status,
            TargetAudience = curso.PublicoAlvo,
            WorkloadHours = curso.CargaHoraria,
            StartDate = curso.DataDisponibilizacao
        }).ToArray();

        IEnumerable<CourseOffer> query = allCourses;

        if (!string.IsNullOrWhiteSpace(filter.Term))
        {
            var term = filter.Term.Trim();
            query = query.Where(course =>
                course.Title.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                course.ShortDescription.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                course.FullDescription.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                course.Level.Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(filter.Category))
        {
            query = query.Where(course => course.Category.Equals(filter.Category, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(filter.Modality))
        {
            query = query.Where(course => course.Modality.Equals(filter.Modality, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(filter.Status))
        {
            query = query.Where(course => course.Level.Equals(filter.Status, StringComparison.OrdinalIgnoreCase));
        }

        var normalizedCourses = query
            .OrderBy(course => course.StartDate)
            .ThenBy(course => course.Title)
            .ToArray();

        var model = new CourseCatalogViewModel
        {
            Filter = filter,
            ErrorMessage = errorMessage,
            Courses = normalizedCourses.Select(course => new CursoViewModel
            {
                IdCurso = course.Id,
                NomeCompleto = course.Title,
                NomeBreve = course.ShortDescription,
                Descricao = course.FullDescription,
                Categoria = course.Category,
                Modalidade = course.Modality,
                Status = course.Level,
                PublicoAlvo = course.TargetAudience,
                CargaHoraria = course.WorkloadHours,
                DataDisponibilizacao = course.StartDate
            }).ToArray(),
            Categories = allCourses
                .Select(course => course.Category)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(category => category)
                .ToArray(),
            Modalities = allCourses
                .Select(course => course.Modality)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(modality => modality)
                .ToArray(),
            Statuses = allCourses
                .Select(course => course.Level)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(status => status)
                .ToArray()
        };

        return View(model);
    }

    public async Task<IActionResult> Details(int id)
    {
        var cursos = await BuscarCursosNaApi();
        var course = cursos
            .Where(curso => curso.IdCurso == id)
            .Select(curso => new CourseOffer
            {
                Id = curso.IdCurso,
                Title = curso.NomeCompleto,
                ShortDescription = curso.NomeBreve,
                FullDescription = curso.Descricao,
                Instructor = "Corpo docente SESI",
                Category = curso.Categoria,
                Modality = curso.Modalidade,
                Level = curso.Status,
                TargetAudience = curso.PublicoAlvo,
                WorkloadHours = curso.CargaHoraria,
                StartDate = curso.DataDisponibilizacao
            })
            .FirstOrDefault();

        if (course is null)
        {
            return NotFound();
        }

        return View(course);
    }

    private async Task<List<CursoViewModel>> BuscarCursosNaApi()
    {
        var response = await ApiClient.GetAsync("api/curso/buscar");
        if (!response.IsSuccessStatusCode)
        {
            var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            var message = !string.IsNullOrWhiteSpace(problem?.Detail)
                ? problem.Detail
                : "Não foi possível carregar os cursos no momento.";

            throw new InvalidOperationException(message);
        }

        return await response.Content.ReadFromJsonAsync<List<CursoViewModel>>() ?? [];
    }
}
