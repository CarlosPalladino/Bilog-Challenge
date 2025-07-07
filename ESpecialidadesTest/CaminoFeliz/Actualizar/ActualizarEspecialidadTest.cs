using Application.Dto.Request;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebApi.Controllers;

namespace EspecialidadesTest.CaminoFeliz.Actualizar
{
    public class ActualizarEspecialidadTest
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
        public async Task ActualizarEspecialidad_WhenConflict_ShouldReturn409()
        {
            // Arrange
            var updateRequest = new EspecialidadUpdateRequest
            {
                descripcion = "Cirugía",
                RowVersion = "AAAAAAAACcM="
            };

            _serviceMock
           .Setup(s => s.ActualizarEspecialidad(updateRequest, 3054))
           .ThrowsAsync(new DbUpdateConcurrencyException());

            var ex = Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () =>
            await _controller.ActualizarEspecialidad(updateRequest, 3054));

            Assert.That(ex, Is.Not.Null);
        }


    }
}
