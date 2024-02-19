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
            CreateMap<AssetManage, AssetReadDto>();
            CreateMap<AssetCreateDto, AssetManage>();
            CreateMap<AssetUpdateDto, AssetManage>();
            CreateMap<AssetManage, AssetUpdateDto>();
        }
    }
}