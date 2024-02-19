using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;

namespace AssetManagement.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // Source -> Target
            CreateMap<AccountModel, AccountReadDto>();
            CreateMap<AccountCreateDto, AccountModel>();
            CreateMap<AccountUpdateDto, AccountModel>();
            CreateMap<AccountModel, AccountUpdateDto>();
        }
    }
}