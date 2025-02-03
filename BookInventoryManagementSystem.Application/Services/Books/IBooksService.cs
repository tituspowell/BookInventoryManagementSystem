namespace BookInventoryManagementSystem.Application.Services.Books;

public interface IBooksService
{
    bool BookExists(int id);
    Task CreateAsync(BookViewModelWithoutId bookVM);
    Task DeleteAsync(int id);
    Task EditAsync(BookViewModelWithId bookVM);
    Task<List<BookViewModelWithId>> GetAllAsync();
    Task<T?> GetBookAsync<T>(int id) where T : class;
}