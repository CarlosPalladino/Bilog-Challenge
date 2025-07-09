using Application.Dto.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace EspecialidadesTest.CaminoNoFeliz.Crear
{
    public class CrearEspecialidadNegativoTest
    {
        private Mock<IEspecialidadInterface> _serviceMock;
        private EspecialidadesController _controller;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IEspecialidadInterface>();
            _controller = new EspecialidadesController(_serviceMock.Object);
        }
        [Test]
        public async Task CrearEspecialidad_ConDescripcionVacia_DeberiaDevolver400()
        {
            // Arrange
            var request = new EspecialidadRequest
            {
                cod_especialidad = "OD03",
                descripcion = ""
            };

            _controller.ModelState.AddModelError("descripcion", "La descripción es obligatoria");

            // Act
            var result = await _controller.NuevaEspecialidad(request);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            var badRequest = result as BadRequestObjectResult;
            Assert.That(badRequest.StatusCode, Is.EqualTo(400));
        }
    }
}
