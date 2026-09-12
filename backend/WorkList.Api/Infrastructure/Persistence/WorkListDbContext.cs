using Microsoft.EntityFrameworkCore;

namespace WorkList.Api.Infrastructure.Persistence;

public class WorkListDbContext : DbContext
{
    public WorkListDbContext(DbContextOptions<WorkListDbContext> options)
        : base(options)
    {
        
    }
}