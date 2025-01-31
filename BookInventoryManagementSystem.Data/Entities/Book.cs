namespace BookInventoryManagementSystem.Data.Entities;

public class Book : BaseEntityWithId
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public DateOnly? PublicationYear { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public string? CoverImageURL { get; set; }
    public string? Tags { get; set; }
}
