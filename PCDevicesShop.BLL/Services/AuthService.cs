
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.DAL.Entities;
using PCDevicesShop.DAL.Interfaces;
using System.Security.Claims;

namespace PCDevicesShop.BLL.Services
{
    public class AuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<RegisterDTO> _registeringUserValidator;
        private readonly IValidator<LoginDTO> _loginingInUserValidator;
        private readonly TokenService _tokenService;
        private readonly PasswordService _passwordService;

        public AuthService(
            IUserRepository userRepository,
            IMapper mapper,
            TokenService tokenService,
            PasswordService passwordService,
            IValidator<RegisterDTO>
            registeringUserValidator,
            IValidator<LoginDTO> loginingInUserValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
            _passwordService = passwordService;
            _loginingInUserValidator = loginingInUserValidator;
            _registeringUserValidator = registeringUserValidator;
        }

        public async Task<TokensDTO> RegisterAsync(RegisterDTO registeringUser, CancellationToken ct = default)
        {
            var validationResult = await _registeringUserValidator.ValidateAsync(registeringUser, ct);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var user = _mapper.Map<User>(registeringUser);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken.RefreshToken;
            user.RefreshTokenExpiresAt = refreshToken.ExpiresAt;
            try
            {
                await _userRepository.AddAsync(user, ct);
                var accessToken = _tokenService.GenerateAccessToken(user);
                return new TokensDTO(accessToken, refreshToken.RefreshToken);
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Ошибка при сохранении пользователя", ex);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
        }

        public async Task<TokensDTO> LoginAsync(LoginDTO loginingInUser, CancellationToken ct = default)
        {
            var validationResult = await _loginingInUserValidator.ValidateAsync(loginingInUser, ct);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var user = await _userRepository.GetByUserNameAsync(loginingInUser.UserName, ct);
            if (user == null)
            {
                throw new NullReferenceException("Пользователь не найден");
            }
            if (!_passwordService.ValidatePassword(loginingInUser.Password, user.PasswordHash))
            {
                throw new InvalidOperationException("Неверный пароль");
            }
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken.RefreshToken;
            user.RefreshTokenExpiresAt = refreshToken.ExpiresAt;
            try
            {
                await _userRepository.UpdateAsync(user, ct);
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Ошибка при входе в аккаунт");
            }
            var accessToken = _tokenService.GenerateAccessToken(user);
            return new TokensDTO(accessToken, refreshToken.RefreshToken);
        }

        public async Task<TokensDTO> RefreshAsync(TokensDTO tokens, CancellationToken ct)
        {
            ClaimsPrincipal claimsPrincipal;
            try
            {
                claimsPrincipal = _tokenService.GetPrincipalFromToken(tokens.AccessToken);
            }
            catch
            {
                throw new SecurityTokenException("Неверный acess-токен");
            }
            var login = claimsPrincipal.Identity?.Name;
            if (login == null)
            {
                throw new SecurityTokenException("Неверный acess-токен");
            }
            var user = await _userRepository.GetByUserNameAsync(login, ct);
            if (user == null)
            {
                throw new NullReferenceException("Пользователь не найден " + login);
            }
            if (user.RefreshToken != tokens.RefreshToken || user.RefreshTokenExpiresAt < DateTime.UtcNow)
            {
                throw new SecurityTokenException("Неверный refresh-токен");
            }
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken.RefreshToken;
            user.RefreshTokenExpiresAt = refreshToken.ExpiresAt;
            await _userRepository.UpdateAsync(user, ct);
            var accessToken = _tokenService.GenerateAccessToken(user);
            return new TokensDTO(accessToken, refreshToken.RefreshToken);
        }
    }
}
