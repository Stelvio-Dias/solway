namespace Solway.Models;

public class MediaType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual ICollection<Content> Contents { get; set; } = null!;
}