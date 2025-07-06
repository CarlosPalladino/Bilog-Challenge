using Application.Dto.Request;
using Application.Dto.Response;

namespace Application.Interfaces
{
    public interface IEspecialidadInterface
    {
        Task<List<EspecialidadResponse>> ListaEspecialidades();

        Task CreateEspecialidad(EspecialidadRequest request);

        Task ActualizarEspecialidad(EspecialidadUpdateRequest requestUpdate, int id);

        Task EliminarEspecialida(int id);
    }
}
