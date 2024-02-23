using AssetManagement.Data;
using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AccountController(
    IAccountRepo repository, IMapper mapper) : ControllerBase
    {
        private readonly IAccountRepo _repository = repository;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginDto accountLoginDto)
        {
            var response = await _repository.Login(accountLoginDto);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountCreateDto accountCreateDto)
        {
            var accountModel = _mapper.Map<AccountModel>(accountCreateDto);

            if (accountModel.Role == null)
            {
                accountModel.Role = "user";
            }
            accountModel.IsActive = true;
            accountModel.CreatDate = DateTime.Now;

            var response = await _repository.Register(accountModel);

            if (!response.Success)
            {
                return Conflict(response);
            }

            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(AccountToken accountToken)
        {
            var response = await _repository.RefreshToken(accountToken);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
        }

    }


}