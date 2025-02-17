using AutoMapper;
using BookInventoryManagementSystem.Application.Services.Reviews;
using BookInventoryManagementSystem.Application.Services.Users;

namespace BookInventoryManagementSystem.Application.Services.BooksReviewsSharedService;

public class BooksReviewsSharedService(
    ApplicationDbContext _context,
    IBooksService _booksService,
    IReviewsService _reviewsService,
    IUserService _userService,
    IMapper _mapper) : IBooksReviewsSharedService
{
    // This exists to avoid circular dependencies where the books service relies on the reviews service and vice versa

    public async Task<List<BookViewModelWithId>> GetAllBookViewModelsAsync()
    {
        List<Book> bookList = _context.Books.ToList();

        var bookVMList = _mapper.Map<List<BookViewModelWithId>>(bookList);

        foreach (var bookVM in bookVMList)
        {
            bookVM.NumberOfReviews = await _reviewsService.GetNumberOfReviewsForBookAsync(bookVM.Id);
            bookVM.AverageRating = await _reviewsService.GetAverageRatingForBookAsync(bookVM.Id);
        }

        return bookVMList;
    }

    public async Task<BookViewModelWithIdAndReviews> GetBookViewModelWithIdAndReviewsAsync(int bookId)
    {
        var book = await _booksService.GetBookAsync(bookId) ?? throw new Exception($"Book with ID {bookId} not found!");

        var bookVM = _mapper.Map<BookViewModelWithIdAndReviews>(book);

        // Get the logged-in user's ID
        bookVM.LoggedInUserIdIfLoggedIn = await _userService.GetIdOfLoggedInUserAsync();

        // Add the reviews if there are any, and order them
        var reviews = await _reviewsService.GetReviewsForBookAsync(book.Id);
        bookVM.Reviews = reviews.OrderByDescending(r => r.ReviewerId == bookVM.LoggedInUserIdIfLoggedIn)
                                .ThenByDescending(r => r.CreatedAt)
                                .ToList();

        bookVM.NumberOfReviews = bookVM.Reviews.Count();

        // Don't blow up if there are no reviews
        if (bookVM.NumberOfReviews > 0)
        {
            bookVM.AverageRating = (float)bookVM.Reviews.Average(r => r.RatingOutOfFive);
        }
        else
        {
            bookVM.AverageRating = 0;
        }

        bookVM.LoggedInUserHasExistingReview = await _reviewsService.ReviewExistsByUserForBookAsync(bookId, bookVM.LoggedInUserIdIfLoggedIn);

        return bookVM;
    }
}
