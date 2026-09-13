using WorkList.Api.Features.Authentication.DTOs;

namespace WorkList.Api.Features.Authentication.Services;

public interface IAuthService
{
    Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
}