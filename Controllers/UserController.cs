using AutoMapper;
using Inventory.Model;
using Inventory.Model.MyDTO;
using Inventory.Services.IServices;
using Microsoft.AspNetCore.Mvc;


namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase


    {
        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly IMapper _mapper;
            private readonly IUser _userService;
            private readonly IJwt _jwtService;

            public UsersController(IMapper mapper, IUser userService, IJwt jwtService)
            {
                _mapper = mapper;
                _userService = userService;
                _jwtService = jwtService;
            }

            [HttpPost("register")]
            public async Task<ActionResult<string>> RegisterUser(AddUserDTO addUserDto)
            {
                var user = _mapper.Map<User>(addUserDto);
                user.Password = BCrypt.Net.BCrypt.HashPassword(addUserDto.Password);

                var checkUser = await _userService.GetUserByEmail(addUserDto.Email);
                if (checkUser != null)
                {
                    return BadRequest("Email Already Exists");
                }

                var response = await _userService.RegisterUser(user);
                return Ok(response);
            }

            [HttpPost("login")]
            public async Task<ActionResult<string>> LoginUser(LogUserDTO user)
            {
                var checkUser = await _userService.GetUserByEmail(user.Email);

                if (checkUser == null)
                {
                    return BadRequest("Invalid Credentials");
                }

                var isCorrect = BCrypt.Net.BCrypt.Verify(user.Password, checkUser.Password);
                if (!isCorrect)
                {
                    return BadRequest("Invalid Credentials");
                }

                var token = _jwtService.GenerateToken(checkUser);
                return Ok(token);
            }
        }
    }
}

