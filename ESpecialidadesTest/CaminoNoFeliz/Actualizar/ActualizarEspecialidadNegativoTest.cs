using Application.Dto.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace EspecialidadesTest.CaminoNoFeliz.Actualizar
{
    public class ActualizarEspecialidadNegativoTest
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
        public async Task ActualizarEspecialidad_WithNullRowVersion_ShouldReturn400()
        {
            // Arrange
            var updateRequest = new EspecialidadUpdateRequest
            {
                descripcion = "Nueva desc.",
                RowVersion = null!
            };

            _controller.ModelState.AddModelError("RowVersion", "El campo RowVersion es obligatorio");

            // Act
            var result = await _controller.ActualizarEspecialidad(updateRequest, 3054);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            var badRequest = result as BadRequestObjectResult;
            Assert.That(badRequest.StatusCode, Is.EqualTo(400));
        }
    }
}
