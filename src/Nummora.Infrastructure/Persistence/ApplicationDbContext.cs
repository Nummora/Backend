using Microsoft.EntityFrameworkCore;

namespace Nummora.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base  (options)
    {}
}