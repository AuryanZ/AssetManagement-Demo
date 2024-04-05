// using AutoMapper;
// using AssetManagement.Dtos;
// using AssetManagement.Models;

// namespace AssetManagement.Profiles
// {
//     public class AssetProfile : Profile
//     {
//         public AssetProfile()
//         {
//             // Source -> Target
//             CreateMap<Asset, GetAssetDto>();
//             CreateMap<Asset[], GetAssetDto[]>();
//             CreateMap<AssetCreateDto, Asset>();
//             // .ForMember(dest => dest.SubZone.Id, opt => opt.MapFrom(src => src.SubZoneID));
//             CreateMap<AssetUpdateDto, Asset>();
//             CreateMap<Asset, AssetUpdateDto>();
//             CreateMap<Asset, AssetBySzonDto>();
//             CreateMap<AssetBySzonDto, Asset>();
//         }
//     }
// }