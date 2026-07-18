using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class HobbyProfile : Profile {
    public HobbyProfile() {
        CreateMap<CreateHobbyDto, Hobby>();
        CreateMap<UpdateHobbyDto, Hobby>();
        CreateMap<Hobby, ReadHobbyDto>();
    }
}