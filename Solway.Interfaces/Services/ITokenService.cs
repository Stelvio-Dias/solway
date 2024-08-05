using Solway.Models;

namespace Solway.Interfaces.Services;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}