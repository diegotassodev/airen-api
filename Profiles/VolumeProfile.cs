using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
namespace AirenApi.Profiles;

public class VolumeProfile : Profile {
    public VolumeProfile() {
        CreateMap<CreateVolumeDto, Volume>();
        CreateMap<UpdateVolumeDto, Volume>();
        CreateMap<Volume, ReadVolumeDto>().ForMember(volumeDto => volumeDto.Capitulos, opt => opt.MapFrom(volume => volume.Capitulos));
    }
}