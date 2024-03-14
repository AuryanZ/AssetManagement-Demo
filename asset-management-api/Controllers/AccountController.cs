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

            if (response.status == 200)
            {
                Response.Headers.Append("Authorization", $"Bearer {response.accessToken}");
                Response.Headers.Append("refreshToken", $"Bearer {response.refreshToken}");
                return Ok(new GeneralServiceResponse(200, "Login successful"));
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

            if (response.status != 200)
            {
                return Conflict(response);
            }

            return Ok(response);
        }

        //refresh token
        [HttpGet("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {

            var accessToken = Request.Headers["Authorization"];
            if (accessToken.Count == 0)
            {
                return Unauthorized(new GeneralServiceResponse(401, "Access Token is required"));
            }

            var refreshToken = Request.Headers["refreshToken"];
            if (refreshToken.Count == 0)
            {
                return BadRequest(new GeneralServiceResponse(401, "Refresh token is required"));
            }

            AccountToken accountToken = new AccountToken
            {
                AccessToken = accessToken[0].Split(" ")[1],
                RefreshToken = refreshToken[0].Split(" ")[1],
            };

            var response = await _repository.RefreshToken(accountToken);

            if (response.status == 200)
            {
                Response.Headers.Append("Authorization", $"Bearer {response.accessToken}");
                Response.Headers.Append("refreshToken", $"Bearer {response.refreshToken}");
                return Ok(new GeneralServiceResponse(200, "Token refreshed"));
            }
            else
            {
                if (response.msg == "Token not refreshed")
                {
                    return NoContent();
                }
                return Unauthorized(response);
            }

        }


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            var accessToken = Request.Headers["Authorization"];
            if (accessToken.Count == 0)
            {
                return Unauthorized(new GeneralServiceResponse(401, "Access Token is required"));
            }

            Console.WriteLine("access Token " + accessToken[0].Split(" ")[1]);
            AccountToken accountToken = new AccountToken
            {
                AccessToken = accessToken[0].Split(" ")[1],
                RefreshToken = "null",
            };

            var response = await _repository.Logout(accountToken);

            if (response.status == 200)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(AccountChangePassword accountChangePassword)
        {
            var response = await _repository.ChangePassword(accountChangePassword);

            if (response.status == 200)
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

            if (response.status == 200)
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

            if (response.status == 200)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
        }

        [HttpGet("user-role")]
        [Authorize]
        public async Task<IActionResult> GetUserRole()
        {
            var accessToken = Request.Headers["Authorization"];
            if (accessToken.Count == 0)
            {
                return Unauthorized(new GeneralServiceResponse(401, "Access Token is required"));
            }
            string accountToken = accessToken[0].Split(" ")[1];

            var response = await _repository.GetUserRole(accountToken);
            if (response.status == 200)
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