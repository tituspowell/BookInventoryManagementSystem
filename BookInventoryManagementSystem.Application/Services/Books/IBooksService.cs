﻿using BookInventoryManagementSystem.Data.Entities;

namespace BookInventoryManagementSystem.Application.Services.Books;

public interface IBooksService
{
    bool BookExists(int id);
    Task CreateAsync(BookViewModelWithoutId bookVM);
    Task DeleteAsync(int id);
    Task EditAsync(BookViewModelWithId bookVM);
    Task<List<BookViewModelWithId>> GetAllAsync();
    Task<BookViewModelWithId> GetBookViewModelWithIdAsync(int id);
    Task<Book?> GetBookAsync(int id);
}