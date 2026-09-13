using WorkList.Api.Features.Authentication.Entities;

namespace WorkList.Api.Infrastructure.Authentication;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}