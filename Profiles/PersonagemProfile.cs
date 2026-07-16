using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class PersonagemProfile : Profile {
    public PersonagemProfile() {
        CreateMap<CreatePersonagemDto, Personagem>();
        CreateMap<UpdatePersonagemDto, Personagem>();
        CreateMap<Personagem, ReadPersonagemDto>().ForMember(personagemDto => personagemDto.Potentia, opt => opt.MapFrom(personagem => personagem.Potentia));;
    }
}