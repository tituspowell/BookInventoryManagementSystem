using System.ComponentModel;

namespace BookInventoryManagementSystem.Application.ViewModels.Books.Shared;

public abstract class BookBaseFieldsViewModel
{
    [Required]
    public required string Title { get; set; }
    [Required]
    public required List<string> Authors { get; set; } = [];
    [DisplayName("Publication Year")]
    public DateOnly? PublicationYear { get; set; }
    [StringLength(13)]
    public string? ISBN { get; set; }
    [StringLength(50)]
    public string? Genre { get; set; }
    [DisplayName("Cover Image URL")]
    public string? CoverImageURL { get; set; }
    public List<string>? Tags { get; set; } = [];

    public string GetParsedAuthorList()
    {
        return Authors.Count == 1 ? Authors.First() : string.Join(", ", Authors);
    }
}
