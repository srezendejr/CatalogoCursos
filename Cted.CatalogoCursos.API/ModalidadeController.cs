using Cted.CatalogoCursos.Service.Interface;
using Cted.CatalogoCursos.Service.Service;
using Cted.CatalogoCursos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cted.CatalogoCursos.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadeController : ControllerBase
    {
        private readonly IModalidadeService _modalidadeService;
        public ModalidadeController(IModalidadeService modalidadeService)
        {
            _modalidadeService = modalidadeService;
        }
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<ModalidadeViewModel>>> Buscar()
        {
            var modalidades = await _modalidadeService.BuscarModalidades();
            return Ok(modalidades);
        }
    }
}
