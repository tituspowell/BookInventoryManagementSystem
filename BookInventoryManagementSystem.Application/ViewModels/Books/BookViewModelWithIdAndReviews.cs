namespace BookInventoryManagementSystem.Application.ViewModels.Books;

public class BookViewModelWithIdAndReviews : BookViewModelWithId
{
    public required IEnumerable<Review> Reviews { get; set; }
}
