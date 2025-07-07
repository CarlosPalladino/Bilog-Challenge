using Application.Interfaces;
using Moq;
using WebApi.Controllers;

namespace EspecialidadesTest.CaminoNoFeliz.Listar
{
    public class ListarEspecialidadNegativoTest
    {
        private Mock<IEspecialidadInterface> _serviceMock;
        private EspecialidadesController _controller;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IEspecialidadInterface>();
            _controller = new EspecialidadesController(_serviceMock.Object);
        }
        public void ListaEspecialidades_ShouldThrowException_WhenServiceFails()
        {
            // Arrange
            _serviceMock
                .Setup(s => s.ListaEspecialidades())
                .Throws(new Exception("Error inesperado al acceder a datos"));

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _controller.ListaEspecialidades());
            Assert.That(ex!.Message, Does.Contain("Error inesperado"));
        }
    }
}
