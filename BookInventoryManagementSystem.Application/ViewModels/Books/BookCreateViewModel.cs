using System.ComponentModel;

namespace BookInventoryManagementSystem.Application.ViewModels.Books;

public class BookCreateViewModel
{
    [Required]
    public required string Title { get; set; }

    // When they submit the details for a new book, the authors field is just a string with newlines separating multiple authors.
    // This is then converted to a list of strings before it is stored in the database
    [Required]
    [DisplayName("Authors")]
    public string AuthorsUnparsed { get; set; }

    [DisplayName("Publication Year")]
    public DateOnly? PublicationYear { get; set; }

    [StringLength(13)]
    public string? ISBN { get; set; }

    [StringLength(50)]
    public string? Genre { get; set; }

    [DisplayName("Cover Image URL")]
    public string? CoverImageURL { get; set; }

    // QQ TODO - This will need the same treatment as Authors
    public List<string>? Tags { get; set; } = [];
}
