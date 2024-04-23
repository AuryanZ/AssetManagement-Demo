using AutoMapper;
using AssetManagement.Dtos;
using AssetManagement.Models;

namespace AssetManagement.Profiles
{
    public class TransformerProfiles : Profile
    {
        public TransformerProfiles()
        {
            // Source -> Target
            CreateMap<PostTransformersDto, Transformer>()
                .ForPath(dist => dist.AssetsGroup.GroupId, opt => opt.MapFrom(src => src.GroupId));
            CreateMap<Transformer, PostTransformersDto>();
            CreateMap<Transformer, GetTransformersDto>();
            CreateMap<Transformer[], GetTransformersDto[]>();
        }
    }
}