// Ignore Spelling: Especialidad

using Application.Dto.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class EspecialidadesMapper : Profile
    {
        public EspecialidadesMapper()
        {
            CreateMap<Especialidad, EspecialidaResponse>()
                .ForMember(dest => dest.rowVersion, opt =>
                    opt.MapFrom(src => Convert.ToBase64String(src.rowversion)));
        }
    }
}