using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class AfiliacaoProfile : Profile {
    public AfiliacaoProfile() {
        CreateMap<CreateAfiliacaoDto, Afiliacao>();
        CreateMap<UpdateAfiliacaoDto, Afiliacao>();
        CreateMap<Afiliacao, ReadAfiliacaoDto>();
    }
}