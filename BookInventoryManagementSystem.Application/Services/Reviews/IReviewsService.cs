
namespace BookInventoryManagementSystem.Application.Services.Reviews
{
    public interface IReviewsService
    {
        Task CreateAsync(ReviewCreateViewModel reviewVM);
        Task<IEnumerable<Review>> GetReviewsForBookAsync(int id);
        Task<float> GetAverageRatingForBookAsync(int id);
        Task<int> GetNumberOfReviewsForBookAsync(int id);
        Task<bool> ReviewExistsByUserForBookAsync(int bookId, string userId);
    }
}