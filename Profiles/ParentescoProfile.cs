using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class ParentescoProfile : Profile {
    public ParentescoProfile() {
        CreateMap<CreateParentescoDto, Parentesco>();
        CreateMap<UpdateParentescoDto, Parentesco>();
        CreateMap<Parentesco, ReadParentescoDto>();
    }
}