using Application.Dto.Request;
using Application.Dto.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("especialidades")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadInterface _service;

        public EspecialidadesController(IEspecialidadInterface service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas las especialidades disponibles
        /// </summary>
        [ProducesResponseType(typeof(List<EspecialidadResponse>), 200)]
        [HttpGet]
        public async Task<IActionResult> ListaEspecialidades()
        {
            var lista = await _service.ListaEspecialidades();
            return Ok(lista);
        }

        /// <summary>
        /// Crea una nueva especialidad
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 409)]
        [HttpPost]
        public async Task<IActionResult> NuevaEspecialidad([FromBody] EspecialidadRequest request)
        {
            await _service.CreateEspecialidad(request);
            return StatusCode(StatusCodes.Status201Created, "Especialidad creada exitosamente");
        }

        /// <summary>
        /// Actualiza la descripción de una especialidad
        /// </summary>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 409)]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEspecialidad([FromBody] EspecialidadUpdateRequest updateRequest, int id)
        {
            await _service.ActualizarEspecialidad(updateRequest, id);
            return Ok("La especialidad se ha actualizado");
        }
        /// <summary>
        /// Elimina una especialidad por ID
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEspecialidad(int id)
        {
            await _service.EliminarEspecialida(id);
            return NoContent();
        }
    }
}
