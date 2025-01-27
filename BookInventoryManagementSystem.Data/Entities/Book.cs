namespace BookInventoryManagementSystem.Data.Entities;

public class Book : BaseEntity
{
    public required string Title { get; set; }
    public required List<string> Authors { get; set; } = [];
    public DateOnly? PublicationYear { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public string? CoverImageURL { get; set; }
    public required List<string> Tags { get; set; } = [];
}
