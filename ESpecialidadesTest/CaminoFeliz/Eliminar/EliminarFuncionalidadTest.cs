using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace EspecialidadesTest.CaminoFeliz.Eliminar
{

    [TestFixture]
    public class EliminarEspecialidadTest
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
        public async Task EliminarEspecialidad_DeberiaDevolver204_CuandoEsExitosa()
        {
            // Arrange
            var id_especialidad = 3054;

            _serviceMock
                .Setup(s => s.EliminarEspecialida(id_especialidad))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.EliminarEspecialidad(id_especialidad);

            // Assert
            var noContentResult = result as NoContentResult;
            Assert.That(noContentResult, Is.Not.Null);
            Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
        }

    }
}
