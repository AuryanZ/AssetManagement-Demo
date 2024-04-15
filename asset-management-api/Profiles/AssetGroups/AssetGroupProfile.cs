using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;

namespace AssetManagement.Profiles
{
    public class AssetsGroupProfile : Profile
    {
        public AssetsGroupProfile()
        {
            // Source -> Target
            CreateMap<CreateAssetGroupDtos, AssetsGroup>();
            CreateMap<AssetsGroup, GetAssetDto>();
        }

    }
}