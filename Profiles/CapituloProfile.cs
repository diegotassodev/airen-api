using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class CapituloProfile : Profile {
    public CapituloProfile() {
        CreateMap<CreateCapituloDto, Capitulo>();
        CreateMap<UpdateCapituloDto, Capitulo>();
        CreateMap<Capitulo, ReadCapituloDto>().ForMember(capituloDto => capituloDto.NumeroVolume, opt => opt.MapFrom(capitulo => capitulo.Volume!.Numero));
    }
}