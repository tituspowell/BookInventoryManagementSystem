using AutoMapper;
using BookInventoryManagementSystem.Application.Services.Reviews;
using BookInventoryManagementSystem.Application.Services.Users;
using Microsoft.AspNetCore.Http.HttpResults;

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
        var book = await _booksService.GetBookAsync(bookId);

        if (book == null)
        {
            return null;
        }

        var bookVM = _mapper.Map<BookViewModelWithIdAndReviews>(book);

        // Add the reviews if there are any
        bookVM.Reviews = await _reviewsService.GetReviewsForBookAsync(book.Id);

        bookVM.LoggedInUserId = await _userService.GetIdOfLoggedInUserAsync();

        bookVM.LoggedInUserHasExistingReview = await _reviewsService.ReviewExistsByUserForBookAsync(bookId, bookVM.LoggedInUserId);

        return bookVM;
    }

}
