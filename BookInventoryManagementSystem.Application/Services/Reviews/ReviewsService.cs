using AutoMapper;
using BookInventoryManagementSystem.Application.Services.Users;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Application.Services.Reviews;

public class ReviewsService(ApplicationDbContext _context,
    IBooksService _booksService,
    IUserService _userService,
    IMapper _mapper) : IReviewsService
{
    public async Task CreateAsync(ReviewViewModel reviewVM)
    {
        var review = _mapper.Map<Review>(reviewVM);

        _context.Add(review);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Review>> GetReviewsForBookAsync(int id)
    {
        return await _context.Reviews
            .Where(r => r.BookId == id)
            .Include(r => r.Reviewer)
            .ToListAsync();
    }

    public async Task<float> GetAverageRatingForBookAsync(int id)
    {
        var book = await _booksService.GetBookAsync(id);

        var reviews = await _context.Reviews
            .Where(r => r.BookId == id)
            .ToListAsync();

        if (reviews.Count == 0)
        {
            return 0;
        }

        var averageRating = reviews.Average(r => r.RatingOutOfFive);

        return (float)averageRating;
    }

    public async Task<int> GetNumberOfReviewsForBookAsync(int id)
    {
        var book = await _booksService.GetBookAsync(id);

        var numberOfReviews = await _context.Reviews
            .Where(r => r.BookId == id)
            .CountAsync();

        return numberOfReviews;
    }

    public async Task<bool> ReviewExistsByUserForBookAsync(int bookId, string userId)
    {
        return await _context.Reviews
            .Where(r => r.BookId == bookId)
            .Where(r => r.ReviewerId == userId)
            .AnyAsync();
    }

    public async Task<ReviewViewModelWithBookInfoAndId> GetReviewViewModelAsync(int id)
    {
        var review = await _context.Reviews.SingleAsync(r => r.Id == id) ?? throw new Exception($"Review with ID {id} not found");
        var reviewVM = _mapper.Map<ReviewViewModelWithBookInfoAndId>(review);

        var book = await _booksService.GetBookAsync(reviewVM.BookId) ?? throw new Exception($"Book with ID {reviewVM.BookId} not found");
        reviewVM.BookTitle = book.Title;
        reviewVM.BookAuthor = book.Author;

        var reviewer = await _userService.GetUserByIdAsync(review.ReviewerId);
        reviewVM.ReviewerName = $"{reviewer.FirstName} {reviewer.LastName}";

        // TODO: four awaits doesn't feel very optimised...
        var loggedInUser = await _userService.GetLoggedInApplicationUserAsync();
        if (loggedInUser == null)
        {
            reviewVM.ReviewIsByLoggedInUser = false;
        }
        else
        {
            reviewVM.ReviewIsByLoggedInUser = review.ReviewerId == loggedInUser.Id;
        }

        return reviewVM;
    }

    public async Task<bool> AllowedToEditReview(int id)
    {
        var userId = await _userService.GetIdOfLoggedInUserAsync();
        if (string.IsNullOrEmpty(userId))
        {
            // Not logged in, so no
            return false;
        }

        if (await _userService.IsLibrarianOrAdminAsync(userId))
        {
            // They have sufficient privileges
            return true;
        }

        if (await ReviewIsByUserAsync(id, userId))
        {
            // It's their review, so yes
            return true;
        }

        return false;
    }

    public async Task EditAsync(ReviewViewModelWithBookInfoAndId reviewVM)
    {
        // Verify once more that they are allowed to edit this review, i.e. that it's theirs
        var allowedToEditReview = await AllowedToEditReview(reviewVM.Id);
        if (!allowedToEditReview)
        {
            throw new Exception("Not allowed to edit review!");
        }

        var existingReview = await _context.Reviews.SingleAsync(r => r.Id == reviewVM.Id) ?? throw new Exception($"Review with ID {reviewVM.Id} not found");

        var book = await _context.Books.SingleAsync(b => b.Id == existingReview.BookId) ?? throw new Exception($"Book with ID {existingReview.BookId} not found");
        existingReview.Book = book;

        _mapper.Map(reviewVM, existingReview);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review != null)
        {
            _context.Reviews.Remove(review);
        }

        await _context.SaveChangesAsync();
    }

    // Private methods

    private async Task<bool> ReviewIsByUserAsync(int id, string userId)
    {
        return await _context.Reviews
            .Where(r => r.Id == id)
            .Where(r => r.ReviewerId == userId)
            .AnyAsync();
    }

}
