using Application.Dto.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace EspecialidadesTest.CaminoFeliz.Crear
{
    public class NuevaEspecialidadesTest
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
        public async Task NuevaEspecialidad_ShouldReturn201()
        {
            // Arrange
            var request = new EspecialidadRequest
            {
                cod_especialidad = "OD02",
                descripcion = "Ortodoncia"
            };

            _serviceMock.Setup(s => s.CreateEspecialidad(request)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.NuevaEspecialidad(request);

            // Assert
            var createdResult = result as ObjectResult;
            Assert.That(createdResult, Is.Not.Null);
            Assert.That(createdResult.StatusCode, Is.EqualTo(201));
            Assert.That(createdResult.Value, Is.EqualTo("Especialidad creada exitosamente"));
        }

    }
}
