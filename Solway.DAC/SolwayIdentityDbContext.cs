using Solway.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Solway.DAC;

public class SolwayIdentityDbContext : IdentityDbContext<AppUser>
{
    public SolwayIdentityDbContext(DbContextOptions<SolwayIdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
}