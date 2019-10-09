using System.Threading.Tasks;
using AutoMapper;
using Fisher.Core.Data.Dtos;
using Fisher.Core.Domain;
using Fisher.Core.Services;
using Fisher.Core.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IMapper _mapper;
        private IJwtHandler _jwtHandler;
        private string _role = "User";

        public AuthController(IAuthService service,IJwtHandler jwtHandler,IMapper mapper)
        {
            _authService = service;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<IActionResult> Register(SignUpDto signUpDto)
        {
            var user = new User
            {
                Email = signUpDto.Email,
                UserName = signUpDto.UserName
            };

            await _authService.Register(user, signUpDto.Password);
            return Ok(); //change for Created (201 code)
        }

        public async Task<IActionResult> Login(SignInDto signInDto)
        {
           await _authService.Login(signInDto.UserName, signInDto.Password);
           var token = _jwtHandler.GetToken(signInDto.UserName, _role);
           return Ok(token);
        }
    }
}