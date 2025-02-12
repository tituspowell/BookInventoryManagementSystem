
namespace BookInventoryManagementSystem.Application.Services.BooksReviewsSharedService;

public interface IBooksReviewsSharedService
{
    Task<List<BookViewModelWithId>> GetAllBookViewModelsAsync();
    Task<BookViewModelWithIdAndReviews> GetBookViewModelWithIdAndReviewsAsync(int bookId);
}