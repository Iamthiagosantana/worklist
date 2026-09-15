using WorkList.Api.Features.Authentication.Entities;

namespace WorkList.Api.Features.Authentication.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByNameAsync(string userName);
    Task<bool> IsNameUniqueAsync(string userName);
    Task AddAsync(User user);
}