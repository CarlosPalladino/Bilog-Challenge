using Application.Dto.Request;
using Application.Dto.Response;

namespace Application.Interfaces
{
    public interface IEspecialidadInterface
    {
        Task<List<EspecialidaResponse>> ListaEspecialidades();

        Task CreateEspecialidad(EspecialidadRequest request);

        Task<EspecialidadRequest> ActualizarEspecialidad();

        Task EliminarEspecialida(int id);
    }
}
