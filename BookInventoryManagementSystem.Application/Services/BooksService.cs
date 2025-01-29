using AutoMapper;
using BookInventoryManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Application.Services;

public class BooksService(ApplicationDbContext _context, IMapper _mapper) : IBooksService
{
    public async Task<List<BookIndexViewModel>> GetBooksAsync()
    {
        List<Book> bookList = await _context.Books.ToListAsync();

        var bookVMList = _mapper.Map<List<BookIndexViewModel>>(bookList);
        return bookVMList;
    }
}
