using Application.Dto.Request;
using Application.Dto.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class EspecialidadesService : IEspecialidadInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EspecialidadesService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<EspecialidadRequest> ActualizarEspecialidad()
        {
            throw new NotImplementedException();
        }

        public async Task CreateEspecialidad(EspecialidadRequest request)
        {
            var especialidad = _mapper.Map<Especialidad>(request);
            _context.Add(especialidad);
            await _context.SaveChangesAsync();
        }

        public Task EliminarEspecialida(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EspecialidaResponse>> ListaEspecialidades()
        {
            var lista = await _context.Especialidades.Select(e => new EspecialidaResponse
            {
                cod_especialidad = e.cod_especialidad,
                descripcion = e.descripcion,
                rowVersion = e.rowversion

            }).ToListAsync();
            return lista;
        }
    }
}
