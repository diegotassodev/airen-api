using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class PotentiaProfile : Profile {
    public PotentiaProfile() {
        CreateMap<CreatePotentiaDto, Potentia>();
        CreateMap<UpdatePotentiaDto, Potentia>();
        CreateMap<Potentia, ReadPotentiaDto>();
    }
}