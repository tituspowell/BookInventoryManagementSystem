
namespace BookInventoryManagementSystem.Application.Services.Reviews
{
    public interface IReviewsService
    {
        Task CreateAsync(ReviewCreateViewModel reviewVM);
        Task<IEnumerable<Review>> GetReviewsForBookAsync(int id);
        Task<float> GetAverageRatingForBook(int id);
        Task<int> GetNumberOfReviewsForBook(int id);
        Task<bool> ReviewExistsByUserForBook(int bookId, string userId);
    }
}