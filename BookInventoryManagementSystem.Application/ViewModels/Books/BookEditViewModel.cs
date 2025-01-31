namespace BookInventoryManagementSystem.Application.ViewModels.Books;

public class BookEditViewModel : BookBaseFieldsWithUnparsedListsViewModel
{
    [Required]
    public required int Id { get; set; }
}
