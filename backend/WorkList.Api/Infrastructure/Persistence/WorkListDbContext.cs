using Microsoft.EntityFrameworkCore;
using WorkList.Api.Features.Authentication.Entities;

namespace WorkList.Api.Infrastructure.Persistence;

public class WorkListDbContext : DbContext
{
    public WorkListDbContext(DbContextOptions<WorkListDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}