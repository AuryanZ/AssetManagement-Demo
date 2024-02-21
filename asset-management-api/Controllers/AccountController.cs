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
    public class AccountController : ControllerBase
    {
        // private readonly UserManager<IdentityUser> _userManager;
        // private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAccountRepo _repository;
        private readonly IMapper _mapper;

        public AccountController(
        // UserManager<IdentityUser> userManager, 
        // SignInManager<IdentityUser> signInManager, 
        IAccountRepo repository, IMapper mapper)
        {
            // _userManager = userManager;
            // _signInManager = signInManager;
            _mapper = mapper;
            _repository = repository;
        }

        // GET api/login
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<AccountReadDto> GetUserById(int id)
        {
            var accountItem = _repository.GetUserById(id);
            if (accountItem != null)
            {
                return Ok(_mapper.Map<AccountReadDto>(accountItem));
            }
            return NotFound();
        }

        [HttpGet("username/{username}", Name = "GetUserByUsername")]
        public ActionResult<AccountReadDto> GetUserByUsername(string username)
        {
            var accountItem = _repository.GetUserByUserName(username);
            if (accountItem != null)
            {
                return Ok(_mapper.Map<AccountReadDto>(accountItem));
            }
            return NotFound();
        }

        // POST api/login
        [HttpPost]
        public ActionResult<AccountReadDto> Login(AccountReadDto signInModel)
        {
            // var user = await _userManager.FindByNameAsync(signInModel.Username);
            // Console.WriteLine(signInModel.Username);
            // Console.WriteLine("Login");
            var user = _repository.GetUserByUserName(signInModel.Username)
               ?? _repository.GetUserByEmail(signInModel.Username);
            if (user != null)
            {
                if (user.IsActive == false)
                {
                    return Unauthorized(new { message = "User is not active" });
                }
                // var result = _signInManager.PasswordSignInAsync(user, signInModel.Password, false, false);
                var result = user.Password == signInModel.Password;
                if (result.Equals(true))
                {
                    // Update user LastLogin to db
                    user.LastLogin = DateTime.Now;
                    _repository.UpdateUserLastLogin(user);
                    _repository.SaveChanges();

                    return Ok();
                }
            }

            return Unauthorized();
        }

        // Create User
        [HttpPost("create")]
        public ActionResult<AccountReadDto> CreateUser(AccountCreateDto accountCreateDto)
        {
            var accountModel = _mapper.Map<AccountModel>(accountCreateDto);

            if (_repository.GetUserByUserName(accountModel.Username) != null)
            {
                return Conflict(new { message = "Username already exists" });
            }

            if (_repository.GetUserByEmail(accountModel.Email) != null)
            {
                return Conflict(new { message = "Email already exists" });
            }

            if (accountModel.Role == null)
            {
                accountModel.Role = "user";
            }
            accountModel.IsActive = true;
            accountModel.CreatDate = DateTime.Now;

            _repository.CreateUser(accountModel);
            _repository.SaveChanges();

            var accountReadDto = _mapper.Map<AccountReadDto>(accountModel);

            return CreatedAtRoute(nameof(GetUserById), new { id = accountReadDto.Id }, accountReadDto);
        }

        // Update User
        [HttpPatch("{id}")]
        public ActionResult<AccountReadDto> UpdateUser(int id, JsonPatchDocument<AccountUpdateDto> accountPatch)
        {
            var accountModelFromRepo = _repository.GetUserById(id);
            if (accountModelFromRepo == null)
            {
                return NotFound();
            }

            // Check if the user is trying to update the username
            if (accountPatch.Operations[0].path == "/username")
            {
                if (_repository.GetUserByUserName(accountPatch.Operations[0].value.ToString()) != null)
                {
                    return Conflict(new { message = "Username already exists" });
                }
            }

            // Check if the user is trying to update the email
            if (accountPatch.Operations[0].path == "/Email")
            {
                if (_repository.GetUserByEmail(accountPatch.Operations[0].value.ToString()) != null)
                {
                    return Conflict(new { message = "Email already exists" });
                }
            }

            var accountToPatch = _mapper.Map<AccountUpdateDto>(accountModelFromRepo);

            accountPatch.ApplyTo(accountToPatch, ModelState);

            if (!TryValidateModel(accountToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(accountToPatch, accountModelFromRepo);

            _repository.UpdateUser(accountModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }


}