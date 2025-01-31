namespace BookInventoryManagementSystem.Application.ViewModels.Books.Shared;

public class BookBaseFieldsIncludingIdViewModel : BookBaseFieldsViewModel
{
    // All the book fields including the ID
    public required int Id { get; set; }
}
