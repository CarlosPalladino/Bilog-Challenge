using Application.Interfaces;
using Moq;
using WebApi.Controllers;

namespace EspecialidadesTest.CaminoNoFeliz.Eliminar
{
    public class EliminarEspecialidadNegativoTest
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
        public async Task EliminarEspecialidad_WithNonexistentId_ShouldThrowNotFound()
        {
            // Arrange
            var idInvalido = 9999;

            _serviceMock
                .Setup(s => s.EliminarEspecialida(idInvalido))
                .ThrowsAsync(new KeyNotFoundException("No existe"));

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _controller.EliminarEspecialidad(idInvalido));

            Assert.That(ex!.Message, Does.Contain("No existe"));
        }

    }
}
