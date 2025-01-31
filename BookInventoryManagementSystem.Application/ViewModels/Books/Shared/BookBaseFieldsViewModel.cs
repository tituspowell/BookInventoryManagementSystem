using System.ComponentModel;

namespace BookInventoryManagementSystem.Application.ViewModels.Books.Shared;

public abstract class BookBaseFieldsViewModel
{
    // All the common fields for a book, excluding ID since that's not always needed in the various view models,
    // and also the Authors and Tags fields, because those have parsed (list of strings) and unparsed (single string) flavours.
    [Required]
    public required string Title { get; set; }
    [Required]
    public DateOnly? PublicationYear { get; set; }
    [StringLength(13)]
    public string? ISBN { get; set; }
    [StringLength(50)]
    public string? Genre { get; set; }
    [DisplayName("Cover Image URL")]
    public string? CoverImageURL { get; set; }
    public List<string>? Tags { get; set; } = [];
}
