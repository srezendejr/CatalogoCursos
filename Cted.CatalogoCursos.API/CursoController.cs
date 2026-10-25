using Cted.CatalogoCursos.Service.Interface;
using Cted.CatalogoCursos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cted.CatalogoCursos.API;

[ApiController]
[Route("api/[controller]")]
public sealed class CursoController(ICursoService cursoService) : ControllerBase
{
    [HttpGet("buscar")]
    public async Task<ActionResult<IEnumerable<CursoViewModel>>> Buscar()
    {
        try
        {
            var cursos = await cursoService.BuscarCursos();
            return Ok(cursos);
        }
        catch (InvalidOperationException ex)
        {
            return Problem(
                title: "Erro ao buscar cursos",
                detail: ex.Message,
                statusCode: 500);
        }
    }
}
