using BookInventoryManagementSystem.Data.Entities;

namespace BookInventoryManagementSystem.Application.Services.Books;

public interface IBooksService
{
    bool BookExists(int id);
    Task CreateAsync(BookViewModelWithoutId bookVM);
    Task DeleteAsync(int id);
    Task EditAsync(BookViewModelWithId bookVM);
    Task<Book?> GetBookAsync(int id);
}