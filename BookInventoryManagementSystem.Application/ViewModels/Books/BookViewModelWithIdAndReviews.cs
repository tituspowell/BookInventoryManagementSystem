namespace BookInventoryManagementSystem.Application.ViewModels.Books;

public class BookViewModelWithIdAndReviews : BookViewModelWithId
{
    public required IEnumerable<Review> Reviews { get; set; }

    public string? LoggedInUserIdIfLoggedIn { get; set; }
    public bool LoggedInUserHasExistingReview { get; set; }
}
