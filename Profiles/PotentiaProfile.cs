using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class PotentiaProfile : Profile {
    public PotentiaProfile() {
        CreateMap<CreatePotentiaDto, Potentia>();
        CreateMap<UpdatePotentiaDto, Potentia>();
        CreateMap<Potentia, ReadPotentiaDto>()
            .ForMember(potentiaDto => potentiaDto.NomePersonagem, opt => opt.MapFrom(potentia => potentia.Personagem!.Nome))
            .ForMember(potentiaDto => potentiaDto.ListaHabilidades, opt => opt.MapFrom(potentia => potentia.Habilidades));
    }
}