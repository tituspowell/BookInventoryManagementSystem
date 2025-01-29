
namespace BookInventoryManagementSystem.Application.Services;

public interface IBooksService
{
    bool BookExists(int id);
    Task CreateAsync(BookCreateViewModel bookVM);
    Task DeleteAsync(int id);
    Task EditAsync(BookEditViewModel bookVM);
    Task<List<BookIndexViewModel>> GetAllAsync();
    Task<T?> GetBookAsync<T>(int id) where T : class;
}