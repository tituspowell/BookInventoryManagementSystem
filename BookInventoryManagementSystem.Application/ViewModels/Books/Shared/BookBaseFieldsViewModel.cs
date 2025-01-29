namespace BookInventoryManagementSystem.Application.ViewModels.Books.Shared;

public class BookBaseFieldsViewModel
{
    [Required]
    public required string Title { get; set; }
    [Required]
    public required List<string> Authors { get; set; } = [];
    public DateOnly? PublicationYear { get; set; }
    [StringLength(13)]
    public string? ISBN { get; set; }
    [StringLength(50)]
    public string? Genre { get; set; }
    public string? CoverImageURL { get; set; }
    public List<string> Tags { get; set; } = [];
}
