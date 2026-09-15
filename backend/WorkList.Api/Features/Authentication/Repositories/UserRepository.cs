using Microsoft.EntityFrameworkCore;
using WorkList.Api.Features.Authentication.Entities;
using WorkList.Api.Infrastructure.Persistence;

namespace WorkList.Api.Features.Authentication.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WorkListDbContext _db;
    
    public UserRepository(WorkListDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetUserByNameAsync(string userName)
    {
        return await _db.Users.FirstOrDefaultAsync(user => user.Username == userName);
    }

    public async Task<bool> IsNameUniqueAsync(string userName)
    {
        return !await _db.Users.AnyAsync(user => user.Username == userName);
    }

    public async Task AddAsync(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }
}