
namespace BookInventoryManagementSystem.Application.Services.Reviews
{
    public interface IReviewsService
    {
        Task<float> GetRatingForBook(int id);
    }
}