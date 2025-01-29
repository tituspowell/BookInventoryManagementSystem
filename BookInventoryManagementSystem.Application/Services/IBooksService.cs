
namespace BookInventoryManagementSystem.Application.Services;

public interface IBooksService
{
    Task<List<BookIndexViewModel>> GetBooksAsync();
}