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

        public async Task ActualizarEspecialidad(EspecialidadUpdateRequest updateRequest, int id)
        {
            var especialidadActual = await _context.Especialidades
                                                 .FindAsync(id);
            if (especialidadActual is null)
                throw new KeyNotFoundException($"no se encontró la especialidad: {id}");

            _context.Entry(especialidadActual).OriginalValues["rowversion"] = Convert.FromBase64String(updateRequest.RowVersion);
            _mapper.Map(updateRequest, especialidadActual);

            _context.Update(especialidadActual);
            _context.SaveChanges();
        }

        public async Task CreateEspecialidad(EspecialidadRequest crearRequest)
        {
            var especialidad = _mapper.Map<Especialidad>(crearRequest);
            _context.Add(especialidad);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEspecialida(int id_especialidad)
        {
            var especialidadEncontrada = await _context.Especialidades
                                                 .FindAsync(id_especialidad);
            if (especialidadEncontrada is null)
                throw new KeyNotFoundException($"no se encontró la especialidad: {id_especialidad}");
            _context.Remove(especialidadEncontrada);
            _context.SaveChanges();
        }

        public async Task<List<EspecialidadResponse>> ListaEspecialidades()
        {
            var lista = await _context.Especialidades.Select(e => new EspecialidadResponse
            {
                cod_especialidad = e.cod_especialidad,
                descripcion = e.descripcion,
                rowVersion = e.rowversion

            }).ToListAsync();
            return lista;
        }
    }
}
