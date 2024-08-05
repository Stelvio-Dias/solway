using Solway.Models;

namespace Solway.DTO;

public class ContentDTO
{
    public int Id { get; set; }
    public string ContentURL { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
    public float Height { get; set; }
    public float Width { get; set; }
    public string Description { get; set; } = string.Empty;

    public int MediaTypeId { get; set; }
    public MediaTypeDTO MediaType { get; set; } = null!;
}