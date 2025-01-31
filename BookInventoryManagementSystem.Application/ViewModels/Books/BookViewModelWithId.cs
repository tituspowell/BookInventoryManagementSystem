namespace BookInventoryManagementSystem.Application.ViewModels.Books;

public class BookViewModelWithId : BookViewModelWithoutId
{
    public required int Id { get; set; }
}
