using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Application.Services.Reviews;

public class ReviewsService(ApplicationDbContext _context,
    IBooksService _booksService,
    IMapper _mapper) : IReviewsService
{
    public async Task CreateAsync(ReviewCreateViewModel reviewVM)
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

    public async Task<float> GetAverageRatingForBook(int id)
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

    public async Task<int> GetNumberOfReviewsForBook(int id)
    {
        var book = await _booksService.GetBookAsync(id);

        var numberOfReviews = await _context.Reviews
            .Where(r => r.BookId == id)
            .CountAsync();

        return numberOfReviews;
    }

    public async Task<bool> ReviewExistsByUserForBook(int bookId, string userId)
    {
        return await _context.Reviews
            .Where(r => r.BookId == bookId)
            .Where(r => r.ReviewerId == userId)
            .AnyAsync();
    }
}
