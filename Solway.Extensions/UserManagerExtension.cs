using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Solway.Models;
using System.Security.Claims;

namespace Solway.Extensions;

public static class UserManagerExtension
{
    public static async Task<AppUser?> FindUserByEmailWithClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
    {
        string? email = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
    }
}