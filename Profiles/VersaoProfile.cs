using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class VersaoProfile : Profile {
    public VersaoProfile() {
        CreateMap<CreateVersaoDto, Versao>();
        CreateMap<UpdateVersaoDto, Versao>();
        CreateMap<Versao, ReadVersaoDto>()
            .ForMember(versaoDto => versaoDto.NomePersonagem, opt => opt.MapFrom(versao => versao.Personagem!.Nome));
    }
}