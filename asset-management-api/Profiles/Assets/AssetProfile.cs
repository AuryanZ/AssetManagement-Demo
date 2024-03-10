using AutoMapper;
using AssetManagement.Dtos;
using AssetManagement.Models;

namespace AssetManagement.Profiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            // Source -> Target
            CreateMap<Asset, AssetReadDto>();
            CreateMap<AssetCreateDto, Asset>();
            CreateMap<AssetUpdateDto, Asset>();
            CreateMap<Asset, AssetUpdateDto>();
        }
    }
}