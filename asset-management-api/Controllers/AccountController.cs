using AssetManagement.Data;
using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(
    IAccountRepo repository, IMapper mapper) : ControllerBase
    {
        private readonly IAccountRepo _repository = repository;
        private readonly IMapper _mapper = mapper;

        [HttpPost("login")]
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

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(AccountToken accountToken)
        {
            var response = await _repository.Logout(accountToken);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(AccountChangePassword accountChangePassword)
        {
            var response = await _repository.ChangePassword(accountChangePassword);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
        }

        //active users
        [HttpPatch("active-user")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ActiveUser(string[] eamil)
        {
            var response = await _repository.ActiveUser(eamil);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
        }

        //inactive users
        [HttpPost("inactive-user")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> InactiveUser(string[] eamil)
        {
            var response = await _repository.InactiveUser(eamil);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
        }

        [HttpGet("user-role/{accountToken}")]
        public async Task<IActionResult> GetUserRole(string accountToken)
        {
            var response = await _repository.GetUserRole(accountToken);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }
    }



}