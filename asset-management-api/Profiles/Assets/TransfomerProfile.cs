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
            CreateMap<PostTransformersDto, Transformer>();
            CreateMap<PostTransformersDto, Asset>();
        }
    }
}