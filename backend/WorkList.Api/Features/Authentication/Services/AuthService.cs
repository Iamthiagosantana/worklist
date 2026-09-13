using WorkList.Api.Features.Authentication.DTOs;
using WorkList.Api.Features.Authentication.Entities;
using WorkList.Api.Features.Authentication.Repositories;

namespace WorkList.Api.Features.Authentication.Services;

public class AuthService : IAuthService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    
    public AuthService(IPasswordHasher passwordHasher, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
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
        
        return new RegisterResponse(user.Id, user.Username);
    }
}