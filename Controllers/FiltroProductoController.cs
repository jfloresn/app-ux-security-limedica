using app_ux_security_limedica.Infraestructure;
using app_ux_security_limedica.Infraestructure.filtro;
using app_ux_security_limedica.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_ux_security_limedica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiltroProductoController : ControllerBase
    {

        private readonly FiltrarEspecialidadEditorialRepository filtrarEspecialidadEditorialRepository;
        private readonly ILogger<FiltroProductoController> _logger;


        public FiltroProductoController(FiltrarEspecialidadEditorialRepository filtrar, 
            ILogger<FiltroProductoController> logger)
        {
            filtrarEspecialidadEditorialRepository = filtrar;
            _logger = logger;
        }



        [HttpGet("filter-product")]
        public async Task<IEnumerable<BookFiltroDTO>> ObtenerLibros([FromQuery] int opcion, [FromQuery] int? idEditorial = null, [FromQuery] int? idEspecialidad = null)
        {
            return await filtrarEspecialidadEditorialRepository.ObtenerLibrosAsync(opcion, idEditorial, idEspecialidad);
        }

    }
}
