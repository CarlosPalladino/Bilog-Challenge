using Application.Dto.Request;
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
        /// Endpoint que retorna la lista de especialidades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListaEspecialidades()
        {
            var listaEspecialidades = await _service.ListaEspecialidades();
            return listaEspecialidades.Any() ? Ok(listaEspecialidades) : NotFound();
        }


        /// <summary>
        /// Endpoint que genera una nueva especialidad
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> NuevaEspecialidad([FromBody] EspecialidadRequest request)
        {
            await _service.CreateEspecialidad(request);
            return Ok("Nueva especialidad creada");
        }

        /// <summary>
        /// enpoint que permite actualizar la descripcion de la especialidad
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEspecialidad([FromBody] EspecialidadUpdateRequest updateRequest, int id)
        {
            await _service.ActualizarEspecialidad(updateRequest, id);
            return Ok("la especialidad se ha actualizado");
        }
        /// <summary>
        /// endpoit que permite eliminar una especialidad 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEspecialidad(int id)
        {
            await _service.EliminarEspecialida(id);
            return Ok("la especialidad fue eliminada exitosamente");
        }
    }
}
