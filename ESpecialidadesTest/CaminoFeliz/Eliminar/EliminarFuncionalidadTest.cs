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
        public async Task EliminarEspecialidad_ShouldReturn204_WhenSuccessful()
        {
            // Arrange
            var id = 3054;

            _serviceMock
                .Setup(s => s.EliminarEspecialida(id))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.EliminarEspecialidad(id);

            // Assert
            var noContentResult = result as NoContentResult;
            Assert.That(noContentResult, Is.Not.Null);
            Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
        }

    }
}
