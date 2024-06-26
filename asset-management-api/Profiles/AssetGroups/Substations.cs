using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;

namespace AssetManagement.Profiles
{
   public class Substations : Profile
   {
      public Substations()
      {
         // Source -> Target
         CreateMap<CreateAssetGroupDtos, ZoneSubstation>();
         CreateMap<ZoneSubstation, GetSubstationDto>();
      }
   }
}