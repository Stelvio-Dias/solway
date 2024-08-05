using Microsoft.Extensions.Logging;
using Solway.Models;
using System.Text.Json;

namespace Solway.DAC.Seed;

public class SolwayContextSeed
{
    public static async Task SeedAsync(SolwayDbContext context, ILoggerFactory loggerFactory)
    {
        /*try
        {
            // Seed Media type
            if (!context.MediaTypes.Any())
            {
                var mediaTypesFile = File.ReadAllText("../Solway.DAC/Seed/MediaTypes.json");
                var mediaTypes = JsonSerializer.Deserialize<List<MediaType>>(mediaTypesFile)!;

                await context.AddRangeAsync(mediaTypes);

                await context.SaveChangesAsync();
            }

            // Seed App User
            if (!context.AppUsers.Any())
            {
                var appUsersFile = File.ReadAllText("../Solway.DAC/Seed/AppUsers.json");
                var appUsers = JsonSerializer.Deserialize<List<AppUser>>(appUsersFile)!;

                await context.AddRangeAsync(appUsers);

                await context.SaveChangesAsync();
            }

            // Seed Content
            if (!context.Contents.Any())
            {
                var contentFile = File.ReadAllText("../Solway.DAC/Seed/Contents.json");
                var contents = JsonSerializer.Deserialize<List<Content>>(contentFile)!;

                await context.AddRangeAsync(contents);

                await context.SaveChangesAsync();
            }

        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<SolwayContextSeed>();
            logger.LogWarning(ex, ex.Message);
        }*/
    }
}