using Solway.Models;

namespace Solway.DTO;

public class AppUserDTO
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    public IEnumerable<ContentDTO> Contents { get; set; } = Enumerable.Empty<ContentDTO>();
}