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
            CreateMap<AccountCreateDto, AccountModel>();
        }
    }
}