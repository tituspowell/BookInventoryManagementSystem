using System.ComponentModel;

namespace BookInventoryManagementSystem.Application.ViewModels.Books.Shared;

public class BookBaseFieldsWithParsedListsViewModel : BookBaseFieldsViewModel
{
    // The read only version of a book, with Authors as a pre-parsed list of strings, how it is stored in the database
    [Required]
    public required List<string> Authors { get; set; } = [];

    public string GetParsedAuthorList()
    {
        return Authors.Count == 1 ? Authors.First() : string.Join(", ", Authors);
    }
}
