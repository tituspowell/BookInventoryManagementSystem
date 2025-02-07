
namespace BookInventoryManagementSystem.Application.Services.Reviews
{
    public interface IReviewsService
    {
        Task CreateAsync(ReviewCreateViewModel reviewVM);
        Task<IEnumerable<Review>> GetReviewsForBookAsync(int id);
        Task<float> GetRatingForBook(int id);
        Task<bool> ReviewExistsByUserForBook(int bookId, string userId);
    }
}