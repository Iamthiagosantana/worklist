using WorkList.Api.Features.Authentication.DTOs;
using WorkList.Api.Features.Authentication.Entities;
using WorkList.Api.Features.Authentication.Repositories;
using WorkList.Api.Infrastructure.Authentication;

namespace WorkList.Api.Features.Authentication.Services;

public class AuthService : IAuthService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    
    public AuthService(IPasswordHasher passwordHasher, IUserRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest)
    {
        var isUnique = await _userRepository.IsNameUniqueAsync(registerRequest.Username);

        if (!isUnique)
        {
            throw new Exception("Username is already taken.");
        }

        var hashPassword = _passwordHasher.Hash(registerRequest.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = registerRequest.Username,
            PasswordHash = hashPassword
        };

        await _userRepository.AddAsync(user);
        
        var token = _jwtTokenService.GenerateToken(user);
        
        return new RegisterResponse(token);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserByNameAsync(loginRequest.Username);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        var isPasswordCorrect = _passwordHasher.Verify(user.PasswordHash, loginRequest.Password);

        if (!isPasswordCorrect)
        {
            throw new Exception("Password is incorrect.");
        }
        
        var token = _jwtTokenService.GenerateToken(user);
        
        return new LoginResponse(token);
    }
}