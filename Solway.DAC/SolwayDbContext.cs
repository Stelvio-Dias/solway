using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Solway.Models;
using System.Text.Json;

namespace Solway.DAC;

public class SolwayDbContext : DbContext
{
    public DbSet<Content> Contents { get; set; }
    public DbSet<MediaType> MediaTypes { get; set; }

    public SolwayDbContext(DbContextOptions<SolwayDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed media type
        /*var mediaTypesFile = File.ReadAllText("../Solway.DAC/Seed/MediaTypes.json");
        var mediaTypes = JsonSerializer.Deserialize<List<MediaType>>(mediaTypesFile)!;
        //foreach (var mediaType in mediaTypes) modelBuilder.Entity<MediaType>().HasData(mediaType);

        // Seed app user
        var appUsersFile = File.ReadAllText("../Solway.DAC/Seed/AppUsers.json");
        var appUsers = JsonSerializer.Deserialize<List<AppUser>>(appUsersFile)!;
        //foreach (var appUser in appUsers) modelBuilder.Entity<AppUser>().HasData(appUser);

        // Seed Content
        var contentFile = File.ReadAllText("../Solway.DAC/Seed/Contents.json");
        var contents = JsonSerializer.Deserialize<List<Content>>(contentFile)!;*/
        //foreach (var content in contents) modelBuilder.Entity<Content>().HasData(content);
    }
}