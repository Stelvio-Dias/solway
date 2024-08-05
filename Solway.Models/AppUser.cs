using Microsoft.AspNetCore.Identity;

namespace Solway.Models;

public class AppUser : IdentityUser
{
    public string PictureUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();
}