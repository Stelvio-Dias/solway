using Solway.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Solway.DAC.Identity;

public class IdentityDataContext : IdentityDbContext<AppUser>
{
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
}