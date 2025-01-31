using System.ComponentModel;

namespace BookInventoryManagementSystem.Application.ViewModels.Books.Shared;

public class BookBaseFieldsWithUnparsedListsViewModel : BookBaseFieldsViewModel
{
    // The input version of a created or edited book, with Authors as a single string that needs to be parsed into a list of strings before it can be stored in the database
    [Required]
    [DisplayName("Authors")]
    public required string UnparsedAuthors { get; set; }
}
