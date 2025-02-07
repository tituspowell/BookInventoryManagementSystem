
namespace BookInventoryManagementSystem.Application.Services.BooksReviewsSharedService;

public interface IBooksReviewsSharedService
{
    Task<BookViewModelWithIdAndReviews> GetBookViewModelWithIdAndReviewsAsync(int bookId);
}