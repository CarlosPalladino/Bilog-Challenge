using Application.Dto.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace EspecialidadesTest.CaminoFeliz.Listar;

[TestFixture]
public class EspecialidadesControllerTests
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
    public async Task ListaEspecialidades_DeberiaDevolverOk_ConLista()
    {
        // Arrange
        var especialidades = new List<EspecialidadResponse>
        {
            new() {
                cod_especialidad = "03",
                descripcion = "03",
                rowVersion = Convert.FromBase64String("AAAAAAAo9GE=")
            }
        };

        _serviceMock.Setup(s => s.ListaEspecialidades()).ReturnsAsync(especialidades);

        // Act
        var result = await _controller.ListaEspecialidades();

        // Assert
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));
        Assert.That(okResult.Value, Is.EqualTo(especialidades));
    }



}
