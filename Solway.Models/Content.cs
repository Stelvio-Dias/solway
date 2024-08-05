namespace Solway.Models;

public class Content : BaseEntity
{
    public string ContentURL { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
    public float Height { get; set; }
    public float Width { get; set; }
    public string Description { get; set; } = string.Empty;

    // Media type Relashionship
    public int MediaTypeId { get; set; }
    public virtual MediaType MediaType { get; set; } = null!;

    //  App User Relationship
    public string AppUserId { get; set; } = string.Empty;
    public virtual AppUser AppUser { get; set; } = null!;
}   