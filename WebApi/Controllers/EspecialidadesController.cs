using Application.Dto.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadInterface _service;

        public EspecialidadesController(IEspecialidadInterface service)
        {
            _service = service;
        }

        /// <summary>
        /// Endpoint que retorna la listsa de especialidades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListaEspecialidades()
        {
            var listaEspecialidades = await _service.ListaEspecialidades();
            return listaEspecialidades.Any() ? Ok(listaEspecialidades) : NotFound();
        }

        // GET api/<EspecialidadesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EspecialidadesController>
        [HttpPost]
        public async Task<IActionResult> NuevaEspecialidad([FromBody] EspecialidadRequest request)
        {
            await _service.CreateEspecialidad(request);

            return Ok("Nueva especialidad creada");
        }

        // PUT api/<EspecialidadesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EspecialidadesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
