using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCDevicesShop.API.Models;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.BLL.Services;

namespace PCDevicesShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(AuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel registeringUser, CancellationToken ct)
        {
            var registerDTO = _mapper.Map<RegisterDTO>(registeringUser);
            var tokens = await _authService.RegisterAsync(registerDTO, ct);
            return Ok(new {tokens.AccessToken, tokens.RefreshToken });  
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginingInUser, CancellationToken ct)
        {
            var loginDTO = _mapper.Map<LoginDTO>(loginingInUser);
            var tokens = await _authService.LoginAsync(loginDTO, ct);
            return Ok(new {tokens.AccessToken, tokens.RefreshToken});
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokensModel requestTokens, CancellationToken ct)
        {
            TokensDTO tokensDTO = _mapper.Map<TokensDTO>(requestTokens);
            var responseTokens = await _authService.RefreshAsync(tokensDTO, ct);
            return Ok(new {responseTokens.AccessToken, responseTokens.RefreshToken});
        }
    }
}
